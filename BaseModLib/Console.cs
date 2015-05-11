/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  To contact me you can e-mail me at info@fluffyfish.de
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModAPI
{
    public class Console
    {
        const int MAX_LINES = 200;
        public static List<string> Lines = new List<string>();
        public delegate void CommandCallback(string param);
        public delegate void ComplexCommandCallback(string[] param);
        protected static Dictionary<string, Command> Commands = new Dictionary<string, Command>();
        public delegate void CloseCallback();
        public static CloseCallback OnClose;
        protected static ConsoleComponent consoleComponent;

        [ModAPI.Attributes.AddModname]
        public static void Write(string Message)
        {
        }

        public static Command GetCommand(string Command)
        {
            Command = Command.ToLower();
            if (Commands.ContainsKey(Command))
            {
                return Commands[Command];
            }
            return null;
        }
        public static void Write(string Message, string ModName) {
            Lines.Add("["+ModName+"]: "+Message);
            if (Lines.Count > MAX_LINES)
                Lines.RemoveAt(0);
        }

        public static ConsoleComponent GetConsoleComponent()
        {
            return consoleComponent;
        }

        public static List<string> GetPossibleValues(string Input)
        {
            List<string> ret = new List<string>();
            try
            {
                foreach (Command command in Commands.Values)
                {
                    if (command.IsMatch(Input))
                    {
                        return command.GetAutoCompletion(Input);
                    }
                }
            }
            catch (Exception e)
            {
                Write(e.ToString(), "Core");
            }
            return ret;
        }

        public static void ParseInput(string Input)
        {
            try
            {
                Input = Input.Trim();
                foreach (Command command in Commands.Values)
                {
                    if (command.IsMatch(Input))
                    {
                        string ErrorText = command.GetErrorText(Input);
                        if (ErrorText != "")
                        {
                            Write(ErrorText, command.CommandName);
                            return;
                        }
                        else
                        {
                            object[] param = command.GetParameters(Input);
                            try
                            {
                                command.OnSubmit(param);
                            }
                            catch (Exception ex)
                            {
                                Console.Write("An error occured while executing the command:\r\n"+ex.ToString(), "Core");
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString(), "Core");
            }
        }

        public static void Switch()
        {
            if (GetConsoleComponent().opened)
                Close();
            else
                Open();
        }
        public static void Open()
        {
            GetConsoleComponent().Open();
        }

        public static void Close()
        {
            GetConsoleComponent().Close();
            if (OnClose != null)
                OnClose();
        }

        public static void RegisterCommand(Command command)
        {
            string name = command.CommandName;
            if (!Commands.ContainsKey(name.ToLower()))
            {
                if (command.IsValid())
                {
                    Commands.Add(name.ToLower(), command);
                    if (name != "help")
                        CommandList.Add(name);
                }
                else
                {
                    Write("Command \"" + name + "\" couldn't be added. It's invalid.");
                }
            }
            else
            {
                Write("Command \"" + name + "\" couldn't be added. It already exists.");
            }
        }

        protected static bool initialized = false;
        protected static List<string> CommandList = new List<string>();

        protected static void Help(object[] param)
        {
            if (param.Length == 0 || param[0] == "")
            {
                Write("Available commands: " + string.Join(", ", CommandList.ToArray()), "Help");
            }
            else
            {
                if (CommandList.Contains((string)param[0]))
                {
                    Command com = Commands[(string)param[0]];
                    string help = "Help for command \"" + Commands[(string)param[0]].CommandName + "\":\r\n"+Commands[(string)param[0]].HelpText+"\r\nUsage: "+Commands[(string)param[0]].CommandName;
                    bool optional = false;
                    foreach (IConsoleParameter param2 in com.Parameters) 
                    {
                        help += " ";
                        if (param2.IsOptional && !optional)
                            help += "[";
                        help += param2.Name;
                    }
                    Write(help, "Help");
                }
                else
                {
                    Write("Command \"" + param[0] + "\" not found.", "Help");
                }
            }
        }

        protected static Command helpCommand;

        public static void Initialize(GameObject SystemObject)
        {
            if (!initialized)
            {
                helpCommand = new Command();
                helpCommand.OnSubmit = Help;
                helpCommand.CommandName = "help";
                BaseConsoleParameter param = new BaseConsoleParameter();
                param.Name = "Command";
                param.IsOptional = true;
                param.ListValueRequired = true;
                param.TooltipText = "The command to show help for";
                param.UseAutoComplete = true;
                helpCommand.Parameters.Add(param);
                
                RegisterCommand(helpCommand);

                RegisterCommand(new Command()
                {
                    CommandName = "test",
                    HelpText = "This is a test method",
                    OnSubmit = delegate(object[] objs) { },
                    Parameters = new List<IConsoleParameter>()
                    {
                        new ModAPI.Console.BaseConsoleParameter() 
                        {
                            Name = "Testparam",
                            IsOptional = true,
                            TooltipText = "testtooltip",
                            ListValueRequired = true,
                            UseAutoComplete = true,
                            Values = new List<string>() 
                            {
                                "test1a",
                                "best1",
                                "test2b",
                                "test3b",
                                "best2"
                            }
                        }
                    }
                });
                initialized = true;
            }

            if (SystemObject.transform.FindChild("__ModAPIConsole__") == null)
            {
                GameObject console = new GameObject("__ModAPIConsole__");
                consoleComponent = console.AddComponent<ConsoleComponent>();
                console.transform.parent = SystemObject.transform;
            }
        }

        public class Command
        {
            public string CommandName = "";
            public string HelpText = "";
            public List<IConsoleParameter> Parameters = new List<IConsoleParameter>();
            public delegate void Callback(object[] objects);
            public Callback OnSubmit = null;

            public Command() 
            {

            }

            internal bool IsValid()
            {
                bool optional = false;
                if (CommandName.Trim() == "")
                    return false;
                if (OnSubmit == null)
                    return false;
                foreach (IConsoleParameter param in Parameters)
                {
                    if (param.IsOptional)
                        optional = true;
                    if (!param.IsOptional && optional)
                        return false;
                }
                return true;
            }

            internal bool IsMatch(string command)
            {
                return ((command.Length == CommandName.Length && command.ToLower() == CommandName.ToLower()) || command.ToLower().StartsWith(CommandName.ToLower() + " "));
            }

            internal List<string> GetAutoCompletion(string command)
            {
                List<string> ret = new List<string>();
                string[] param = GetParametersAsString(command);
                int num = param.Length - 1;
                if (command.Substring(command.Length - 1) == " ")
                    num += 1;
                if (num >= 0 && num < Parameters.Count)
                    ret = Parameters[num].GetAllValues().ToArray().ToList();
                
                for (int i = 0; i < ret.Count; i++)
                {
                    string el = ret[i];
                    if (param.Length > num && !el.ToLower().StartsWith(param[num].ToLower()))
                    {
                        ret.RemoveAt(i);
                        i--;
                    }
                }
                
                return ret;
            }

            internal string GetErrorText(string command)
            {
                string ErrorText = "";
                string[] param = GetParametersAsString(command);
                
                for (int i = 0; i < Parameters.Count; i++)
                {
                    if (param.Length <= i && !Parameters[i].IsOptional)
                    {
                        ErrorText += "Required parameter " + (i + 1) + " is missing. ";
                    }
                    if (param.Length > i && !Parameters[i].Verify(param[i]))
                    {
                        ErrorText += "Parameter " + (i + 1) + " is invalid. ";
                    }
                }
                if (param.Length > Parameters.Count)
                    ErrorText += "Too many paramters. Only "+Parameters.Count+" are required. ";
                
                return ErrorText;
            }
            internal bool IsValid(string command)
            {
                string[] param = GetParametersAsString(command);
                if (param.Length > Parameters.Count)
                    return false;
                for (int i = 0; i < Parameters.Count; i++)
                {
                    if (i >= param.Length - 1 && !Parameters[i].IsOptional)
                        return false;
                    if (!Parameters[i].Verify(param[i]))
                        return false;
                }
                return true;
            }
            internal object[] GetParameters(string command)
            {
                string[] param = GetParametersAsString(command);
                if (param.Length > Parameters.Count)
                    return new object[0];
                object[] objs = new object[param.Length];
                for (int i = 0; i < param.Length; i++)
                {
                    objs[i] = this.Parameters[i].ParseValue(param[i]);
                }
                return objs;
            }
            internal string[] GetParametersAsString(string command) 
            {
                command = command.Trim();

                List<string> parameters = new List<string>();
                int index = CommandName.Length;
                bool inBrackets = false;
                int c = 0;
                if (command.Length < index)
                    return new string[0];
                while (c < 100)
                {
                    if (index >= command.Length) break;
                    int whitespaceIndex = command.IndexOf(" ", index);
                    int bracketIndex = command.IndexOf("\"", index);
                    if (bracketIndex != -1 && (bracketIndex < whitespaceIndex || inBrackets))
                    {
                        if (inBrackets) 
                        {
                            string param = command.Substring(index, bracketIndex - index);
                            parameters.Add(param);
                            index = bracketIndex + 2;
                        }
                        else 
                        {
                            index = bracketIndex + 1;
                        }
                        inBrackets = !inBrackets;
                    }
                    else if (whitespaceIndex != -1)
                    {
                        string param = command.Substring(index, whitespaceIndex - index);
                        if (param.Trim() != "")
                        {
                            parameters.Add(param);
                        }
                        index = whitespaceIndex + 1;
                    }
                    else
                    {
                        break;
                    }
                    c++;
                }

                if (command.Length >= index) 
                {
                    string param = command.Substring(index).Trim();
                    if (param != "")
                    {
                        parameters.Add(command.Substring(index).Trim());
                    }
                }

                return parameters.ToArray();
            }
        }

        public interface IConsoleParameter
        {
            bool UseAutoComplete {
                get;
            }
            bool IsOptional {
                get;
            }
            string TooltipText {
                get;
            }
            string Name{
                get;
            }

            bool Verify(string value);
            List<string> GetAllValues();
            object ParseValue(string value);
        }

        public class BaseConsoleParameter : IConsoleParameter
        {
            protected string _TooltipText;
            public string _Name = "";
            public bool _UseAutoComplete = false;
            public bool _IsOptional = false;
            public bool _ListValueRequired = false;
            
            public bool UseAutoComplete {
                get 
                {
                    return _UseAutoComplete;
                }
                set 
                {
                    _UseAutoComplete = value;
                }
            }
            public bool IsOptional {
                get
                {
                    return _IsOptional;
                }
                set
                {
                    _IsOptional = value;
                }
            }
            public bool ListValueRequired
            {
                get 
                {
                    return _ListValueRequired;
                }
                set 
                {
                    _ListValueRequired = value;
                }
            }
            
            public string TooltipText {
                get 
                {
                    return _TooltipText;
                }
                set 
                {
                    _TooltipText = value;
                }
            }
            public string Name 
            {
                get 
                {
                    return _Name;
                }
                set 
                {
                    _Name = value;
                }
            }
            public List<string> Values;

            public bool Verify(string value)
            {
                if (ListValueRequired)
                {
                    foreach (string val in Values)
                    {
                        if (val.ToLower() == value.ToLower())
                            return true;
                    }
                    return false;
                }
                return true;
            }

            public List<string> GetAllValues()
            {
                return Values;
            }

            public object ParseValue(string value)
            {
                return value;
            }
        }
    }
}
