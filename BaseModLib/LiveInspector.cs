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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Reflection;
using System.Linq;

public class LiveInspector : MonoBehaviour
{
    public GUISkin Skin;
    public float Top = 0f;
    protected static bool commandsAdded = false;
    protected static LiveInspector Instance;

    // Use this for initialization
    void Start()
    {
        if (!commandsAdded)
        {
            ModAPI.Console.RegisterCommand(new ModAPI.Console.Command()
            {
                CommandName = "showInspector",
                HelpText = "Shows the scenegraph",
                OnSubmit = Show
            });
            ModAPI.Console.RegisterCommand(new ModAPI.Console.Command()
            {
                CommandName = "hideInspector",
                HelpText = "Hides the scenegraph",
                OnSubmit = Hide
            });
            commandsAdded = true;
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

    public static bool show = false;
    protected Vector2 ScrollPosition;
    protected Vector2 ScrollPosition2;
    protected int FieldNum = 0;
    protected static GUIStyle whiteLabelStyle;
    protected static GUIStyle labelStyle;
    protected static GUIStyle boldLabelStyle;
    protected static GUIStyle arrowRightStyle;
    protected static GUIStyle arrowDownStyle;
    protected static GUIStyle darkArrowRightStyle;
    protected static GUIStyle darkArrowDownStyle;

    protected List<Transform> Expanded = new List<Transform>();
    protected Transform[] all;
    protected float nextCheck = 0f;
    protected Dictionary<string, Transform> rootElements;

    void Update()
    {
        if (show)
        {
            if (Event.current.control && Input.GetMouseButtonDown(0))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(r, out hitInfo))
                {
                    selectedTransform = hitInfo.collider.transform;
                }
            }
        }
    }
    void OnGUI()
    {
        if (show)
        {
            GUI.skin = ModAPI.GUI.Skin;
            if (whiteLabelStyle == null)
            {
                whiteLabelStyle = GUI.skin.GetStyle("WhiteLabel");
                labelStyle = GUI.skin.label;
                boldLabelStyle = new GUIStyle(labelStyle);
                boldLabelStyle.fontStyle = FontStyle.Bold;
                boldLabelStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
                arrowRightStyle = GUI.skin.GetStyle("ArrowRight");
                arrowDownStyle = GUI.skin.GetStyle("ArrowDown");
                darkArrowRightStyle = GUI.skin.GetStyle("DarkArrowRight");
                darkArrowDownStyle = GUI.skin.GetStyle("DarkArrowDown");

            }
            float Height = Screen.height - Top;
            GUI.depth = -1000;

            bool createRoot = false;
            if (nextCheck > 0f)
            {
                nextCheck -= Time.deltaTime;
                if (nextCheck <= 0f)
                {
                    all = GameObject.FindObjectsOfType<Transform>();
                    createRoot = true;
                    nextCheck = 1f;
                }
            }
            if (all == null)
            {
                all = GameObject.FindObjectsOfType<Transform>();
                createRoot = true;
                nextCheck = 1f;
            }

            List<string> names = new List<string>();
            if (createRoot)
            {
                int k = 0;
                rootElements = new Dictionary<string, Transform>();
                foreach (Transform t in all)
                {
                    if (t != null)
                    {
                        if ((SearchString == "" && t.parent == null) || (SearchString != "" && t.name.Contains(SearchString)))
                        {
                            rootElements.Add(t.name + k, t);
                            k+=1;
                        }
                    }
                }
            }

            names = rootElements.Keys.ToList();
            names.Sort();

            FieldNum = 0;
            if (selectedTransform != null)
            {
                GUI.Box(new Rect(240, Top - 10, 300 + 10, Height + 20), "", GUI.skin.window);
                ScrollPosition2 = GUI.BeginScrollView(new Rect(250, 0, 300, Height), ScrollPosition2, new Rect(0, 0, 10, listHeight2));
                listHeight2 = DrawComponents(selectedTransform);
                GUI.EndScrollView();
            }

            GUI.Box(new Rect(-10, Top - 10, 250 + 10, Height + 20), "", GUI.skin.window);
            ScrollPosition = GUI.BeginScrollView(new Rect(0, 0, 250, Height - 30), ScrollPosition, new Rect(0, 0, 10, listHeight));

            List<Transform> tt = new List<Transform>();
            foreach (string n in names)
            {
                tt.Add(rootElements[n]);
            }
            listHeight = DrawList(tt.ToArray(), 0);
            GUI.EndScrollView();
            SearchString = GUI.TextField(new Rect(0, Height - 30, 250, 30), SearchString);
        }
    }

    protected string SearchString = "";
    protected List<Component> ExpandedComponents = new List<Component>();

    float DrawComponents(Transform t)
    {
        float height = 10f;
        GUIStyle labelStyle = LiveInspector.labelStyle;
        GUIStyle arrowRight = LiveInspector.darkArrowRightStyle;
        GUIStyle arrowDown = LiveInspector.darkArrowDownStyle;
        Component[] components = t.GetComponents<Component>();
        float heightPer = 20f;
        GUI.TextField(new Rect(20f, height, 230f, 20f), "Name: " + t.gameObject.name);
        height += 20;
        GUI.Label(new Rect(20f, height, 230f, 20f), "Tag: " + t.gameObject.tag);
        height += 20;
        GUI.Label(new Rect(20f, height, 230f, 20f), "Layer: " + t.gameObject.layer);
        height += 20;
        for (int i = 0; i < components.Length; i++)
        {
            float y = height;
            float x = 20f;
            Component comp = components[i];
            if (ExpandedComponents.Contains(comp))
            {
                if (GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowDown))
                    ExpandedComponents.Remove(comp);
            }
            else
            {
                if (GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowRight))
                    ExpandedComponents.Add(comp);
            }
            GUI.Label(new Rect(20, y, 230f, heightPer), comp.GetType().FullName, labelStyle);
            height += heightPer;
            if (ExpandedComponents.Contains(comp))
            {
                height += DrawComponent(comp, height);
            }
        }
        return height;
    }

    float DrawComponent(Component comp, float startY, System.Type t = null)
    {
        float height = 0f;
        GUIStyle arrowRight = LiveInspector.darkArrowRightStyle;
        GUIStyle arrowDown = LiveInspector.darkArrowDownStyle;

        if (t == null) t = comp.GetType();
        PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        for (int i = 0; i < properties.Length; i++)
        {
            try
            {
                PropertyInfo f = properties[i];
                if (f.CanWrite)
                {
                    height += DrawField(f.Name, f.GetValue(comp, new object[] { }), startY + height);
                }
            }
            catch (System.Exception e)
            {

            }
        }

        FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        for (int i = 0; i < fields.Length; i++)
        {
            try
            {
                FieldInfo f = fields[i];
                height += DrawField(f.Name, f.GetValue(comp), startY + height);
            }
            catch (System.Exception e)
            {

            }
        }

        if (t.BaseType != null && t.BaseType.FullName != "UnityEngine.MonoBehaviour")
            height += DrawComponent(comp, startY + height, t.BaseType);
        return height;
    }

    float DrawField(string Name, object value, float startY)
    {
        float height = 40f;
        GUI.Label(new Rect(20f, startY, 150f, 20f), Name + ":", boldLabelStyle);
        if (value != null)
        {
            if (value.GetType().FullName == "UnityEngine.GameObject")
            {
                if (GUI.Button(new Rect(20f, startY + 20f, 270f, 20f), value.ToString(), labelStyle)) 
                {
                    selectedTransform = ((GameObject) value).transform;
                }
            } 
            else if (value.GetType().FullName == "UnityEngine.Transform")
            {
                if (GUI.Button(new Rect(20f, startY + 20f, 270f, 20f), value.ToString(), labelStyle)) 
                {
                    selectedTransform = ((Transform) value);
                }
            }
            else
            {
                GUI.Label(new Rect(20f, startY + 20f, 270f, 20f), value.ToString(), labelStyle);
            }
        }
        else GUI.Label(new Rect(20f, startY + 20f, 150f, 20f), "null", labelStyle);
        return height;
    }

    protected float listHeight = 0f;
    protected float listHeight2 = 0f;

    float DrawList(Transform[] all, float startY, int depth = 0)
    {
        GUIStyle labelStyle = LiveInspector.labelStyle;
        GUIStyle arrowRight = LiveInspector.arrowRightStyle;
        GUIStyle arrowDown = LiveInspector.arrowDownStyle;
        float height = 0f;
        float heightPer = 16f;
        foreach (Transform t in all)
        {
            float x = 20f + depth * 20f;
            float y = startY + height;
            float realY = y - ScrollPosition.y;

            if (t == null)
            {
                GUI.Label(new Rect(x, y, 250f - x, heightPer), "(removed)", labelStyle);
                height += heightPer;
            }
            else
            {
                if (realY > -heightPer && realY < Screen.height + heightPer)
                {
                    if (selectedTransform == t)
                    {
                        GUI.Box(new Rect(-5f, y - 1f, 260f, heightPer + 1f), "");
                    }

                    if (t.childCount > 0)
                    {
                        if (Expanded.Contains(t))
                        {
                            if (GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowDown))
                                Expanded.Remove(t);
                        }
                        else
                        {
                            if (GUI.Button(new Rect(x - 18f, y + 1f, 16f, heightPer), "", arrowRight))
                                Expanded.Add(t);
                        }
                    }

                    if (GUI.Button(new Rect(x, y, 250f - x, heightPer), t.name, labelStyle))
                    {
                        selectedTransform = t;
                        ScrollPosition2 = Vector2.zero;
                    }
                }
                height += heightPer;
                if (Expanded.Contains(t))
                {
                    Transform[] sub = new Transform[t.childCount];
                    for (int i = 0; i < sub.Length; i++)
                        sub[i] = t.GetChild(i);
                    height += DrawList(sub, startY + height, depth + 1);
                }
            }
        }
        return height;
    }

    protected Transform selectedTransform;

 
}
