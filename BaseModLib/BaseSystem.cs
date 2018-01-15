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
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Ionic.Zip;
using UnityEngine;

namespace ModAPI
{
    /// <summary>
    /// BaseSystem should not be used by mods.
    /// </summary>
    public class BaseSystem : MonoBehaviour
    {
        protected static GameObject SystemObject;
        protected static int LastLevelNum = -1;
        internal static string _modsFolder;
        protected static bool Initialized;
        protected static Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();

        protected static List<Execution> ExecuteEveryFrame = new List<Execution>();
        protected static List<Execution> ExecuteEveryFrameInGame = new List<Execution>();
        protected static List<Execution> ExecuteOnApplicationStart = new List<Execution>();
        protected static List<Execution> ExecuteOnGameStart = new List<Execution>();

        protected class Execution
        {
            public MethodInfo Method;
            public string ModId;
        }

        private static Type FindType(string fullName)
        {
            foreach (var m in Mods.Values)
            {
                var t = m.Assembly.GetType(fullName);
                if (t != null)
                {
                    return t;
                }
            }
            return
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.FullName.Equals(fullName));
        }

        private static MethodInfo FindMethod(string path)
        {
            var parts = path.Split(new[] { "::" }, StringSplitOptions.None);
            var parts2 = parts[0].Split(new[] { " " }, StringSplitOptions.None);

            var t = FindType(parts2[1]);
            if (t != null)
            {
                var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                var methodName = parts[1].Replace("()", "");
                foreach (var m in methods)
                {
                    if (m.Name == methodName)
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        public static void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;
                _modsFolder = Path.GetFullPath(Application.dataPath + "/../Mods") + Path.DirectorySeparatorChar;
                try
                {
                    var configuration = XDocument.Load(_modsFolder + "RuntimeConfiguration.xml");
                    foreach (var modConfiguration in configuration.Root.Elements("Mod"))
                    {
                        try
                        {
                            var newMod = new Mod(modConfiguration);
                            if (newMod.Id != "")
                            {
                                Mods.Add(newMod.Id, newMod);
                            }
                            newMod.Assembly = Assembly.Load(new AssemblyName(newMod.Id));
                            ModAPI.Mods.Add(newMod);
                        }
                        catch (Exception e)
                        {
                            var idAttribute = modConfiguration.Attribute("ID");
                            var id = "Core";
                            if (idAttribute != null)
                            {
                                id = idAttribute.Value;
                            }
                            Log.Write("Something went wrong while initializing a mod: " + e, id);
                        }
                    }

                    foreach (var executeEveryFrame in configuration.Root.Elements("ExecuteEveryFrame"))
                    {
                        var m = FindMethod(executeEveryFrame.Value);
                        if (m != null)
                        {
                            var onlyInGame = executeEveryFrame.Attribute("OnlyInGame").Value;
                            if (onlyInGame == "true")
                            {
                                ExecuteEveryFrameInGame.Add(new Execution { Method = m, ModId = executeEveryFrame.Attribute("ModID").Value });
                            }
                            else
                            {
                                ExecuteEveryFrame.Add(new Execution { Method = m, ModId = executeEveryFrame.Attribute("ModID").Value });
                            }
                        }
                        else
                        {
                            Log.Write("Could not find method for execute every frame: " + executeEveryFrame.Value, "Core");
                        }
                    }

                    foreach (var executeOnApplicationStart in configuration.Root.Elements("ExecuteOnApplicationStart"))
                    {
                        var m = FindMethod(executeOnApplicationStart.Value);
                        if (m != null)
                        {
                            ExecuteOnApplicationStart.Add(new Execution { Method = m, ModId = executeOnApplicationStart.Attribute("ModID").Value });
                        }
                        else
                        {
                            Log.Write("Could not find method for execute on application start: " + executeOnApplicationStart.Value, "Core");
                        }
                    }

                    foreach (var executeOnGameStart in configuration.Root.Elements("ExecuteOnGameStart"))
                    {
                        var m = FindMethod(executeOnGameStart.Value);
                        if (m != null)
                        {
                            ExecuteOnGameStart.Add(new Execution { Method = m, ModId = executeOnGameStart.Attribute("ModID").Value });
                        }
                        else
                        {
                            Log.Write("Could not find method for execute on game start: " + executeOnGameStart.Value, "Core");
                        }
                    }

                    var www = new WWW("file://" + _modsFolder + "GUI.assetbundle");
                    while (www.progress < 1)
                    {
                    }
                    Log.Write("Asset bundle ready: " + www.error, "Core");
                    Log.Write("Asset bundle: " + www.assetBundle, "Core");
                    if ((www.error == "" || www.error == null) && www.assetBundle != null)
                    {
                        Log.Write("Asset bundle loaded", "Core");
                        var objs = www.assetBundle.LoadAllAssets();
                        foreach (var o in objs)
                        {
                            Log.Write("Asset bundle: " + o, "Core");
                            if (o is GUISkin)
                            {
                                GUI.Skin = (GUISkin) o;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Write("Something went wrong while initializing: " + e, "Core");
                }
            }
            if (SystemObject == null)
            {
                Log.Write(Application.loadedLevel + "", "Core");
                SystemObject = new GameObject("__ModAPISystem__");
                ;
                Input.Initialize(SystemObject);
                Console.Initialize(SystemObject);
                if (SystemObject.GetComponent<BaseSystem>() == null)
                {
                    SystemObject.AddComponent<BaseSystem>();
                }
                if (SystemObject.GetComponent<LiveInspector>() == null)
                {
                    SystemObject.AddComponent<LiveInspector>();
                }

                if (Application.loadedLevel > 0)
                {
                    Execute(ExecuteOnGameStart);
                }
                else
                {
                    Execute(ExecuteOnApplicationStart);
                }
            }
        }

        private static void Execute(List<Execution> chain)
        {
            foreach (var m in chain)
            {
                try
                {
                    m.Method.Invoke(null, null);
                }
                catch (Exception e)
                {
                    Log.Write("Something went wrong while executing " + m.Method.DeclaringType.FullName + "::" + m.Method.Name + ":" + e, m.ModId);
                }
            }
        }

        protected float Progress;

        void Update()
        {
            try
            {
                if (Loading)
                {
                    var mod = CurrentMod;
                    if (CurrentZipFile != null)
                    {
                        if (CurrentZipFile.Entries.Count <= CurrentEntry)
                        {
                            CurrentEntry = 0;
                            CurrentMod += 1;
                        }
                        else
                        {
                            var entry = CurrentZipFile.Entries.ElementAt(CurrentEntry);
                            if (!entry.IsDirectory)
                            {
                                if (entry.FileName.ToLower().EndsWith(".png") || entry.FileName.ToLower().EndsWith(".jpg") || entry.FileName.ToLower().EndsWith(".jpeg"))
                                {
                                    var m = new MemoryStream();
                                    entry.Extract(m);
                                    m.Position = 0;
                                    var fileBytes = m.ToArray();
                                    var newTexture = new Texture2D(1, 1);
                                    newTexture.LoadImage(fileBytes);
                                    Resources.Add(ToLoad[CurrentMod], entry.FileName.ToLower(), newTexture);
                                }
                            }
                            CurrentEntry += 1;
                        }
                    }
                    if (CurrentZipFile == null || mod != CurrentMod)
                    {
                        if (ToLoad.Count <= CurrentMod)
                        {
                            Loading = false;
                        }
                        else
                        {
                            var modResourceFile = _modsFolder + ToLoad[CurrentMod].Id + ".resources";
                            CurrentZipFile = new ZipFile(modResourceFile);
                        }
                    }
                    var per = mod / (float) ToLoad.Count;
                    Progress = (per * mod + per * (CurrentEntry / (float) CurrentZipFile.Entries.Count)) * 100f;
                }
                else
                {
                    Execute(ExecuteEveryFrame);
                    if (Application.loadedLevel > 0)
                    {
                        Execute(ExecuteEveryFrameInGame);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), "Core");
            }
        }

        protected Texture2D BackgroundTexture;
        protected Texture2D WhiteTexture;
        protected Texture2D BlackTexture;
        protected Texture2D GrayTexture;
        protected bool Loading;
        protected GUIStyle WhiteLabel;
        protected GUIStyle BlackLabel;
        protected List<Mod> ToLoad;
        protected int CurrentMod;
        protected ZipFile CurrentZipFile;
        protected int CurrentEntry;

        void Start()
        {
            BackgroundTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            BackgroundTexture.SetPixel(0, 0, new Color(0.33f, 0.33f, 0.33f, 0.95f));
            BackgroundTexture.Apply();

            WhiteTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
            WhiteTexture.SetPixel(0, 0, new Color(0.93f, 0.93f, 0.93f));
            WhiteTexture.Apply();

            BlackTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
            BlackTexture.SetPixel(0, 0, new Color(0f, 0f, 0f));
            BlackTexture.Apply();

            GrayTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
            GrayTexture.SetPixel(0, 0, new Color(0.6f, 0.6f, 0.6f));
            GrayTexture.Apply();

            WhiteLabel = new GUIStyle(GUI.Skin.label);
            BlackLabel = new GUIStyle(GUI.Skin.label);
            WhiteLabel.fontSize = 20;
            BlackLabel.fontSize = 20;

            WhiteLabel.normal.textColor = new Color(1f, 1f, 1f);
            BlackLabel.normal.textColor = new Color(0f, 0f, 0f);

            ToLoad = new List<Mod>();
            foreach (var mod in ModAPI.Mods.LoadedMods.Values)
            {
                if (mod.HasResources)
                {
                    ToLoad.Add(mod);
                }
            }
            Loading = ToLoad.Count > 0;
        }

        // ReSharper disable once InconsistentNaming
        void OnGUI()
        {
            if (Loading)
            {
                if (Camera.current != null)
                {
                    var cam = Camera.current;
                    UnityEngine.GUI.DrawTexture(new Rect(0, 0, cam.pixelWidth, cam.pixelHeight), BackgroundTexture);

                    var loadingBarWidth = cam.pixelWidth * 0.3f;
                    var loadingBarHeight = 50f;
                    var x = cam.pixelWidth / 2f - loadingBarWidth / 2f;
                    var y = cam.pixelHeight / 2f - loadingBarHeight / 2f;

                    var percentDisplay = new GUIContent(Mathf.Ceil(Progress * 10f) / 10f + "%");
                    var labelSize = WhiteLabel.CalcSize(percentDisplay);

                    UnityEngine.GUI.Label(new Rect(x + loadingBarWidth / 2f - labelSize.x / 2f + 1f, y - labelSize.y - 5f + 1f, labelSize.x + 20f, labelSize.y), percentDisplay, BlackLabel);
                    UnityEngine.GUI.Label(new Rect(x + loadingBarWidth / 2f - labelSize.x / 2f, y - labelSize.y - 5f, labelSize.x + 20f, labelSize.y), percentDisplay, WhiteLabel);

                    var taskDisplay = new GUIContent("Loading resources...");
                    var label2Size = WhiteLabel.CalcSize(taskDisplay);

                    UnityEngine.GUI.Label(new Rect(x + loadingBarWidth / 2f - label2Size.x / 2f + 1f, y + loadingBarHeight + 5f + 1f, label2Size.x + 20f, label2Size.y), taskDisplay, BlackLabel);
                    UnityEngine.GUI.Label(new Rect(x + loadingBarWidth / 2f - label2Size.x / 2f, y + loadingBarHeight + 5f, label2Size.x + 20f, label2Size.y), taskDisplay, WhiteLabel);

                    UnityEngine.GUI.DrawTexture(new Rect(x, y, loadingBarWidth * (Progress / 100f), loadingBarHeight), GrayTexture);

                    UnityEngine.GUI.DrawTexture(new Rect(x, y, loadingBarWidth, 1), WhiteTexture);
                    UnityEngine.GUI.DrawTexture(new Rect(x, y + loadingBarHeight, loadingBarWidth, 1), WhiteTexture);
                    UnityEngine.GUI.DrawTexture(new Rect(x, y, 1, loadingBarHeight), WhiteTexture);
                    UnityEngine.GUI.DrawTexture(new Rect(x + loadingBarWidth, y, 1, loadingBarHeight), WhiteTexture);

                    /*UnityEngine.GUI.DrawTexture(new Rect(x + 1, y + loadingBarHeight + 1, loadingBarWidth, 1), this.blackTexture);
                    UnityEngine.GUI.DrawTexture(new Rect(x + loadingBarWidth + 1, y + 1, 1, loadingBarHeight), this.blackTexture);
                    */
                }
            }
        }
    }
}
