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
using System.Reflection;
using UnityEngine;
using Console = ModAPI.Console;

public class LiveInspector : MonoBehaviour
{
    public GUISkin Skin;
    public float Top = 0f;
    protected static bool CommandsAdded;
    protected static LiveInspector Instance;

    // Use this for initialization
    void Start()
    {
        if (!CommandsAdded)
        {
            Console.RegisterCommand(new Console.Command
            {
                CommandName = "showInspector",
                HelpText = "Shows the scenegraph",
                OnSubmit = Show
            });
            Console.RegisterCommand(new Console.Command
            {
                CommandName = "hideInspector",
                HelpText = "Hides the scenegraph",
                OnSubmit = Hide
            });
            CommandsAdded = true;
        }
        Instance = this;
    }

    public static void Show(object[] param)
    {
        show = true;
    }

    public static void Hide(object[] param)
    {
        show = false;
    }

    public static bool show;
    protected Vector2 ScrollPosition;
    protected Vector2 ScrollPosition2;
    protected int FieldNum;
    protected static GUIStyle WhiteLabelStyle;
    protected static GUIStyle LabelStyle;
    protected static GUIStyle BoldLabelStyle;
    protected static GUIStyle ArrowRightStyle;
    protected static GUIStyle ArrowDownStyle;
    protected static GUIStyle DarkArrowRightStyle;
    protected static GUIStyle DarkArrowDownStyle;

    protected List<Transform> Expanded = new List<Transform>();
    protected Transform[] All;
    protected float NextCheck;
    protected Dictionary<string, Transform> RootElements;

    void Update()
    {
        if (show)
        {
            if (Event.current.control && Input.GetMouseButtonDown(0))
            {
                var r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(r, out hitInfo))
                {
                    SelectedTransform = hitInfo.collider.transform;
                }
            }
        }
    }

    // ReSharper disable once InconsistentNaming
    void OnGUI()
    {
        if (show)
        {
            UnityEngine.GUI.skin = ModAPI.GUI.Skin;
            if (WhiteLabelStyle == null)
            {
                WhiteLabelStyle = UnityEngine.GUI.skin.GetStyle("WhiteLabel");
                LabelStyle = UnityEngine.GUI.skin.label;
                BoldLabelStyle = new GUIStyle(LabelStyle)
                {
                    fontStyle = FontStyle.Bold
                };
                BoldLabelStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
                ArrowRightStyle = UnityEngine.GUI.skin.GetStyle("ArrowRight");
                ArrowDownStyle = UnityEngine.GUI.skin.GetStyle("ArrowDown");
                DarkArrowRightStyle = UnityEngine.GUI.skin.GetStyle("DarkArrowRight");
                DarkArrowDownStyle = UnityEngine.GUI.skin.GetStyle("DarkArrowDown");
            }
            var height = Screen.height - Top;
            UnityEngine.GUI.depth = -1000;

            var createRoot = false;
            if (NextCheck > 0f)
            {
                NextCheck -= Time.deltaTime;
                if (NextCheck <= 0f)
                {
                    All = FindObjectsOfType<Transform>();
                    createRoot = true;
                    NextCheck = 1f;
                }
            }
            if (All == null)
            {
                All = FindObjectsOfType<Transform>();
                createRoot = true;
                NextCheck = 1f;
            }

            var names = new List<string>();
            if (createRoot)
            {
                var k = 0;
                RootElements = new Dictionary<string, Transform>();
                foreach (var t in All)
                {
                    if (t != null)
                    {
                        if ((SearchString == "" && t.parent == null) || (SearchString != "" && t.name.Contains(SearchString)))
                        {
                            RootElements.Add(t.name + k, t);
                            k += 1;
                        }
                    }
                }
            }

            names = RootElements.Keys.ToList();
            names.Sort();

            FieldNum = 0;
            if (SelectedTransform != null)
            {
                UnityEngine.GUI.Box(new Rect(240, Top - 10, 300 + 10, height + 20), "", UnityEngine.GUI.skin.window);
                ScrollPosition2 = UnityEngine.GUI.BeginScrollView(new Rect(250, 0, 300, height), ScrollPosition2, new Rect(0, 0, 10, ListHeight2));
                ListHeight2 = DrawComponents(SelectedTransform);
                UnityEngine.GUI.EndScrollView();
            }

            UnityEngine.GUI.Box(new Rect(-10, Top - 10, 250 + 10, height + 20), "", UnityEngine.GUI.skin.window);
            ScrollPosition = UnityEngine.GUI.BeginScrollView(new Rect(0, 0, 250, height - 30), ScrollPosition, new Rect(0, 0, 10, ListHeight));

            var tt = new List<Transform>();
            foreach (var n in names)
            {
                tt.Add(RootElements[n]);
            }
            ListHeight = DrawList(tt.ToArray(), 0);
            UnityEngine.GUI.EndScrollView();
            SearchString = UnityEngine.GUI.TextField(new Rect(0, height - 30, 250, 30), SearchString);
        }
    }

    protected string SearchString = "";
    protected List<Component> ExpandedComponents = new List<Component>();

    float DrawComponents(Transform t)
    {
        var height = 10f;
        var labelStyle = LabelStyle;
        var arrowRight = DarkArrowRightStyle;
        var arrowDown = DarkArrowDownStyle;
        var components = t.GetComponents<Component>();
        var heightPer = 20f;
        UnityEngine.GUI.TextField(new Rect(20f, height, 230f, 20f), "Name: " + t.gameObject.name);
        height += 20;
        UnityEngine.GUI.Label(new Rect(20f, height, 230f, 20f), "Tag: " + t.gameObject.tag);
        height += 20;
        UnityEngine.GUI.Label(new Rect(20f, height, 230f, 20f), "Layer: " + t.gameObject.layer);
        height += 20;
        for (var i = 0; i < components.Length; i++)
        {
            var y = height;
            var x = 20f;
            var comp = components[i];
            if (ExpandedComponents.Contains(comp))
            {
                if (UnityEngine.GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowDown))
                {
                    ExpandedComponents.Remove(comp);
                }
            }
            else
            {
                if (UnityEngine.GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowRight))
                {
                    ExpandedComponents.Add(comp);
                }
            }
            UnityEngine.GUI.Label(new Rect(20, y, 230f, heightPer), comp.GetType().FullName, labelStyle);
            height += heightPer;
            if (ExpandedComponents.Contains(comp))
            {
                height += DrawComponent(comp, height);
            }
        }
        return height;
    }

    float DrawComponent(Component comp, float startY, Type t = null)
    {
        var height = 0f;
        var arrowRight = DarkArrowRightStyle;
        var arrowDown = DarkArrowDownStyle;

        if (t == null)
        {
            t = comp.GetType();
        }
        var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        for (var i = 0; i < properties.Length; i++)
        {
            try
            {
                var f = properties[i];
                if (f.CanWrite)
                {
                    height += DrawField(f.Name, f.GetValue(comp, new object[] { }), startY + height);
                }
            }
            catch (Exception e)
            {
            }
        }

        var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        for (var i = 0; i < fields.Length; i++)
        {
            try
            {
                var f = fields[i];
                height += DrawField(f.Name, f.GetValue(comp), startY + height);
            }
            catch (Exception e)
            {
            }
        }

        if (t.BaseType != null && t.BaseType.FullName != "UnityEngine.MonoBehaviour")
        {
            height += DrawComponent(comp, startY + height, t.BaseType);
        }
        return height;
    }

    float DrawField(string Name, object value, float startY)
    {
        var height = 40f;
        UnityEngine.GUI.Label(new Rect(20f, startY, 150f, 20f), Name + ":", BoldLabelStyle);
        if (value != null)
        {
            if (value.GetType().FullName == "UnityEngine.GameObject")
            {
                if (UnityEngine.GUI.Button(new Rect(20f, startY + 20f, 270f, 20f), value.ToString(), LabelStyle))
                {
                    SelectedTransform = ((GameObject) value).transform;
                }
            }
            else if (value.GetType().FullName == "UnityEngine.Transform")
            {
                if (UnityEngine.GUI.Button(new Rect(20f, startY + 20f, 270f, 20f), value.ToString(), LabelStyle))
                {
                    SelectedTransform = ((Transform) value);
                }
            }
            else
            {
                UnityEngine.GUI.Label(new Rect(20f, startY + 20f, 270f, 20f), value.ToString(), LabelStyle);
            }
        }
        else
        {
            UnityEngine.GUI.Label(new Rect(20f, startY + 20f, 150f, 20f), "null", LabelStyle);
        }
        return height;
    }

    protected float ListHeight;
    protected float ListHeight2;

    float DrawList(Transform[] all, float startY, int depth = 0)
    {
        var labelStyle = LabelStyle;
        var arrowRight = ArrowRightStyle;
        var arrowDown = ArrowDownStyle;
        var height = 0f;
        var heightPer = 16f;
        foreach (var t in all)
        {
            var x = 20f + depth * 20f;
            var y = startY + height;
            var realY = y - ScrollPosition.y;

            if (t == null)
            {
                UnityEngine.GUI.Label(new Rect(x, y, 250f - x, heightPer), "(removed)", labelStyle);
                height += heightPer;
            }
            else
            {
                if (realY > -heightPer && realY < Screen.height + heightPer)
                {
                    if (SelectedTransform == t)
                    {
                        UnityEngine.GUI.Box(new Rect(-5f, y - 1f, 260f, heightPer + 1f), "");
                    }

                    if (t.childCount > 0)
                    {
                        if (Expanded.Contains(t))
                        {
                            if (UnityEngine.GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowDown))
                            {
                                Expanded.Remove(t);
                            }
                        }
                        else
                        {
                            if (UnityEngine.GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowRight))
                            {
                                Expanded.Add(t);
                            }
                        }
                    }

                    if (UnityEngine.GUI.Button(new Rect(x, y, 250f - x, heightPer), t.name, labelStyle))
                    {
                        SelectedTransform = t;
                        ScrollPosition2 = Vector2.zero;
                    }
                }
                height += heightPer;
                if (Expanded.Contains(t))
                {
                    var sub = new Transform[t.childCount];
                    for (var i = 0; i < sub.Length; i++)
                    {
                        sub[i] = t.GetChild(i);
                    }
                    height += DrawList(sub, startY + height, depth + 1);
                }
            }
        }
        return height;
    }

    protected Transform SelectedTransform;
}
