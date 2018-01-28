using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ModAPI.Components.Panels;

namespace ModAPI.Utils
{
    public class Language
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.RegisterAttached("Key", typeof(string), typeof(Language), new PropertyMetadata(default(string), KeyChanged));

        private static void KeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d;
            var found = false;
            var langRoot = "";
            while (!found && (current = GetParent(current)) != null)
            {
                var rootPart = "";
                if (current.GetValue(KeyProperty) != null && current.GetValue(KeyProperty) != "")
                {
                    rootPart = current.GetValue(KeyProperty) as string;
                }
                else if (current is IPanel)
                {
                    try
                    {
                        rootPart = ((IPanel) current).GetLangRoot();
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("LanguageHelper", "It seems like InitializeComponent is called in constructor of \"" + current.GetType().FullName + "\".", Debug.Type.Warning);
                    }
                }
                if (rootPart != "")
                {
                    if (!rootPart.EndsWith("."))
                    {
                        rootPart += ".";
                    }
                    langRoot = rootPart + langRoot;
                }
            }

            if (d is TextBlock)
            {
                (d as TextBlock).SetResourceReference(TextBlock.TextProperty, langRoot + d.GetValue(KeyProperty));
            }
            if (d is Window)
            {
                (d as Window).SetResourceReference(Window.TitleProperty, langRoot + d.GetValue(KeyProperty) + ".Title");
            }
        }

        private static DependencyObject GetParent(DependencyObject o)
        {
            if (o == null)
            {
                return null;
            }
            if (o is ContentElement)
            {
                var parent = ContentOperations.GetParent((ContentElement) o);
                if (parent != null)
                {
                    return parent;
                }

                if (o is FrameworkContentElement)
                {
                    return ((FrameworkContentElement) o).Parent;
                }
            }
            else if (o is FrameworkElement)
            {
                return ((FrameworkElement) o).Parent;
            }
            return VisualTreeHelper.GetParent(o);
        }

        public static void SetKey(UIElement element, string value)
        {
            element.SetValue(KeyProperty, value);
        }

        public static string GetKey(UIElement element)
        {
            return (string) element.GetValue(KeyProperty);
        }
    }
}
