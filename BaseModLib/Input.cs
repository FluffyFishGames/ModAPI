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
using System.IO;
using ModAPI.Attributes;
using UnityEngine;

namespace ModAPI
{
    public class Input : MonoBehaviour
    {
        public static Dictionary<string, KeyCode> KeyMapping = new Dictionary<string, KeyCode>();
        protected static bool Initialized;
        protected static List<KeyCode> WatchList = new List<KeyCode>();
        protected static List<KeyCode> PressedKeys = new List<KeyCode>();
        protected static List<KeyEvent> Events = new List<KeyEvent>();
        protected static Dictionary<string, KeyEvent.KeyState> CurrentStates = new Dictionary<string, KeyEvent.KeyState>();

        protected class KeyEvent
        {
            public List<KeyCode> Keys = new List<KeyCode>();
            protected bool Down;

            public enum KeyState
            {
                DOWN,
                Up,
                Pressed,
                None
            }

            public string ModId = "";
            public string Id = "";

            public KeyState EventState()
            {
                var allPressed = true;
                foreach (var key in Keys)
                {
                    if (!PressedKeys.Contains(key))
                    {
                        allPressed = false;
                    }
                }

                if (allPressed && !Down)
                {
                    Down = true;
                    return KeyState.DOWN;
                }
                if (allPressed && Down)
                {
                    return KeyState.Pressed;
                }
                if (!allPressed && Down)
                {
                    Down = false;
                    return KeyState.Up;
                }
                return KeyState.None;
            }
        }

        void Start()
        {
        }

        void Update()
        {
            foreach (var key in WatchList)
            {
                if (UnityEngine.Input.GetKeyDown(key))
                {
                    PressedKeys.Add(key);
                }
                if (!UnityEngine.Input.GetKey(key) && PressedKeys.Contains(key))
                {
                    PressedKeys.Remove(key);
                }
            }

            foreach (var keyEvent in Events)
            {
                CurrentStates[keyEvent.ModId + "::" + keyEvent.Id] = keyEvent.EventState();
            }
        }

        public static void Initialize(GameObject parent)
        {
            if (parent.transform.FindChild("__ModAPIInputManager__") == null)
            {
                var inputManager = new GameObject("__ModAPIInputManager__");
                inputManager.AddComponent<Input>();
                inputManager.transform.parent = parent.transform;
            }

            if (!Initialized)
            {
                foreach (KeyCode n in Enum.GetValues(typeof(KeyCode)))
                {
                    var key = Enum.GetName(typeof(KeyCode), n);
                    if (!KeyMapping.ContainsKey(key))
                    {
                        KeyMapping.Add(key, n);
                    }
                }

                foreach (var mod in Mods.LoadedMods.Values)
                {
                    foreach (var kv in mod.Buttons)
                    {
                        var newEvent = new KeyEvent();
                        newEvent.ModId = mod.Id;
                        newEvent.Id = kv.Key;
                        var allKeys = kv.Value.Split(new[] { "+" }, StringSplitOptions.None);
                        foreach (var k in allKeys)
                        {
                            if (KeyMapping.ContainsKey(k))
                            {
                                var keyCode = KeyMapping[k];
                                if (!WatchList.Contains(keyCode))
                                {
                                    WatchList.Add(keyCode);
                                }
                                newEvent.Keys.Add(KeyMapping[k]);
                            }
                            else
                            {
                                File.AppendAllText("Test.txt", k);
                            }
                        }
                        CurrentStates.Add(newEvent.ModId + "::" + newEvent.Id, KeyEvent.KeyState.None);
                        Events.Add(newEvent);
                    }
                }
                Initialized = true;
            }
        }

        [AddModname]
        public static string GetKeyBindingAsString(string buttonName)
        {
            return "";
        }

        [AddModname]
        public static bool GetButton(string buttonName)
        {
            return false;
        }

        [AddModname]
        public static bool GetButtonDown(string buttonName)
        {
            return false;
        }

        [AddModname]
        public static bool GetButtonUp(string buttonName)
        {
            return false;
        }

        protected static string GetKeyBindingAsString(string buttonName, string modName)
        {
            if (Mods.LoadedMods[modName].Buttons.ContainsKey(buttonName))
            {
                return Mods.LoadedMods[modName].Buttons[buttonName];
            }
            return "";
        }

        protected static bool GetButton(string buttonName, string modName)
        {
            if (CurrentStates.ContainsKey(modName + "::" + buttonName))
            {
                var state = CurrentStates[modName + "::" + buttonName];
                return state == KeyEvent.KeyState.DOWN || state == KeyEvent.KeyState.Pressed;
            }
            return false;
        }

        protected static bool GetButtonDown(string buttonName, string modName)
        {
            if (CurrentStates.ContainsKey(modName + "::" + buttonName))
            {
                var state = CurrentStates[modName + "::" + buttonName];
                return state == KeyEvent.KeyState.DOWN;
            }
            return false;
        }

        protected static bool GetButtonUp(string buttonName, string modName)
        {
            if (CurrentStates.ContainsKey(modName + "::" + buttonName))
            {
                var state = CurrentStates[modName + "::" + buttonName];
                return state == KeyEvent.KeyState.Up;
            }
            return false;
        }
    }
}
