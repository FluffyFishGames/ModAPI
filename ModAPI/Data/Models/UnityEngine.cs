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
using System.Threading.Tasks;
using ModAPI.Data.Models;
using ModAPI.Utils;
using System.Xml.Linq;

namespace UnityEngine
{

    public enum HideFlags
    {
        HideAndDontSave
    }

    public class Object
    {
        public string name;
        public HideFlags hideFlags;
        public bool active;

        public Object(string name)
        {
            this.name = name;
        }

        public Object()
        {

        }
    }

    public class ComponentXMLProvider : Component, ModAPI.Data.Models.IXMLProvider
    {
        public virtual XElement GetXML()
        {
            return ModAPI.Data.Models.XMLParser.GetXML(this);
        }

        public virtual void SetXML(XElement element)
        {
            ModAPI.Data.Models.XMLParser.SetXML(this, element);
        }
    }

    public class BaseUnity : Object
    {
        public object[] data;

        public BaseUnity() : base()
        {

        }

        public BaseUnity(string name) : base(name) { }

        public BaseUnity(object[] data)
        {
            this.data = data;
        }
    }

    public class Material : BaseUnity
    {
        public Material(object[] data) : base(data) { }
    }

    public class Texture : BaseUnity
    {
        public Texture(object[] data) : base(data) { }
    }

    public class Bounds : BaseUnity
    {
        public Bounds(object[] data) : base(data) { }
    }

    public class ScriptableObject : BaseUnity
    {
        public ScriptableObject() : base() { }
        public ScriptableObject(object[] data) : base(data) { }
    }

    public class MeshFilter : BaseUnity
    {
        public MeshFilter(object[] data) : base(data) { }
    }

    public class Component : BaseUnity
    {
        public byte[] byteData;
        public object[] componentData;

        public Component() : base() {}
        public Component(object[] data) : base(data) { }
    }

    public class GameObject : BaseUnity
    {
        public GameObject(string name) : base(name) { }
        public GameObject(object[] data) : base(data) { }

        public object GetComponent(Type name)
        {
            return Components[name];
            
        }

        public object AddComponent(Type name)
        {
            object obj = Activator.CreateInstance(name);
            Components.Add(name, obj);
            return obj;
        }

        public Dictionary<Type, object> Components = new Dictionary<Type,object>();
    }
    public class Font : BaseUnity
    {
        public Font(object[] data) : base(data) { }
    }

    public class AudioClip : BaseUnity
    {
        public AudioClip(object[] data) : base(data) { }
    }

    public class TextAsset : BaseUnity
    {
        public TextAsset(object[] data) : base(data) { }
    }

    public class Mesh : BaseUnity
    {
        public Mesh(object[] data) : base(data) { }
    }

    public class AnimationClip : BaseUnity
    {
        public AnimationClip(object[] data) : base(data) { }
    }

    public class Texture2D : BaseUnity
    {
        public Texture2D(object[] data) : base(data) { }
    }

    public class AnimationState : BaseUnity
    {
        public AnimationState(object[] data) : base(data) { }
    }

    public class WaitForSeconds : BaseUnity
    {
        public WaitForSeconds(object[] data) : base(data) { }
    }

    public class BoxCollider : Component
    {
        public BoxCollider(object[] data) : base(data) { }
    }
    public class Terrain : Component
    {
        public Terrain(object[] data) : base(data) { }
    }
    public class WheelCollider : Collider
    {
        public WheelCollider(object[] data) : base(data) { }
    }
    public class MeshCollider : Collider
    {
        public MeshCollider(object[] data) : base(data) { }
    }
    public class TerrainCollider : Collider
    {
        public TerrainCollider(object[] data) : base(data) { }
    }
    public class CapsuleCollider : Collider
    {
        public CapsuleCollider(object[] data) : base(data) { }
    }
    public class SphereCollider : Collider
    {
        public SphereCollider(object[] data) : base(data) { }
    }
    public class NavMeshAgent : Component
    {
        public NavMeshAgent(object[] data) : base(data) { }
    }
    public class Camera : Component
    {
        public Camera(object[] data) : base(data) { }
    }
    public class Rigidbody : Component
    {
        public Rigidbody(object[] data) : base(data) { }
    }
    public class Renderer : Component
    {
        public Renderer(object[] data) : base(data) { }
    }
    public class ClothRenderer : Component
    {
        public ClothRenderer(object[] data) : base(data) { }
    }
    public class LineRenderer : Component
    {
        public LineRenderer(object[] data) : base(data) { }
    }
    public class TrailRenderer : Component
    {
        public TrailRenderer(object[] data) : base(data) { }
    }
    public class ParticleRenderer : Component
    {
        public ParticleRenderer(object[] data) : base(data) { }
    }
    public class SkinnedMeshRenderer : Component
    {
        public SkinnedMeshRenderer(object[] data) : base(data) { }
    }
    public class MeshRenderer : Component
    {
        public MeshRenderer(object[] data) : base(data) { }
    }

    public class AudioListener : Component
    {
        public AudioListener(object[] data) : base(data) { }
    }

    public class ParticleEmitter : Component
    {
        public ParticleEmitter(object[] data) : base(data) { }
    }

    public class Cloth : Component
    {
        public Cloth(object[] data) : base(data) { }
    }

    public class Light : Component
    {
        public Light(object[] data) : base(data) { }
    }

    public class Joint : Component
    {
        public Joint(object[] data) : base(data) { }
    }

    public class TextMesh : Component
    {
        public TextMesh(object[] data) : base(data) { }
    }
    public class Collider : Component
    {
        public Collider(object[] data) : base(data) { }
    }

    public class Color : BaseXMLProvider
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }

    public class Vector2 : BaseXMLProvider
    {
        public static Vector2 zero = new Vector2(0f, 0f);

        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Vector3 : IXMLProvider
    {
        public static Vector3 zero = new Vector3(0f, 0f, 0f);

        public float x;
        public float y;
        public float z;

        public Vector3() { }
        public XElement GetXML()
        {
            XElement root = new XElement("Vector3");
            root.Add(new XElement("X", this.x));
            root.Add(new XElement("Y", this.y));
            root.Add(new XElement("Z", this.z));
            root.SetAttributeValue("Type", "UnityEngine.Vector3");
            return root;
        }

        public void SetXML(XElement element)
        {
            this.x = XMLHelper.GetXMLElementAsFloat(element, "X", this.x);
            this.y = XMLHelper.GetXMLElementAsFloat(element, "Y", this.y);
            this.z = XMLHelper.GetXMLElementAsFloat(element, "Z", this.z);
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static bool operator ==(Vector3 x, Vector3 y)
        {
            return x.x == y.x && x.y == y.y && x.z == y.z;
        }
        public static bool operator !=(Vector3 x, Vector3 y)
        {
            return !(x == y);
        }
    }

    public class Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public static Vector4 zero = new Vector4(0, 0, 0, 0);
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    public class Quaternion : IXMLProvider
    {
        public static Quaternion identity = new Quaternion(0f, 0f, 0f, 1f);
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion() { }
        public XElement GetXML()
        {
            XElement root = new XElement("Quaternion");
            root.Add(new XElement("X", this.x));
            root.Add(new XElement("Y", this.y));
            root.Add(new XElement("Z", this.z));
            root.Add(new XElement("W", this.w));
            root.SetAttributeValue("Type", "UnityEngine.Quaternion");
            return root;
        }

        public void SetXML(XElement element)
        {
            this.x = XMLHelper.GetXMLElementAsFloat(element, "X", this.x);
            this.y = XMLHelper.GetXMLElementAsFloat(element, "Y", this.y);
            this.z = XMLHelper.GetXMLElementAsFloat(element, "Z", this.z);
            this.w = XMLHelper.GetXMLElementAsFloat(element, "W", this.w);
        }

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static bool operator ==(Quaternion x, Quaternion y)
        {
            return x.x == y.x && x.y == y.y && x.z == y.z && x.w == y.w;
        }
        public static bool operator !=(Quaternion x, Quaternion y)
        {
            return !(x == y);
        }
    }

    public class Transform : BaseXMLProvider
    {
        public Transform() { }
        public Vector3 localPosition;
        public Quaternion localRotation;
        public Vector3 localScale;
    }
}
