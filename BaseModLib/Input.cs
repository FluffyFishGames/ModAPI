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
    public class Input : MonoBehaviour
    {
        public static Dictionary<string, KeyCode> KeyMapping = new Dictionary<string, KeyCode>();
        protected static bool Initialized = false;
        protected static List<KeyCode> WatchList = new List<KeyCode>();
        protected static List<KeyCode> PressedKeys = new List<KeyCode>();
        protected static List<KeyEvent> Events = new List<KeyEvent>();
        protected static Dictionary<string, KeyEvent.KeyState> CurrentStates = new Dictionary<string, KeyEvent.KeyState>();

        protected class KeyEvent
        {
            public List<KeyCode> Keys = new List<KeyCode>();
            protected bool Down = false;
            public enum KeyState { DOWN, UP, PRESSED, NONE };
            public string ModID = "";
            public string ID = "";

            public KeyState EventState()
            {
                bool allPressed = true;
                foreach (KeyCode key in Keys)
                {
                    if (!PressedKeys.Contains(key))
                        allPressed = false;
                }

                if (allPressed && !Down)
                {
                    Down = true;
                    return KeyState.DOWN;
                }
                else if (allPressed && Down)
                {
                    return KeyState.PRESSED;
                }
                else if (!allPressed && Down)
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
            foreach (KeyCode key in WatchList)
            {
                if (UnityEngine.Input.GetKeyDown(key))
                    PressedKeys.Add(key);
                if (!UnityEngine.Input.GetKey(key) && PressedKeys.Contains(key))
                    PressedKeys.Remove(key);
            }

            foreach (KeyEvent keyEvent in Events)
            {
                CurrentStates[keyEvent.ModID + "::" + keyEvent.ID] = keyEvent.EventState();
            }
        }

        public static void Initialize(GameObject Parent)
        {
            if (Parent.transform.FindChild("__ModAPIInputManager__") == null)
            {
                GameObject InputManager = new GameObject("__ModAPIInputManager__");
                InputManager.AddComponent<Input>();
                InputManager.transform.parent = Parent.transform;
            }
            
            if (!Initialized)
            {
                foreach (KeyCode n in System.Enum.GetValues(typeof(KeyCode)))
                {
                    string key = System.Enum.GetName(typeof(KeyCode), n);
                    if (!KeyMapping.ContainsKey(key))
                        KeyMapping.Add(key, n);
                }

                foreach (Mod mod in Mods.LoadedMods.Values)
                {
                    foreach (KeyValuePair<string, string> kv in mod.Buttons)
                    {
                        KeyEvent newEvent = new KeyEvent();
                        newEvent.ModID = mod.ID;
                        newEvent.ID = kv.Key;
                        string[] allKeys = kv.Value.Split(new string[] { "+" }, StringSplitOptions.None);
                        foreach (string k in allKeys)
                        {
                            if (KeyMapping.ContainsKey(k))
                            {
                                KeyCode keyCode = KeyMapping[k];
                                if (!WatchList.Contains(keyCode))
                                    WatchList.Add(keyCode);
                                newEvent.Keys.Add(KeyMapping[k]);
                            }
                            else
                                System.IO.File.AppendAllText("Test.txt", k);
                        }
                        CurrentStates.Add(newEvent.ModID + "::" + newEvent.ID, KeyEvent.KeyState.NONE);
                        Events.Add(newEvent);
                    }
                }
                Initialized = true;
            }
        }

        [ModAPI.Attributes.AddModname]
        public static string GetKeyBindingAsString(string ButtonName)
        {
            return "";
        }

        [ModAPI.Attributes.AddModname]
        public static bool GetButton(string ButtonName)
        {
            return false;
        }


        [ModAPI.Attributes.AddModname]
        public static bool GetButtonDown(string ButtonName)
        {
            return false;
        }

        [ModAPI.Attributes.AddModname]
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
                KeyEvent.KeyState state = CurrentStates[ModName + "::" + ButtonName];
                return state == KeyEvent.KeyState.DOWN || state == KeyEvent.KeyState.PRESSED;
            }
            return false;
        }

        protected static bool GetButtonDown(string ButtonName, string ModName)
        {
            if (CurrentStates.ContainsKey(ModName + "::" + ButtonName))
            {
                KeyEvent.KeyState state = CurrentStates[ModName + "::" + ButtonName];
                return state == KeyEvent.KeyState.DOWN;
            }
            return false;
        }

        protected static bool GetButtonUp(string ButtonName, string ModName)
        {
            if (CurrentStates.ContainsKey(ModName + "::" + ButtonName))
            {
                KeyEvent.KeyState state = CurrentStates[ModName + "::" + ButtonName];
                return state == KeyEvent.KeyState.UP;
            }
            return false;
        }
    }
}
