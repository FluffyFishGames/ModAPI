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
                UP,
                PRESSED,
                NONE
            }

            public string ModID = "";
            public string ID = "";

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
                    return KeyState.PRESSED;
                }
                if (!allPressed && Down)
                {
                    Down = false;
                    return KeyState.UP;
                }
                return KeyState.NONE;
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
                CurrentStates[keyEvent.ModID + "::" + keyEvent.ID] = keyEvent.EventState();
            }
        }

        public static void Initialize(GameObject Parent)
        {
            if (Parent.transform.FindChild("__ModAPIInputManager__") == null)
            {
                var InputManager = new GameObject("__ModAPIInputManager__");
                InputManager.AddComponent<Input>();
                InputManager.transform.parent = Parent.transform;
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
                        newEvent.ModID = mod.ID;
                        newEvent.ID = kv.Key;
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
                        CurrentStates.Add(newEvent.ModID + "::" + newEvent.ID, KeyEvent.KeyState.NONE);
                        Events.Add(newEvent);
                    }
                }
                Initialized = true;
            }
        }

        [AddModname]
        public static string GetKeyBindingAsString(string ButtonName)
        {
            return "";
        }

        [AddModname]
        public static bool GetButton(string ButtonName)
        {
            return false;
        }

        [AddModname]
        public static bool GetButtonDown(string ButtonName)
        {
            return false;
        }

        [AddModname]
        public static bool GetButtonUp(string ButtonName)
        {
            return false;
        }

        protected static string GetKeyBindingAsString(string ButtonName, string ModName)
        {
            if (Mods.LoadedMods[ModName].Buttons.ContainsKey(ButtonName))
            {
                return Mods.LoadedMods[ModName].Buttons[ButtonName];
            }
            return "";
        }

        protected static bool GetButton(string ButtonName, string ModName)
        {
            if (CurrentStates.ContainsKey(ModName + "::" + ButtonName))
            {
                var state = CurrentStates[ModName + "::" + ButtonName];
                return state == KeyEvent.KeyState.DOWN || state == KeyEvent.KeyState.PRESSED;
            }
            return false;
        }

        protected static bool GetButtonDown(string ButtonName, string ModName)
        {
            if (CurrentStates.ContainsKey(ModName + "::" + ButtonName))
            {
                var state = CurrentStates[ModName + "::" + ButtonName];
                return state == KeyEvent.KeyState.DOWN;
            }
            return false;
        }

        protected static bool GetButtonUp(string ButtonName, string ModName)
        {
            if (CurrentStates.ContainsKey(ModName + "::" + ButtonName))
            {
                var state = CurrentStates[ModName + "::" + ButtonName];
                return state == KeyEvent.KeyState.UP;
            }
            return false;
        }
    }
}
