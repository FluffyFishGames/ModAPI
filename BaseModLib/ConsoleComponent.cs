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
        public bool opened;
        public bool justOpened;
        protected bool addParam;
        protected bool submit;
        protected List<string> Last = new List<string>();
        protected int LastPosition = -1;

        void OnGUI()
        {
            if (opened)
            {
                if (autoCompletionMax > -1)
                {
                    if (currentAutocompletion == -1)
                    {
                        currentAutocompletion = 0;
                    }
                    if (Event.current.keyCode == KeyCode.DownArrow && Event.current.type == EventType.KeyDown)
                    {
                        currentAutocompletion += 1;
                        if (currentAutocompletion > autoCompletionMax)
                        {
                            currentAutocompletion = 0;
                        }
                        Event.current.Use();
                    }
                    if (Event.current.keyCode == KeyCode.UpArrow && Event.current.type == EventType.KeyDown)
                    {
                        currentAutocompletion -= 1;
                        if (currentAutocompletion < 0)
                        {
                            currentAutocompletion = autoCompletionMax;
                        }
                        Event.current.Use();
                    }
                    if (currentAutocompletion > -1)
                    {
                        if ((Event.current.keyCode == KeyCode.RightArrow || Event.current.keyCode == KeyCode.Space || Event.current.keyCode == KeyCode.Return) &&
                            Event.current.type == EventType.KeyDown)
                        {
                            if (Event.current.keyCode == KeyCode.Return)
                            {
                                submit = true;
                            }
                            addParam = true;
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
                                input = "";
                                LastPosition = 0;
                            }
                            else
                            {
                                input = Last[LastPosition];
                            }
                            Event.current.Use();
                        }
                    }
                    if (Event.current.keyCode == KeyCode.UpArrow && Event.current.type == EventType.KeyDown)
                    {
                        if (LastPosition < Last.Count - 1)
                        {
                            LastPosition++;
                            input = Last[LastPosition];
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
                        submit = true;
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
                input = UnityEngine.GUI.TextField(new Rect(x + 10f, y + height - 40f, width - 20f, 25f), input);
                input = input.Replace("â", "a");
                input = input.Replace("Â", "A");
                input = input.Replace("ô", "o");
                input = input.Replace("Ô", "O");
                input = input.Replace("î", "i");
                input = input.Replace("Î", "I");
                input = input.Replace("û", "u");
                input = input.Replace("Û", "U");
                input = input.Replace("ê", "e");
                input = input.Replace("Ê", "E");

                input = input.Replace("á", "a");
                input = input.Replace("Á", "A");
                input = input.Replace("ó", "o");
                input = input.Replace("Ó", "O");
                input = input.Replace("í", "i");
                input = input.Replace("Í", "I");
                input = input.Replace("ú", "u");
                input = input.Replace("Ú", "U");
                input = input.Replace("é", "e");
                input = input.Replace("É", "E");

                if (input.StartsWith("^"))
                {
                    input = input.Substring(1);
                }
                var spaceIndex = input.IndexOf(" ");
                var editor = (TextEditor) GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                if (spaceIndex > 0 && editor.pos == input.Length && editor.pos == editor.selectPos)
                {
                    var command = input.Substring(0, spaceIndex);
                    var c = Console.GetCommand(command);
                    var possible = Console.GetPossibleValues(input);
                    var lastIndex = input.LastIndexOf(" ");
                    try
                    {
                        if (possible.Count > 1)
                        {
                            var _left = UnityEngine.GUI.skin.textField.CalcSize(new GUIContent(input.Substring(0, lastIndex))).x - 10f;
                            var _right = UnityEngine.GUI.skin.textField.CalcSize(new GUIContent(input + ".")).x - 5f;

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
                            UnityEngine.GUI.Box(new Rect(x + 10f + _left, y + height - 35f - contentHeight, labelWidth + 10f, contentHeight), "");

                            var maxNum = possible.Count;
                            var perPage = (int) (contentHeight / entryHeight);
                            var istartIndex = 0;
                            if (currentAutocompletion > perPage / 2)
                            {
                                istartIndex = currentAutocompletion - perPage / 2;
                            }
                            if (istartIndex > possible.Count - perPage)
                            {
                                istartIndex = possible.Count - perPage;
                            }
                            if (maxNum > perPage)
                            {
                                maxNum = perPage;
                            }
                            autoCompletionMax = possible.Count - 1;
                            for (var i = 0; i < maxNum; i++)
                            {
                                if (istartIndex + i == currentAutocompletion)
                                {
                                    UnityEngine.GUI.Box(new Rect(x + 10f + _left, y + height - 40f - contentHeight + i * entryHeight, labelWidth + 10f, entryHeight), "", GUI.Skin.button);
                                }
                                UnityEngine.GUI.Label(new Rect(x + 10f + _left + 5f, y + height - 40f - contentHeight + i * entryHeight, labelWidth, entryHeight), possible.ElementAt(istartIndex + i));
                            }

                            if (currentAutocompletion > -1)
                            {
                                var _n = possible[currentAutocompletion].Substring(input.Substring(lastIndex + 1).Length);
                                UnityEngine.GUI.Label(new Rect(x + 10f + _right, y + height - 43f + 3f, 200f, 20f), _n);

                                if (addParam)
                                {
                                    var newInput = input.Substring(0, lastIndex) + " ";
                                    if (possible[currentAutocompletion].Contains(" "))
                                    {
                                        newInput += "\"" + possible[currentAutocompletion] + "\" ";
                                    }
                                    else
                                    {
                                        newInput += possible[currentAutocompletion] + " ";
                                    }
                                    input = newInput;
                                    addParam = false;

                                    editor.pos = input.Length;
                                    editor.selectPos = input.Length;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.ToString(), "Core");
                    }
                }

                if (UnityEngine.GUI.GetNameOfFocusedControl() == "Input" && ((submit && !addParam)) && input.Trim() != "")
                {
                    Console.ParseInput(input);
                    Last.Insert(0, input);
                    input = "";
                    LastPosition = -1;
                    submit = false;
                }
                Event.current.mousePosition = new Vector2(0f, 0f);
                if (justOpened)
                {
                    UnityEngine.GUI.FocusControl("Input");
                    justOpened = false;
                }
            }
            if (lastInput != input)
            {
                currentAutocompletion = -1;
                autoCompletionMax = -1;
            }
            lastInput = input;
        }

        protected string lastInput = "";
        protected int currentAutocompletion = -1;
        protected int autoCompletionMax = -1;

        protected string input = "";

        public void Open()
        {
            opened = true;
            justOpened = true;
        }

        public void Close()
        {
            opened = false;
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
