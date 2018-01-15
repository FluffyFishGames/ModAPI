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
using UnityEngine;

namespace ModAPI
{
    public class ConsoleComponent : MonoBehaviour
    {
        public bool Opened;
        public bool JustOpened;
        protected bool AddParam;
        protected bool Submit;
        protected List<string> Last = new List<string>();
        protected int LastPosition = -1;
        
        // ReSharper disable once InconsistentNaming
        void OnGUI()
        {
            if (Opened)
            {
                if (AutoCompletionMax > -1)
                {
                    if (CurrentAutocompletion == -1)
                    {
                        CurrentAutocompletion = 0;
                    }
                    if (Event.current.keyCode == KeyCode.DownArrow && Event.current.type == EventType.KeyDown)
                    {
                        CurrentAutocompletion += 1;
                        if (CurrentAutocompletion > AutoCompletionMax)
                        {
                            CurrentAutocompletion = 0;
                        }
                        Event.current.Use();
                    }
                    if (Event.current.keyCode == KeyCode.UpArrow && Event.current.type == EventType.KeyDown)
                    {
                        CurrentAutocompletion -= 1;
                        if (CurrentAutocompletion < 0)
                        {
                            CurrentAutocompletion = AutoCompletionMax;
                        }
                        Event.current.Use();
                    }
                    if (CurrentAutocompletion > -1)
                    {
                        if ((Event.current.keyCode == KeyCode.RightArrow || Event.current.keyCode == KeyCode.Space || Event.current.keyCode == KeyCode.Return) &&
                            Event.current.type == EventType.KeyDown)
                        {
                            if (Event.current.keyCode == KeyCode.Return)
                            {
                                Submit = true;
                            }
                            AddParam = true;
                            Event.current.Use();
                            return;
                        }
                    }
                }
                else
                {
                    if (Event.current.keyCode == KeyCode.DownArrow && Event.current.type == EventType.KeyDown)
                    {
                        if (LastPosition > 0)
                        {
                            LastPosition--;
                            if (LastPosition <= 0)
                            {
                                Input = "";
                                LastPosition = 0;
                            }
                            else
                            {
                                Input = Last[LastPosition];
                            }
                            Event.current.Use();
                        }
                    }
                    if (Event.current.keyCode == KeyCode.UpArrow && Event.current.type == EventType.KeyDown)
                    {
                        if (LastPosition < Last.Count - 1)
                        {
                            LastPosition++;
                            Input = Last[LastPosition];
                            Event.current.Use();
                        }
                    }

                    if ((Event.current.keyCode == KeyCode.BackQuote || Event.current.keyCode == KeyCode.Escape || Event.current.keyCode == KeyCode.Backslash) &&
                        Event.current.type == EventType.KeyDown)
                    {
                        Console.Switch();
                    }
                    if (Event.current.keyCode == KeyCode.Return && Event.current.type == EventType.KeyDown)
                    {
                        Submit = true;
                    }
                }

                UnityEngine.GUI.skin = GUI.Skin;
                UnityEngine.GUI.color = new Color(1f, 1f, 1f, 1f);
                UnityEngine.GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
                UnityEngine.GUI.contentColor = new Color(1f, 1f, 1f, 1f);
                UnityEngine.GUI.depth = -100;

                var width = Screen.width / 2f;
                var height = 400f;
                var x = Screen.width - width - 10f;
                var y = Screen.height - height - 10f;
                UnityEngine.GUI.Box(new Rect(x, y, width, height), "Console", UnityEngine.GUI.skin.window);
                var n = Console.Lines.ToList();
                n.Reverse();
                UnityEngine.GUI.enabled = false;
                UnityEngine.GUI.color = new Color(1f, 1f, 1f, 1f);
                UnityEngine.GUI.TextArea(new Rect(x + 10f, y + 40f, width - 20f, height - 85f), string.Join("\r\n", n.ToArray()));
                UnityEngine.GUI.enabled = true;
                UnityEngine.GUI.SetNextControlName("Input");
                Input = UnityEngine.GUI.TextField(new Rect(x + 10f, y + height - 40f, width - 20f, 25f), Input);
                Input = Input.Replace("â", "a");
                Input = Input.Replace("Â", "A");
                Input = Input.Replace("ô", "o");
                Input = Input.Replace("Ô", "O");
                Input = Input.Replace("î", "i");
                Input = Input.Replace("Î", "I");
                Input = Input.Replace("û", "u");
                Input = Input.Replace("Û", "U");
                Input = Input.Replace("ê", "e");
                Input = Input.Replace("Ê", "E");

                Input = Input.Replace("á", "a");
                Input = Input.Replace("Á", "A");
                Input = Input.Replace("ó", "o");
                Input = Input.Replace("Ó", "O");
                Input = Input.Replace("í", "i");
                Input = Input.Replace("Í", "I");
                Input = Input.Replace("ú", "u");
                Input = Input.Replace("Ú", "U");
                Input = Input.Replace("é", "e");
                Input = Input.Replace("É", "E");

                if (Input.StartsWith("^"))
                {
                    Input = Input.Substring(1);
                }
                var spaceIndex = Input.IndexOf(" ");
                var editor = (TextEditor) GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                if (spaceIndex > 0 && editor.pos == Input.Length && editor.pos == editor.selectPos)
                {
                    var command = Input.Substring(0, spaceIndex);
                    var c = Console.GetCommand(command);
                    var possible = Console.GetPossibleValues(Input);
                    var lastIndex = Input.LastIndexOf(" ");
                    try
                    {
                        if (possible.Count > 1)
                        {
                            var left = UnityEngine.GUI.skin.textField.CalcSize(new GUIContent(Input.Substring(0, lastIndex))).x - 10f;
                            var right = UnityEngine.GUI.skin.textField.CalcSize(new GUIContent(Input + ".")).x - 5f;

                            var labelWidth = 0f;
                            foreach (var poss in possible)
                            {
                                var w = UnityEngine.GUI.skin.label.CalcSize(new GUIContent(poss)).x;
                                if (w > labelWidth)
                                {
                                    labelWidth = w;
                                }
                            }
                            var entryHeight = 20f;
                            var maxHeight = 300f;
                            var contentHeight = possible.Count * entryHeight;
                            if (contentHeight > maxHeight)
                            {
                                contentHeight = maxHeight;
                            }
                            UnityEngine.GUI.Box(new Rect(x + 10f + left, y + height - 35f - contentHeight, labelWidth + 10f, contentHeight), "");

                            var maxNum = possible.Count;
                            var perPage = (int) (contentHeight / entryHeight);
                            var istartIndex = 0;
                            if (CurrentAutocompletion > perPage / 2)
                            {
                                istartIndex = CurrentAutocompletion - perPage / 2;
                            }
                            if (istartIndex > possible.Count - perPage)
                            {
                                istartIndex = possible.Count - perPage;
                            }
                            if (maxNum > perPage)
                            {
                                maxNum = perPage;
                            }
                            AutoCompletionMax = possible.Count - 1;
                            for (var i = 0; i < maxNum; i++)
                            {
                                if (istartIndex + i == CurrentAutocompletion)
                                {
                                    UnityEngine.GUI.Box(new Rect(x + 10f + left, y + height - 40f - contentHeight + i * entryHeight, labelWidth + 10f, entryHeight), "", GUI.Skin.button);
                                }
                                UnityEngine.GUI.Label(new Rect(x + 10f + left + 5f, y + height - 40f - contentHeight + i * entryHeight, labelWidth, entryHeight), possible.ElementAt(istartIndex + i));
                            }

                            if (CurrentAutocompletion > -1)
                            {
                                var _n = possible[CurrentAutocompletion].Substring(Input.Substring(lastIndex + 1).Length);
                                UnityEngine.GUI.Label(new Rect(x + 10f + right, y + height - 43f + 3f, 200f, 20f), _n);

                                if (AddParam)
                                {
                                    var newInput = Input.Substring(0, lastIndex) + " ";
                                    if (possible[CurrentAutocompletion].Contains(" "))
                                    {
                                        newInput += "\"" + possible[CurrentAutocompletion] + "\" ";
                                    }
                                    else
                                    {
                                        newInput += possible[CurrentAutocompletion] + " ";
                                    }
                                    Input = newInput;
                                    AddParam = false;

                                    editor.pos = Input.Length;
                                    editor.selectPos = Input.Length;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.ToString(), "Core");
                    }
                }

                if (UnityEngine.GUI.GetNameOfFocusedControl() == "Input" && ((Submit && !AddParam)) && Input.Trim() != "")
                {
                    Console.ParseInput(Input);
                    Last.Insert(0, Input);
                    Input = "";
                    LastPosition = -1;
                    Submit = false;
                }
                Event.current.mousePosition = new Vector2(0f, 0f);
                if (JustOpened)
                {
                    UnityEngine.GUI.FocusControl("Input");
                    JustOpened = false;
                }
            }
            if (LastInput != Input)
            {
                CurrentAutocompletion = -1;
                AutoCompletionMax = -1;
            }
            LastInput = Input;
        }

        protected string LastInput = "";
        protected int CurrentAutocompletion = -1;
        protected int AutoCompletionMax = -1;

        protected string Input = "";

        public void Open()
        {
            Opened = true;
            JustOpened = true;
        }

        public void Close()
        {
            Opened = false;
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.BackQuote) || UnityEngine.Input.GetKeyDown(KeyCode.Backslash))
            {
                Console.Switch();
            }
        }
    }
}
