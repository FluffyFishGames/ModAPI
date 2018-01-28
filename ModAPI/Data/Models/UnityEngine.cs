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
using System.Xml.Linq;
using ModAPI.Data.Models;
using ModAPI.Utils;

namespace UnityEngine
{
    public enum HideFlags
    {
        HideAndDontSave
    }

    public class Object
    {
        public string Name;
        public HideFlags HideFlags;
        public bool Active;

        public Object(string name)
        {
            Name = name;
        }

        public Object()
        {
        }
    }

    public class ComponentXmlProvider : Component, IXmlProvider
    {
        public virtual XElement GetXml()
        {
            return XmlParser.GetXml(this);
        }

        public virtual void SetXml(XElement element)
        {
            XmlParser.SetXml(this, element);
        }
    }

    public class BaseUnity : Object
    {
        public object[] Data;

        public BaseUnity()
        {
        }

        public BaseUnity(string name) : base(name)
        {
        }

        public BaseUnity(object[] data)
        {
            Data = data;
        }
    }

    public class Material : BaseUnity
    {
        public Material(object[] data) : base(data)
        {
        }
    }

    public class Texture : BaseUnity
    {
        public Texture(object[] data) : base(data)
        {
        }
    }

    public class Bounds : BaseUnity
    {
        public Bounds(object[] data) : base(data)
        {
        }
    }

    public class ScriptableObject : BaseUnity
    {
        public ScriptableObject()
        {
        }

        public ScriptableObject(object[] data) : base(data)
        {
        }
    }

    public class MeshFilter : BaseUnity
    {
        public MeshFilter(object[] data) : base(data)
        {
        }
    }

    public class Component : BaseUnity
    {
        public byte[] ByteData;
        public object[] ComponentData;

        public Component()
        {
        }

        public Component(object[] data) : base(data)
        {
        }
    }

    public class GameObject : BaseUnity
    {
        public GameObject(string name) : base(name)
        {
        }

        public GameObject(object[] data) : base(data)
        {
        }

        public object GetComponent(Type name)
        {
            return Components[name];
        }

        public object AddComponent(Type name)
        {
            var obj = Activator.CreateInstance(name);
            Components.Add(name, obj);
            return obj;
        }

        public Dictionary<Type, object> Components = new Dictionary<Type, object>();
    }

    public class Font : BaseUnity
    {
        public Font(object[] data) : base(data)
        {
        }
    }

    public class AudioClip : BaseUnity
    {
        public AudioClip(object[] data) : base(data)
        {
        }
    }

    public class TextAsset : BaseUnity
    {
        public TextAsset(object[] data) : base(data)
        {
        }
    }

    public class Mesh : BaseUnity
    {
        public Mesh(object[] data) : base(data)
        {
        }
    }

    public class AnimationClip : BaseUnity
    {
        public AnimationClip(object[] data) : base(data)
        {
        }
    }

    public class Texture2D : BaseUnity
    {
        public Texture2D(object[] data) : base(data)
        {
        }
    }

    public class AnimationState : BaseUnity
    {
        public AnimationState(object[] data) : base(data)
        {
        }
    }

    public class WaitForSeconds : BaseUnity
    {
        public WaitForSeconds(object[] data) : base(data)
        {
        }
    }

    public class BoxCollider : Component
    {
        public BoxCollider(object[] data) : base(data)
        {
        }
    }

    public class Terrain : Component
    {
        public Terrain(object[] data) : base(data)
        {
        }
    }

    public class WheelCollider : Collider
    {
        public WheelCollider(object[] data) : base(data)
        {
        }
    }

    public class MeshCollider : Collider
    {
        public MeshCollider(object[] data) : base(data)
        {
        }
    }

    public class TerrainCollider : Collider
    {
        public TerrainCollider(object[] data) : base(data)
        {
        }
    }

    public class CapsuleCollider : Collider
    {
        public CapsuleCollider(object[] data) : base(data)
        {
        }
    }

    public class SphereCollider : Collider
    {
        public SphereCollider(object[] data) : base(data)
        {
        }
    }

    public class NavMeshAgent : Component
    {
        public NavMeshAgent(object[] data) : base(data)
        {
        }
    }

    public class Camera : Component
    {
        public Camera(object[] data) : base(data)
        {
        }
    }

    public class Rigidbody : Component
    {
        public Rigidbody(object[] data) : base(data)
        {
        }
    }

    public class Renderer : Component
    {
        public Renderer(object[] data) : base(data)
        {
        }
    }

    public class ClothRenderer : Component
    {
        public ClothRenderer(object[] data) : base(data)
        {
        }
    }

    public class LineRenderer : Component
    {
        public LineRenderer(object[] data) : base(data)
        {
        }
    }

    public class TrailRenderer : Component
    {
        public TrailRenderer(object[] data) : base(data)
        {
        }
    }

    public class ParticleRenderer : Component
    {
        public ParticleRenderer(object[] data) : base(data)
        {
        }
    }

    public class SkinnedMeshRenderer : Component
    {
        public SkinnedMeshRenderer(object[] data) : base(data)
        {
        }
    }

    public class MeshRenderer : Component
    {
        public MeshRenderer(object[] data) : base(data)
        {
        }
    }

    public class AudioListener : Component
    {
        public AudioListener(object[] data) : base(data)
        {
        }
    }

    public class ParticleEmitter : Component
    {
        public ParticleEmitter(object[] data) : base(data)
        {
        }
    }

    public class Cloth : Component
    {
        public Cloth(object[] data) : base(data)
        {
        }
    }

    public class Light : Component
    {
        public Light(object[] data) : base(data)
        {
        }
    }

    public class Joint : Component
    {
        public Joint(object[] data) : base(data)
        {
        }
    }

    public class TextMesh : Component
    {
        public TextMesh(object[] data) : base(data)
        {
        }
    }

    public class Collider : Component
    {
        public Collider(object[] data) : base(data)
        {
        }
    }

    public class Color : BaseXmlProvider
    {
        public float R;
        public float G;
        public float B;
        public float A;

        public Color(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public class Vector2 : BaseXmlProvider
    {
        public static Vector2 Zero = new Vector2(0f, 0f);

        public float X;
        public float Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class Vector3 : IXmlProvider
    {
        public static Vector3 Zero = new Vector3(0f, 0f, 0f);

        public float X;
        public float Y;
        public float Z;

        public Vector3()
        {
        }

        public XElement GetXml()
        {
            var root = new XElement("Vector3");
            root.Add(new XElement("X", X));
            root.Add(new XElement("Y", Y));
            root.Add(new XElement("Z", Z));
            root.SetAttributeValue("Type", "UnityEngine.Vector3");
            return root;
        }

        public void SetXml(XElement element)
        {
            X = XmlHelper.GetXmlElementAsFloat(element, "X", X);
            Y = XmlHelper.GetXmlElementAsFloat(element, "Y", Y);
            Z = XmlHelper.GetXmlElementAsFloat(element, "Z", Z);
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Vector3 x, Vector3 y)
        {
            return x.X == y.X && x.Y == y.Y && x.Z == y.Z;
        }

        public static bool operator !=(Vector3 x, Vector3 y)
        {
            return !(x == y);
        }
    }

    public class Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public static Vector4 Zero = new Vector4(0, 0, 0, 0);

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }

    public class Quaternion : IXmlProvider
    {
        public static Quaternion Identity = new Quaternion(0f, 0f, 0f, 1f);
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Quaternion()
        {
        }

        public XElement GetXml()
        {
            var root = new XElement("Quaternion");
            root.Add(new XElement("X", X));
            root.Add(new XElement("Y", Y));
            root.Add(new XElement("Z", Z));
            root.Add(new XElement("W", W));
            root.SetAttributeValue("Type", "UnityEngine.Quaternion");
            return root;
        }

        public void SetXml(XElement element)
        {
            X = XmlHelper.GetXmlElementAsFloat(element, "X", X);
            Y = XmlHelper.GetXmlElementAsFloat(element, "Y", Y);
            Z = XmlHelper.GetXmlElementAsFloat(element, "Z", Z);
            W = XmlHelper.GetXmlElementAsFloat(element, "W", W);
        }

        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static bool operator ==(Quaternion x, Quaternion y)
        {
            return x.X == y.X && x.Y == y.Y && x.Z == y.Z && x.W == y.W;
        }

        public static bool operator !=(Quaternion x, Quaternion y)
        {
            return !(x == y);
        }
    }

    public class Transform : BaseXmlProvider
    {
        public Vector3 LocalPosition;
        public Quaternion LocalRotation;
        public Vector3 LocalScale;
    }
}
