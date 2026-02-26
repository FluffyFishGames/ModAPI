// UnityEngine Stub for ModAPI BaseModLib compilation
// This is NOT a real UnityEngine - just type stubs for build purposes

namespace UnityEngine
{
    public class Object
    {
        public string name { get; set; }
        public static void Destroy(Object obj) { }
        public static void DestroyImmediate(Object obj) { }
        public static void DontDestroyOnLoad(Object target) { }
        public static T FindObjectOfType<T>() where T : Object { return default(T); }
        public static T[] FindObjectsOfType<T>() where T : Object { return new T[0]; }
    }

    public class Component : Object
    {
        public GameObject gameObject { get; set; }
        public Transform transform { get; set; }
        public T GetComponent<T>() where T : Component { return default(T); }
        public T[] GetComponents<T>() where T : Component { return new T[0]; }
        public T GetComponentInChildren<T>() where T : Component { return default(T); }
        public T[] GetComponentsInChildren<T>() where T : Component { return new T[0]; }
    }

    public class Behaviour : Component
    {
        public bool enabled { get; set; }
    }

    public class MonoBehaviour : Behaviour
    {
        public void StartCoroutine(string methodName) { }
        public void StopCoroutine(string methodName) { }
        public void Invoke(string methodName, float time) { }
        public void InvokeRepeating(string methodName, float time, float repeatRate) { }
        public void CancelInvoke() { }
        public T[] FindObjectsOfType<T>() where T : Object { return new T[0]; }
    }

    public class GameObject : Object
    {
        public Transform transform { get; set; }
        public bool activeSelf { get; set; }
        public string tag { get; set; }
        public int layer { get; set; }

        public GameObject() { }
        public GameObject(string name) { }

        public T AddComponent<T>() where T : Component { return default(T); }
        public T GetComponent<T>() where T : Component { return default(T); }
        public T[] GetComponents<T>() where T : Component { return new T[0]; }
        public T GetComponentInChildren<T>() where T : Component { return default(T); }
        public Component AddComponent(System.Type componentType) { return null; }
        public Component GetComponent(System.Type type) { return null; }
        public void SetActive(bool value) { }
        public static GameObject Find(string name) { return null; }
        public static GameObject[] FindGameObjectsWithTag(string tag) { return new GameObject[0]; }
    }

    public class Transform : Component
    {
        public Vector3 position { get; set; }
        public Vector3 localPosition { get; set; }
        public Vector3 localScale { get; set; }
        public Vector3 eulerAngles { get; set; }
        public Vector3 localEulerAngles { get; set; }
        public Quaternion rotation { get; set; }
        public Quaternion localRotation { get; set; }
        public Transform parent { get; set; }
        public int childCount { get; set; }

        public Transform GetChild(int index) { return null; }
        public Transform Find(string name) { return null; }
        public Transform FindChild(string name) { return Find(name); }
        public new T[] GetComponents<T>() where T : Component { return new T[0]; }
        public void SetParent(Transform parent) { }
        public void SetParent(Transform parent, bool worldPositionStays) { }
    }

    public struct Vector2
    {
        public float x, y;
        public Vector2(float x, float y) { this.x = x; this.y = y; }
        public static Vector2 zero { get { return new Vector2(0, 0); } }
        public static Vector2 one { get { return new Vector2(1, 1); } }
    }

    public struct Vector3
    {
        public float x, y, z;
        public Vector3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
        public static Vector3 zero { get { return new Vector3(0, 0, 0); } }
        public static Vector3 one { get { return new Vector3(1, 1, 1); } }
        public static Vector3 up { get { return new Vector3(0, 1, 0); } }
        public static Vector3 forward { get { return new Vector3(0, 0, 1); } }
        public static Vector3 right { get { return new Vector3(1, 0, 0); } }

        public static bool operator ==(Vector3 a, Vector3 b) { return a.x == b.x && a.y == b.y && a.z == b.z; }
        public static bool operator !=(Vector3 a, Vector3 b) { return !(a == b); }
        public override bool Equals(object obj) { if (obj is Vector3 v) return this == v; return false; }
        public override int GetHashCode() { return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode(); }
    }

    public struct Quaternion
    {
        public float x, y, z, w;
        public Quaternion(float x, float y, float z, float w) { this.x = x; this.y = y; this.z = z; this.w = w; }
        public static Quaternion identity { get { return new Quaternion(0, 0, 0, 1); } }

        public static bool operator ==(Quaternion a, Quaternion b) { return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w; }
        public static bool operator !=(Quaternion a, Quaternion b) { return !(a == b); }
        public override bool Equals(object obj) { if (obj is Quaternion q) return this == q; return false; }
        public override int GetHashCode() { return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode() ^ w.GetHashCode(); }
    }

    public struct Color
    {
        public float r, g, b, a;
        public Color(float r, float g, float b) { this.r = r; this.g = g; this.b = b; this.a = 1f; }
        public Color(float r, float g, float b, float a) { this.r = r; this.g = g; this.b = b; this.a = a; }
        public static Color white { get { return new Color(1, 1, 1, 1); } }
        public static Color black { get { return new Color(0, 0, 0, 1); } }
        public static Color gray { get { return new Color(0.5f, 0.5f, 0.5f, 1); } }
        public static Color red { get { return new Color(1, 0, 0, 1); } }
        public static Color green { get { return new Color(0, 1, 0, 1); } }
        public static Color blue { get { return new Color(0, 0, 1, 1); } }
        public static Color yellow { get { return new Color(1, 1, 0, 1); } }
        public static Color clear { get { return new Color(0, 0, 0, 0); } }
    }

    public struct Rect
    {
        public float x, y, width, height;
        public Rect(float x, float y, float width, float height) { this.x = x; this.y = y; this.width = width; this.height = height; }
    }

    public struct Ray
    {
        public Vector3 origin { get; set; }
        public Vector3 direction { get; set; }
        public Ray(Vector3 origin, Vector3 direction) { this.origin = origin; this.direction = direction; }
    }

    public struct RaycastHit
    {
        public Vector3 point { get; set; }
        public Vector3 normal { get; set; }
        public float distance { get; set; }
        public Transform transform { get; set; }
        public Collider collider { get; set; }
        public GameObject gameObject { get { return transform != null ? transform.gameObject : null; } }
    }

    public class Collider : Component { }

    public static class Physics
    {
        public static bool Raycast(Ray ray, out RaycastHit hitInfo) { hitInfo = new RaycastHit(); return false; }
        public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance) { hitInfo = new RaycastHit(); return false; }
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo) { hitInfo = new RaycastHit(); return false; }
        public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance) { return false; }
    }

    public class Texture : Object { }

    public class Texture2D : Texture
    {
        public int width { get; set; }
        public int height { get; set; }

        public Texture2D(int width, int height) { this.width = width; this.height = height; }
        public Texture2D(int width, int height, TextureFormat format, bool mipmap) { this.width = width; this.height = height; }

        public void SetPixel(int x, int y, Color color) { }
        public Color GetPixel(int x, int y) { return Color.black; }
        public void Apply() { }
        public byte[] EncodeToPNG() { return new byte[0]; }
        public void LoadImage(byte[] data) { }
    }

    public class RenderTexture : Texture
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public enum TextureFormat
    {
        Alpha8, ARGB4444, RGB24, RGBA32, ARGB32, RGB565, R16,
        DXT1, DXT5, RGBA4444, BGRA32, RHalf, RGHalf, RGBAHalf,
        RFloat, RGFloat, RGBAFloat, YUY2, BC4, BC5, BC6H, BC7,
        DXT1Crunched, DXT5Crunched, PVRTC_RGB2, PVRTC_RGBA2,
        PVRTC_RGB4, PVRTC_RGBA4, ETC_RGB4, ETC2_RGB, ETC2_RGBA1,
        ETC2_RGBA8, ASTC_RGB_4x4, ASTC_RGB_5x5, ASTC_RGB_6x6
    }

    public class GUIContent
    {
        public string text { get; set; }
        public Texture image { get; set; }

        public GUIContent() { }
        public GUIContent(string text) { this.text = text; }
        public GUIContent(Texture image) { this.image = image; }
        public GUIContent(string text, Texture image) { this.text = text; this.image = image; }

        public static GUIContent none { get { return new GUIContent(); } }
    }

    public class GUIStyle
    {
        public string name { get; set; }
        public Font font { get; set; }
        public int fontSize { get; set; }
        public FontStyle fontStyle { get; set; }
        public TextAnchor alignment { get; set; }
        public bool wordWrap { get; set; }
        public bool richText { get; set; }
        public GUIStyleState normal { get; set; }
        public GUIStyleState hover { get; set; }
        public GUIStyleState active { get; set; }
        public GUIStyleState focused { get; set; }
        public RectOffset padding { get; set; }
        public RectOffset margin { get; set; }
        public RectOffset border { get; set; }
        public RectOffset overflow { get; set; }
        public float fixedWidth { get; set; }
        public float fixedHeight { get; set; }
        public bool stretchWidth { get; set; }
        public bool stretchHeight { get; set; }

        public GUIStyle() { normal = new GUIStyleState(); hover = new GUIStyleState(); active = new GUIStyleState(); focused = new GUIStyleState(); }
        public GUIStyle(GUIStyle other) : this() { }

        public Vector2 CalcSize(GUIContent content) { return Vector2.zero; }
        public float CalcHeight(GUIContent content, float width) { return 0; }
    }

    public class GUIStyleState
    {
        public Color textColor { get; set; }
        public Texture2D background { get; set; }
    }

    public class GUISkin : Object
    {
        public GUIStyle label { get; set; }
        public GUIStyle button { get; set; }
        public GUIStyle box { get; set; }
        public GUIStyle textField { get; set; }
        public GUIStyle textArea { get; set; }
        public GUIStyle toggle { get; set; }
        public GUIStyle window { get; set; }
        public GUIStyle scrollView { get; set; }
        public GUIStyle horizontalScrollbar { get; set; }
        public GUIStyle verticalScrollbar { get; set; }
        public GUIStyle horizontalSlider { get; set; }
        public GUIStyle verticalSlider { get; set; }
        public Font font { get; set; }

        public GUIStyle FindStyle(string styleName) { return null; }
        public GUIStyle GetStyle(string styleName) { return null; }
    }

    public class Font : Object
    {
        public int fontSize { get; set; }
    }

    public enum FontStyle { Normal, Bold, Italic, BoldAndItalic }
    public enum TextAnchor { UpperLeft, UpperCenter, UpperRight, MiddleLeft, MiddleCenter, MiddleRight, LowerLeft, LowerCenter, LowerRight }

    public class RectOffset
    {
        public int left { get; set; }
        public int right { get; set; }
        public int top { get; set; }
        public int bottom { get; set; }
        public RectOffset() { }
        public RectOffset(int left, int right, int top, int bottom) { this.left = left; this.right = right; this.top = top; this.bottom = bottom; }
    }

    public class Camera : Behaviour
    {
        public float pixelWidth { get; set; }
        public float pixelHeight { get; set; }
        public static Camera main { get; set; }
        public static Camera current { get; set; }
        public Ray ScreenPointToRay(Vector3 position) { return new Ray(); }
    }

    public class Event
    {
        public EventType type { get; set; }
        public KeyCode keyCode { get; set; }
        public Vector2 mousePosition { get; set; }
        public bool control { get; set; }
        public bool shift { get; set; }
        public bool alt { get; set; }
        public char character { get; set; }
        public int button { get; set; }

        public static Event current { get; set; }

        public void Use() { }

        static Event() { current = new Event(); }
    }

    public enum EventType
    {
        MouseDown, MouseUp, MouseMove, MouseDrag,
        KeyDown, KeyUp,
        ScrollWheel,
        Repaint, Layout,
        DragUpdated, DragPerform, DragExited,
        Ignore, Used,
        ValidateCommand, ExecuteCommand,
        ContextClick
    }

    public static class GUIUtility
    {
        public static int hotControl { get; set; }
        public static int keyboardControl { get; set; }
        public static object GetStateObject(System.Type t, int controlID) { return System.Activator.CreateInstance(t); }
    }

    public class TextEditor
    {
        public int cursorIndex { get; set; }
        public int selectIndex { get; set; }
        public int pos { get; set; }
        public int selectPos { get; set; }
        public string text { get; set; }
        public void SelectAll() { }
        public void MoveTextEnd() { }
    }

    public static class GUI
    {
        public static GUISkin skin { get; set; }
        public static Color color { get; set; }
        public static Color backgroundColor { get; set; }
        public static Color contentColor { get; set; }
        public static int depth { get; set; }
        public static bool enabled { get; set; }

        public static void DrawTexture(Rect position, Texture image) { }
        public static void Label(Rect position, string text) { }
        public static void Label(Rect position, string text, GUIStyle style) { }
        public static void Label(Rect position, GUIContent content, GUIStyle style) { }
        public static bool Button(Rect position, string text) { return false; }
        public static bool Button(Rect position, string text, GUIStyle style) { return false; }
        public static bool Button(Rect position, GUIContent content, GUIStyle style) { return false; }
        public static void Box(Rect position, string text) { }
        public static void Box(Rect position, string text, GUIStyle style) { }
        public static string TextField(Rect position, string text) { return text; }
        public static string TextField(Rect position, string text, GUIStyle style) { return text; }
        public static string TextField(Rect position, string text, int maxLength, GUIStyle style) { return text; }
        public static string TextArea(Rect position, string text) { return text; }
        public static string TextArea(Rect position, string text, GUIStyle style) { return text; }
        public static bool Toggle(Rect position, bool value, string text) { return value; }
        public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect) { return scrollPosition; }
        public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar) { return scrollPosition; }
        public static void EndScrollView() { }
        public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue) { return value; }
        public static void SetNextControlName(string name) { }
        public static string GetNameOfFocusedControl() { return ""; }
        public static void FocusControl(string name) { }
    }

    public static class GUILayout
    {
        public static void Label(string text, params GUILayoutOption[] options) { }
        public static void Label(string text, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label(GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }
        public static bool Button(string text, params GUILayoutOption[] options) { return false; }
        public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options) { return false; }
        public static string TextField(string text, params GUILayoutOption[] options) { return text; }
        public static string TextField(string text, GUIStyle style, params GUILayoutOption[] options) { return text; }
        public static string TextField(string text, int maxLength, GUIStyle style, params GUILayoutOption[] options) { return text; }
        public static void BeginHorizontal(params GUILayoutOption[] options) { }
        public static void BeginHorizontal(GUIStyle style, params GUILayoutOption[] options) { }
        public static void EndHorizontal() { }
        public static void BeginVertical(params GUILayoutOption[] options) { }
        public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options) { }
        public static void EndVertical() { }
        public static void Space(float pixels) { }
        public static void FlexibleSpace() { }
        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options) { return scrollPosition; }
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options) { return scrollPosition; }
        public static void EndScrollView() { }
        public static Rect BeginArea(Rect screenRect) { return screenRect; }
        public static Rect BeginArea(Rect screenRect, GUIStyle style) { return screenRect; }
        public static void EndArea() { }
        public static GUILayoutOption Width(float width) { return null; }
        public static GUILayoutOption Height(float height) { return null; }
        public static GUILayoutOption MaxWidth(float maxWidth) { return null; }
        public static GUILayoutOption MinWidth(float minWidth) { return null; }
        public static GUILayoutOption MaxHeight(float maxHeight) { return null; }
        public static GUILayoutOption MinHeight(float minHeight) { return null; }
        public static GUILayoutOption ExpandWidth(bool expand) { return null; }
        public static GUILayoutOption ExpandHeight(bool expand) { return null; }
    }

    public class GUILayoutOption { }

    public static class Input
    {
        public static bool GetKey(KeyCode key) { return false; }
        public static bool GetKeyDown(KeyCode key) { return false; }
        public static bool GetKeyUp(KeyCode key) { return false; }
        public static bool GetMouseButton(int button) { return false; }
        public static bool GetMouseButtonDown(int button) { return false; }
        public static bool GetMouseButtonUp(int button) { return false; }
        public static Vector3 mousePosition { get; set; }
        public static string inputString { get; set; }
    }

    public enum KeyCode
    {
        None = 0, Backspace = 8, Tab = 9, Clear = 12, Return = 13,
        Pause = 19, Escape = 27, Space = 32, Delete = 127,
        Alpha0 = 48, Alpha1, Alpha2, Alpha3, Alpha4, Alpha5, Alpha6, Alpha7, Alpha8, Alpha9,
        A = 97, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
        F1 = 282, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,
        UpArrow = 273, DownArrow, RightArrow, LeftArrow,
        Home = 278, End, PageUp, PageDown,
        BackQuote = 96, Backslash = 92,
        LeftShift = 304, RightShift, LeftControl, RightControl, LeftAlt, RightAlt,
        Mouse0 = 323, Mouse1, Mouse2
    }

    public static class Screen
    {
        public static int width { get; set; }
        public static int height { get; set; }
    }

    public static class Application
    {
        public static string dataPath { get; set; }
        public static string persistentDataPath { get; set; }
        public static bool isPlaying { get; set; }
        public static int loadedLevel { get; set; }
        public static void Quit() { }
    }

    public static class Time
    {
        public static float time { get; set; }
        public static float deltaTime { get; set; }
        public static float fixedDeltaTime { get; set; }
        public static float realtimeSinceStartup { get; set; }
        public static int frameCount { get; set; }
    }

    public class WWW : System.IDisposable
    {
        public string url { get; set; }
        public bool isDone { get; set; }
        public string error { get; set; }
        public string text { get; set; }
        public byte[] bytes { get; set; }
        public AssetBundle assetBundle { get; set; }
        public float progress { get; set; }

        public WWW(string url) { this.url = url; this.isDone = true; this.bytes = new byte[0]; this.text = ""; }
        public void Dispose() { }
    }

    public class AssetBundle : Object
    {
        public static AssetBundle LoadFromFile(string path) { return null; }
        public static AssetBundle LoadFromMemory(byte[] binary) { return null; }
        public T LoadAsset<T>(string name) where T : Object { return default(T); }
        public Object LoadAsset(string name) { return null; }
        public Object LoadAsset(string name, System.Type type) { return null; }
        public Object[] LoadAllAssets() { return new Object[0]; }
        public void Unload(bool unloadAllLoadedObjects) { }
    }

    public class Resources
    {
        public static T Load<T>(string path) where T : Object { return default(T); }
        public static Object Load(string path) { return null; }
    }

    public static class Mathf
    {
        public static float Ceil(float f) { return (float)System.Math.Ceiling(f); }
        public static int CeilToInt(float f) { return (int)System.Math.Ceiling(f); }
        public static float Floor(float f) { return (float)System.Math.Floor(f); }
        public static float Round(float f) { return (float)System.Math.Round(f); }
        public static float Min(float a, float b) { return System.Math.Min(a, b); }
        public static float Max(float a, float b) { return System.Math.Max(a, b); }
        public static float Clamp(float value, float min, float max) { return value < min ? min : (value > max ? max : value); }
        public static float Abs(float f) { return System.Math.Abs(f); }
    }

    public static class Debug
    {
        public static void Log(object message) { }
        public static void LogWarning(object message) { }
        public static void LogError(object message) { }
    }
}