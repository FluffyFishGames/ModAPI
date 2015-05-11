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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModAPI.Components
{
    /// <summary>
    /// Interaktionslogik für Scale9.xaml
    /// </summary>
    public partial class Scale9 : ContentControl
    {

        public static readonly DependencyProperty NormalSourceProperty = DependencyProperty.Register("NormalSource", typeof(BitmapSource), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));
        public static readonly DependencyProperty HoverSourceProperty = DependencyProperty.Register("HoverSource", typeof(BitmapSource), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));
        public static readonly DependencyProperty ActiveSourceProperty = DependencyProperty.Register("ActiveSource", typeof(BitmapSource), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));
        public static readonly DependencyProperty SelectedNormalSourceProperty = DependencyProperty.Register("SelectedNormalSource", typeof(BitmapSource), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));
        public static readonly DependencyProperty SelectedHoverSourceProperty = DependencyProperty.Register("SelectedHoverSource", typeof(BitmapSource), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));
        public static readonly DependencyProperty SelectedActiveSourceProperty = DependencyProperty.Register("SelectedActiveSource", typeof(BitmapSource), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));

        public static readonly DependencyProperty NormalOpacityProperty = DependencyProperty.Register("NormalOpacity", typeof(Double), typeof(Scale9), new PropertyMetadata(1.0, OnPropertyChanged));
        public static readonly DependencyProperty HoverOpacityProperty = DependencyProperty.Register("HoverOpacity", typeof(Double), typeof(Scale9), new PropertyMetadata(0.0, OnPropertyChanged));
        public static readonly DependencyProperty ActiveOpacityProperty = DependencyProperty.Register("ActiveOpacity", typeof(Double), typeof(Scale9), new PropertyMetadata(0.0, OnPropertyChanged));

        public static readonly DependencyProperty InnerPaddingProperty = DependencyProperty.Register("InnerPadding", typeof(Thickness), typeof(Scale9), new PropertyMetadata(new Thickness(), OnPropertyChanged));
        public static readonly DependencyProperty BorderProperty = DependencyProperty.Register("Border", typeof(Thickness), typeof(Scale9), new PropertyMetadata(new Thickness(), OnPropertyChanged));
        public static readonly DependencyProperty BorderSizeProperty = DependencyProperty.Register("BorderSize", typeof(Thickness), typeof(Scale9), new PropertyMetadata(new Thickness(-1,-1,-1,-1), OnPropertyChanged));
        public static readonly DependencyProperty OverflowProperty = DependencyProperty.Register("Overflow", typeof(Thickness), typeof(Scale9), new PropertyMetadata(new Thickness(), OnPropertyChanged));
        public static readonly DependencyProperty ContentOffsetProperty = DependencyProperty.Register("ContentOffset", typeof(Point), typeof(Scale9), new PropertyMetadata(new Point(0, 0), OnPropertyChanged));

        public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register("InnerContent", typeof(object), typeof(Scale9), new PropertyMetadata(null, OnPropertyChanged));
        public static readonly DependencyProperty BlendNormalProperty = DependencyProperty.Register("BlendNormal", typeof(bool), typeof(Scale9), new PropertyMetadata(false, OnPropertyChanged));
        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register("Selected", typeof(bool), typeof(Scale9), new PropertyMetadata(false, OnPropertyChanged));

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(Color), typeof(Scale9), new PropertyMetadata(Colors.Transparent, OnPropertyChanged));
        public static readonly DependencyProperty SelectedTextColorProperty = DependencyProperty.Register("SelectedTextColor", typeof(Color), typeof(Scale9), new PropertyMetadata(Colors.Transparent, OnPropertyChanged));

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Scale9 myControl = (Scale9)sender;
            if ((e.Property.Name == "Selected" || e.Property.Name == "HoverOpacity" || e.Property.Name == "ActiveOpacity") && myControl.BlendNormal)
            {
                if (myControl.BaseNormalOpacity == 0.0) myControl.BaseNormalOpacity = myControl.NormalOpacity;
                double newNormalOpacity = 1.0f;
                if ((!myControl.Selected && myControl.HoverSource != null) || (myControl.Selected && myControl.SelectedHoverSource != null))
                    newNormalOpacity -= myControl.HoverOpacity;
                if ((!myControl.Selected && myControl.ActiveSource != null) || (myControl.Selected && myControl.SelectedActiveSource != null))
                    newNormalOpacity -= myControl.ActiveOpacity;

                myControl.NormalOpacity = myControl.BaseNormalOpacity * newNormalOpacity;
            }
            if (e.Property.Name == "TextColor" || e.Property.Name == "SelectedTextColor" || e.Property.Name == "Selected")
            {
                IEnumerable<TextBlock> et = FindVisualChildren<TextBlock>(sender);
                
                foreach (TextBlock t in et)
                {
                    try
                    {
                        //if (t.Foreground == null || !(t.Foreground is SolidColorBrush))
                        if (myControl.Selected)
                        {
                            if (myControl.SelectedTextColor != Colors.Transparent && myControl.SelectedTextColor != Color.FromArgb(0, 255, 255, 255))
                                t.Foreground = new SolidColorBrush(myControl.SelectedTextColor);
                        }
                        else
                        {
                            if (myControl.TextColor != Colors.Transparent && myControl.TextColor != Color.FromArgb(0, 255, 255, 255))
                                t.Foreground = new SolidColorBrush(myControl.TextColor);
                        }
                        //(t.Foreground as SolidColorBrush).Color = myControl.TextColor;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            if (myControl.TemplateApplied && e.Property.Name == "Selected")
                myControl.Refresh();
        }

        public Rectangle NormalTopLeftRect;
        public Rectangle NormalTopRect;
        public Rectangle NormalTopRightRect;
        public Rectangle NormalLeftRect;
        public Rectangle NormalCenterRect;
        public Rectangle NormalRightRect;
        public Rectangle NormalBottomLeftRect;
        public Rectangle NormalBottomRect;
        public Rectangle NormalBottomRightRect;

        public Rectangle HoverTopLeftRect;
        public Rectangle HoverTopRect;
        public Rectangle HoverTopRightRect;
        public Rectangle HoverLeftRect;
        public Rectangle HoverCenterRect;
        public Rectangle HoverRightRect;
        public Rectangle HoverBottomLeftRect;
        public Rectangle HoverBottomRect;
        public Rectangle HoverBottomRightRect;

        public Rectangle ActiveTopLeftRect;
        public Rectangle ActiveTopRect;
        public Rectangle ActiveTopRightRect;
        public Rectangle ActiveLeftRect;
        public Rectangle ActiveCenterRect;
        public Rectangle ActiveRightRect;
        public Rectangle ActiveBottomLeftRect;
        public Rectangle ActiveBottomRect;
        public Rectangle ActiveBottomRightRect;

        public Rectangle SelectedNormalTopLeftRect;
        public Rectangle SelectedNormalTopRect;
        public Rectangle SelectedNormalTopRightRect;
        public Rectangle SelectedNormalLeftRect;
        public Rectangle SelectedNormalCenterRect;
        public Rectangle SelectedNormalRightRect;
        public Rectangle SelectedNormalBottomLeftRect;
        public Rectangle SelectedNormalBottomRect;
        public Rectangle SelectedNormalBottomRightRect;

        public Rectangle SelectedHoverTopLeftRect;
        public Rectangle SelectedHoverTopRect;
        public Rectangle SelectedHoverTopRightRect;
        public Rectangle SelectedHoverLeftRect;
        public Rectangle SelectedHoverCenterRect;
        public Rectangle SelectedHoverRightRect;
        public Rectangle SelectedHoverBottomLeftRect;
        public Rectangle SelectedHoverBottomRect;
        public Rectangle SelectedHoverBottomRightRect;

        public Rectangle SelectedActiveTopLeftRect;
        public Rectangle SelectedActiveTopRect;
        public Rectangle SelectedActiveTopRightRect;
        public Rectangle SelectedActiveLeftRect;
        public Rectangle SelectedActiveCenterRect;
        public Rectangle SelectedActiveRightRect;
        public Rectangle SelectedActiveBottomLeftRect;
        public Rectangle SelectedActiveBottomRect;
        public Rectangle SelectedActiveBottomRightRect;

        public ImageBrush NormalTopLeft;
        public ImageBrush NormalTop;
        public ImageBrush NormalTopRight;
        public ImageBrush NormalLeft;
        public ImageBrush NormalCenter;
        public ImageBrush NormalRight;
        public ImageBrush NormalBottomLeft;
        public ImageBrush NormalBottom;
        public ImageBrush NormalBottomRight;

        public ImageBrush HoverTopLeft;
        public ImageBrush HoverTop;
        public ImageBrush HoverTopRight;
        public ImageBrush HoverLeft;
        public ImageBrush HoverCenter;
        public ImageBrush HoverRight;
        public ImageBrush HoverBottomLeft;
        public ImageBrush HoverBottom;
        public ImageBrush HoverBottomRight;

        public ImageBrush ActiveTopLeft;
        public ImageBrush ActiveTop;
        public ImageBrush ActiveTopRight;
        public ImageBrush ActiveLeft;
        public ImageBrush ActiveCenter;
        public ImageBrush ActiveRight;
        public ImageBrush ActiveBottomLeft;
        public ImageBrush ActiveBottom;
        public ImageBrush ActiveBottomRight;

        public ImageBrush SelectedNormalTopLeft;
        public ImageBrush SelectedNormalTop;
        public ImageBrush SelectedNormalTopRight;
        public ImageBrush SelectedNormalLeft;
        public ImageBrush SelectedNormalCenter;
        public ImageBrush SelectedNormalRight;
        public ImageBrush SelectedNormalBottomLeft;
        public ImageBrush SelectedNormalBottom;
        public ImageBrush SelectedNormalBottomRight;

        public ImageBrush SelectedHoverTopLeft;
        public ImageBrush SelectedHoverTop;
        public ImageBrush SelectedHoverTopRight;
        public ImageBrush SelectedHoverLeft;
        public ImageBrush SelectedHoverCenter;
        public ImageBrush SelectedHoverRight;
        public ImageBrush SelectedHoverBottomLeft;
        public ImageBrush SelectedHoverBottom;
        public ImageBrush SelectedHoverBottomRight;

        public ImageBrush SelectedActiveTopLeft;
        public ImageBrush SelectedActiveTop;
        public ImageBrush SelectedActiveTopRight;
        public ImageBrush SelectedActiveLeft;
        public ImageBrush SelectedActiveCenter;
        public ImageBrush SelectedActiveRight;
        public ImageBrush SelectedActiveBottomLeft;
        public ImageBrush SelectedActiveBottom;
        public ImageBrush SelectedActiveBottomRight;

        public ColumnDefinition LeftColumn;
        public ColumnDefinition RightColumn;
        public RowDefinition TopRow;
        public RowDefinition BottomRow;

        public Rectangle MouseRect;
        public ContentControl ContentElement;
        public bool TemplateApplied = false;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FindChilds();


            IEnumerable<TextBlock> et = FindVisualChildren<TextBlock>(this);

            foreach (TextBlock t in et)
            {
                try
                {
                    //if (t.Foreground == null || !(t.Foreground is SolidColorBrush))
                    if (Selected)
                    {
                        if (SelectedTextColor != Colors.Transparent && SelectedTextColor != Color.FromArgb(0, 255, 255, 255))
                            t.Foreground = new SolidColorBrush(SelectedTextColor);
                    }
                    else
                    {
                        if (TextColor != Colors.Transparent && TextColor != Color.FromArgb(0, 255, 255, 255))
                        {

                            t.Foreground = new SolidColorBrush(TextColor);
                        }
                    }
                    //(t.Foreground as SolidColorBrush).Color = myControl.TextColor;
                }
                catch (Exception ex)
                {

                }
            }

            Refresh();
            TemplateApplied = true;
        }

        public void FindChilds() {
            
            TopRow = (RowDefinition)GetTemplateChild("TopRow");
            BottomRow = (RowDefinition)GetTemplateChild("BottomRow");
            LeftColumn = (ColumnDefinition)GetTemplateChild("LeftColumn");
            RightColumn = (ColumnDefinition)GetTemplateChild("RightColumn");

            MouseRect = (Rectangle)GetTemplateChild("MouseRect");
            ContentElement = (ContentControl)GetTemplateChild("ContentElement");

            NormalTopLeftRect = (Rectangle) GetTemplateChild("NormalTopLeftRect");
            NormalTopRect = (Rectangle) GetTemplateChild("NormalTopRect");
            NormalTopRightRect = (Rectangle) GetTemplateChild("NormalTopRightRect");
            NormalLeftRect = (Rectangle) GetTemplateChild("NormalLeftRect");
            NormalCenterRect = (Rectangle) GetTemplateChild("NormalCenterRect");
            NormalRightRect = (Rectangle) GetTemplateChild("NormalRightRect");
            NormalBottomLeftRect = (Rectangle) GetTemplateChild("NormalBottomLeftRect");
            NormalBottomRect = (Rectangle) GetTemplateChild("NormalBottomRect");
            NormalBottomRightRect = (Rectangle) GetTemplateChild("NormalBottomRightRect");

            HoverTopLeftRect = (Rectangle) GetTemplateChild("HoverTopLeftRect");
            HoverTopRect = (Rectangle) GetTemplateChild("HoverTopRect");
            HoverTopRightRect = (Rectangle) GetTemplateChild("HoverTopRightRect");
            HoverLeftRect = (Rectangle) GetTemplateChild("HoverLeftRect");
            HoverCenterRect = (Rectangle) GetTemplateChild("HoverCenterRect");
            HoverRightRect = (Rectangle) GetTemplateChild("HoverRightRect");
            HoverBottomLeftRect = (Rectangle) GetTemplateChild("HoverBottomLeftRect");
            HoverBottomRect = (Rectangle) GetTemplateChild("HoverBottomRect");
            HoverBottomRightRect = (Rectangle) GetTemplateChild("HoverBottomRightRect");

            ActiveTopLeftRect = (Rectangle) GetTemplateChild("ActiveTopLeftRect");
            ActiveTopRect = (Rectangle) GetTemplateChild("ActiveTopRect");
            ActiveTopRightRect = (Rectangle) GetTemplateChild("ActiveTopRightRect");
            ActiveLeftRect = (Rectangle) GetTemplateChild("ActiveLeftRect");
            ActiveCenterRect = (Rectangle) GetTemplateChild("ActiveCenterRect");
            ActiveRightRect = (Rectangle) GetTemplateChild("ActiveRightRect");
            ActiveBottomLeftRect = (Rectangle) GetTemplateChild("ActiveBottomLeftRect");
            ActiveBottomRect = (Rectangle) GetTemplateChild("ActiveBottomRect");
            ActiveBottomRightRect = (Rectangle) GetTemplateChild("ActiveBottomRightRect");

            SelectedNormalTopLeftRect = (Rectangle) GetTemplateChild("SelectedNormalTopLeftRect");
            SelectedNormalTopRect = (Rectangle) GetTemplateChild("SelectedNormalTopRect");
            SelectedNormalTopRightRect = (Rectangle) GetTemplateChild("SelectedNormalTopRightRect");
            SelectedNormalLeftRect = (Rectangle) GetTemplateChild("SelectedNormalLeftRect");
            SelectedNormalCenterRect = (Rectangle) GetTemplateChild("SelectedNormalCenterRect");
            SelectedNormalRightRect = (Rectangle) GetTemplateChild("SelectedNormalRightRect");
            SelectedNormalBottomLeftRect = (Rectangle) GetTemplateChild("SelectedNormalBottomLeftRect");
            SelectedNormalBottomRect = (Rectangle) GetTemplateChild("SelectedNormalBottomRect");
            SelectedNormalBottomRightRect = (Rectangle) GetTemplateChild("SelectedNormalBottomRightRect");

            SelectedHoverTopLeftRect = (Rectangle) GetTemplateChild("SelectedHoverTopLeftRect");
            SelectedHoverTopRect = (Rectangle) GetTemplateChild("SelectedHoverTopRect");
            SelectedHoverTopRightRect = (Rectangle) GetTemplateChild("SelectedHoverTopRightRect");
            SelectedHoverLeftRect = (Rectangle) GetTemplateChild("SelectedHoverLeftRect");
            SelectedHoverCenterRect = (Rectangle) GetTemplateChild("SelectedHoverCenterRect");
            SelectedHoverRightRect = (Rectangle) GetTemplateChild("SelectedHoverRightRect");
            SelectedHoverBottomLeftRect = (Rectangle) GetTemplateChild("SelectedHoverBottomLeftRect");
            SelectedHoverBottomRect = (Rectangle) GetTemplateChild("SelectedHoverBottomRect");
            SelectedHoverBottomRightRect = (Rectangle) GetTemplateChild("SelectedHoverBottomRightRect");

            SelectedActiveTopLeftRect = (Rectangle) GetTemplateChild("SelectedActiveTopLeftRect");
            SelectedActiveTopRect = (Rectangle) GetTemplateChild("SelectedActiveTopRect");
            SelectedActiveTopRightRect = (Rectangle) GetTemplateChild("SelectedActiveTopRightRect");
            SelectedActiveLeftRect = (Rectangle) GetTemplateChild("SelectedActiveLeftRect");
            SelectedActiveCenterRect = (Rectangle) GetTemplateChild("SelectedActiveCenterRect");
            SelectedActiveRightRect = (Rectangle) GetTemplateChild("SelectedActiveRightRect");
            SelectedActiveBottomLeftRect = (Rectangle) GetTemplateChild("SelectedActiveBottomLeftRect");
            SelectedActiveBottomRect = (Rectangle) GetTemplateChild("SelectedActiveBottomRect");
            SelectedActiveBottomRightRect = (Rectangle) GetTemplateChild("SelectedActiveBottomRightRect");

            NormalTopLeft = (ImageBrush) GetTemplateChild("NormalTopLeft");
            NormalTop = (ImageBrush) GetTemplateChild("NormalTop");
            NormalTopRight = (ImageBrush) GetTemplateChild("NormalTopRight");
            NormalLeft = (ImageBrush) GetTemplateChild("NormalLeft");
            NormalCenter = (ImageBrush) GetTemplateChild("NormalCenter");
            NormalRight = (ImageBrush) GetTemplateChild("NormalRight");
            NormalBottomLeft = (ImageBrush) GetTemplateChild("NormalBottomLeft");
            NormalBottom = (ImageBrush) GetTemplateChild("NormalBottom");
            NormalBottomRight = (ImageBrush) GetTemplateChild("NormalBottomRight");

            HoverTopLeft = (ImageBrush) GetTemplateChild("HoverTopLeft");
            HoverTop = (ImageBrush) GetTemplateChild("HoverTop");
            HoverTopRight = (ImageBrush) GetTemplateChild("HoverTopRight");
            HoverLeft = (ImageBrush) GetTemplateChild("HoverLeft");
            HoverCenter = (ImageBrush) GetTemplateChild("HoverCenter");
            HoverRight = (ImageBrush) GetTemplateChild("HoverRight");
            HoverBottomLeft = (ImageBrush) GetTemplateChild("HoverBottomLeft");
            HoverBottom = (ImageBrush) GetTemplateChild("HoverBottom");
            HoverBottomRight = (ImageBrush) GetTemplateChild("HoverBottomRight");

            ActiveTopLeft = (ImageBrush) GetTemplateChild("ActiveTopLeft");
            ActiveTop = (ImageBrush) GetTemplateChild("ActiveTop");
            ActiveTopRight = (ImageBrush) GetTemplateChild("ActiveTopRight");
            ActiveLeft = (ImageBrush) GetTemplateChild("ActiveLeft");
            ActiveCenter = (ImageBrush) GetTemplateChild("ActiveCenter");
            ActiveRight = (ImageBrush) GetTemplateChild("ActiveRight");
            ActiveBottomLeft = (ImageBrush) GetTemplateChild("ActiveBottomLeft");
            ActiveBottom = (ImageBrush) GetTemplateChild("ActiveBottom");
            ActiveBottomRight = (ImageBrush) GetTemplateChild("ActiveBottomRight");

            SelectedNormalTopLeft = (ImageBrush) GetTemplateChild("SelectedNormalTopLeft");
            SelectedNormalTop = (ImageBrush) GetTemplateChild("SelectedNormalTop");
            SelectedNormalTopRight = (ImageBrush) GetTemplateChild("SelectedNormalTopRight");
            SelectedNormalLeft = (ImageBrush) GetTemplateChild("SelectedNormalLeft");
            SelectedNormalCenter = (ImageBrush) GetTemplateChild("SelectedNormalCenter");
            SelectedNormalRight = (ImageBrush) GetTemplateChild("SelectedNormalRight");
            SelectedNormalBottomLeft = (ImageBrush) GetTemplateChild("SelectedNormalBottomLeft");
            SelectedNormalBottom = (ImageBrush) GetTemplateChild("SelectedNormalBottom");
            SelectedNormalBottomRight = (ImageBrush) GetTemplateChild("SelectedNormalBottomRight");

            SelectedHoverTopLeft = (ImageBrush) GetTemplateChild("SelectedHoverTopLeft");
            SelectedHoverTop = (ImageBrush) GetTemplateChild("SelectedHoverTop");
            SelectedHoverTopRight = (ImageBrush) GetTemplateChild("SelectedHoverTopRight");
            SelectedHoverLeft = (ImageBrush) GetTemplateChild("SelectedHoverLeft");
            SelectedHoverCenter = (ImageBrush) GetTemplateChild("SelectedHoverCenter");
            SelectedHoverRight = (ImageBrush) GetTemplateChild("SelectedHoverRight");
            SelectedHoverBottomLeft = (ImageBrush) GetTemplateChild("SelectedHoverBottomLeft");
            SelectedHoverBottom = (ImageBrush) GetTemplateChild("SelectedHoverBottom");
            SelectedHoverBottomRight = (ImageBrush) GetTemplateChild("SelectedHoverBottomRight");

            SelectedActiveTopLeft = (ImageBrush) GetTemplateChild("SelectedActiveTopLeft");
            SelectedActiveTop = (ImageBrush) GetTemplateChild("SelectedActiveTop");
            SelectedActiveTopRight = (ImageBrush) GetTemplateChild("SelectedActiveTopRight");
            SelectedActiveLeft = (ImageBrush) GetTemplateChild("SelectedActiveLeft");
            SelectedActiveCenter = (ImageBrush) GetTemplateChild("SelectedActiveCenter");
            SelectedActiveRight = (ImageBrush) GetTemplateChild("SelectedActiveRight");
            SelectedActiveBottomLeft = (ImageBrush) GetTemplateChild("SelectedActiveBottomLeft");
            SelectedActiveBottom = (ImageBrush) GetTemplateChild("SelectedActiveBottom");
            SelectedActiveBottomRight = (ImageBrush) GetTemplateChild("SelectedActiveBottomRight");
        }

        public double BaseNormalOpacity = 0f;

        public Double NormalOpacity
        {
            get { return (Double)base.GetValue(NormalOpacityProperty); }
            set { base.SetValue(NormalOpacityProperty, value); }
        }

        public Double HoverOpacity
        {
            get { return (Double)base.GetValue(HoverOpacityProperty); }
            set
            {
                base.SetValue(HoverOpacityProperty, value);
            }
        }


        public Color TextColor
        {
            get { return (Color)base.GetValue(TextColorProperty); }
            set
            {
                base.SetValue(TextColorProperty, value);
            }
        }

        public Color SelectedTextColor
        {
            get { return (Color)base.GetValue(SelectedTextColorProperty); }
            set
            {
                base.SetValue(SelectedTextColorProperty, value);
            }
        }

        public bool BlendNormal
        {
            get { return (bool)base.GetValue(BlendNormalProperty); }
            set { base.SetValue(BlendNormalProperty, value); }
        }

        public bool Selected
        {
            get { return (bool)base.GetValue(SelectedProperty); }
            set { base.SetValue(SelectedProperty, value); }
        }

        public Double ActiveOpacity
        {
            get { return (Double)base.GetValue(ActiveOpacityProperty); }
            set
            {
                base.SetValue(ActiveOpacityProperty, value);
            }
        }


        public object InnerContent
        {
            get { return base.GetValue(InnerContentProperty) as object; }
            set { base.SetValue(InnerContentProperty, value); }
        }


        public BitmapSource NormalSource
        {
            get { return base.GetValue(NormalSourceProperty) as BitmapSource; }
            set { base.SetValue(NormalSourceProperty, value); }
        }

        public BitmapSource HoverSource
        {
            get { return base.GetValue(HoverSourceProperty) as BitmapSource; }
            set { base.SetValue(HoverSourceProperty, value); }
        }

        public BitmapSource ActiveSource
        {
            get { return base.GetValue(ActiveSourceProperty) as BitmapSource; }
            set { base.SetValue(ActiveSourceProperty, value); }
        }

        public BitmapSource SelectedNormalSource
        {
            get { return base.GetValue(SelectedNormalSourceProperty) as BitmapSource; }
            set { base.SetValue(SelectedNormalSourceProperty, value); }
        }

        public BitmapSource SelectedHoverSource
        {
            get { return base.GetValue(SelectedHoverSourceProperty) as BitmapSource; }
            set { base.SetValue(SelectedHoverSourceProperty, value); }
        }

        public BitmapSource SelectedActiveSource
        {
            get { return base.GetValue(SelectedActiveSourceProperty) as BitmapSource; }
            set { base.SetValue(SelectedActiveSourceProperty, value); }
        }

        public Point ContentOffset
        {
            get { return (Point)base.GetValue(ContentOffsetProperty); }
            set { base.SetValue(ContentOffsetProperty, value); }
        }

        public Thickness Border
        {
            get { return (Thickness)base.GetValue(BorderProperty); }
            set { base.SetValue(BorderProperty, value); }
        }

        public Thickness BorderSize
        {
            get { return (Thickness)base.GetValue(BorderSizeProperty); }
            set { base.SetValue(BorderSizeProperty, value); }
        }

        public Thickness InnerPadding
        {
            get { return (Thickness)base.GetValue(InnerPaddingProperty); }
            set { base.SetValue(InnerPaddingProperty, value); }
        }

        public Thickness Overflow
        {
            get { return (Thickness)base.GetValue(OverflowProperty); }
            set { base.SetValue(OverflowProperty, value); }
        }

        /*static Scale9()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Scale9), new FrameworkPropertyMetadata(typeof(Scale9)));
        }*/

        /*protected ColumnDefinition LeftColumn;
        protected ColumnDefinition CenterColumn;
        protected ColumnDefinition RightColumn;
        protected RowDefinition TopRow;
        protected RowDefinition CenterRow;
        protected RowDefinition BottomRow;
        protected ImageBrush TopLeft;
        protected ImageBrush Top;
        protected ImageBrush TopRight;
        protected ImageBrush Left;
        protected ImageBrush Center;
        protected ImageBrush Right;
        protected ImageBrush BottomLeft;
        protected ImageBrush Bottom;
        protected ImageBrush BottomRight;
        protected Rectangle TopLeftRect;
        protected Rectangle TopRect;
        protected Rectangle TopRightRect;
        protected Rectangle LeftRect;
        protected Rectangle CenterRect;
        protected Rectangle RightRect;
        protected Rectangle BottomLeftRect;
        protected Rectangle BottomRect;
        protected Rectangle BottomRightRect;*/

        public Scale9()
        {
            //AddVisualChild(grid);
        }

        public void Refresh()
        {
            if (MouseRect == null) return;
            this.Margin = new Thickness(-Overflow.Left, -Overflow.Top, -Overflow.Right, -Overflow.Bottom);
            this.MouseRect.Margin = Overflow;

            double BorderTop = BorderSize.Top;
            if (BorderTop < 0) BorderTop = Border.Top;
            if (BorderTop < 0) BorderTop = 0; 
            
            double BorderLeft = BorderSize.Left;
            if (BorderLeft < 0) BorderLeft = Border.Left;
            if (BorderLeft < 0) BorderLeft = 0;
            
            double BorderRight = BorderSize.Right;
            if (BorderRight < 0) BorderRight = Border.Right;
            if (BorderRight < 0) BorderRight = 0;
            
            double BorderBottom = BorderSize.Bottom;
            if (BorderBottom < 0) BorderBottom = Border.Bottom;
            if (BorderBottom < 0) BorderBottom = 0;

            TopRow.Height = new GridLength(BorderTop);
            //CenterRow.Height = new GridLength(0, GridUnitType.Auto);
            BottomRow.Height = new GridLength(BorderBottom);

            LeftColumn.Width = new GridLength(BorderLeft);
            //CenterColumn.Width = new GridLength(0, GridUnitType.Auto);
            RightColumn.Width = new GridLength(BorderRight);

            ContentElement.Margin = new Thickness(ContentOffset.X, ContentOffset.Y, 0, 0);

            System.Windows.Visibility visibility = System.Windows.Visibility.Hidden;

            visibility = NormalSource == null || Selected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            NormalTopLeftRect.Visibility = BorderLeft > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            NormalTopRect.Visibility = BorderTop > 0 ? visibility : Visibility.Collapsed;
            NormalTopRightRect.Visibility = BorderRight > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            NormalLeftRect.Visibility = BorderLeft > 0 ? visibility : Visibility.Collapsed;
            NormalCenterRect.Visibility = visibility;
            NormalRightRect.Visibility = BorderRight > 0 ? visibility : Visibility.Collapsed;
            NormalBottomLeftRect.Visibility = BorderLeft > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;
            NormalBottomRect.Visibility = BorderBottom > 0 ? visibility : Visibility.Collapsed;
            NormalBottomRightRect.Visibility = BorderRight > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;

            visibility = HoverSource == null || Selected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            HoverTopLeftRect.Visibility = BorderLeft > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            HoverTopRect.Visibility = BorderTop > 0 ? visibility : Visibility.Collapsed;
            HoverTopRightRect.Visibility = BorderRight > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            HoverLeftRect.Visibility = BorderLeft > 0 ? visibility : Visibility.Collapsed;
            HoverCenterRect.Visibility = visibility;
            HoverRightRect.Visibility = BorderRight > 0 ? visibility : Visibility.Collapsed;
            HoverBottomLeftRect.Visibility = BorderLeft > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;
            HoverBottomRect.Visibility = BorderBottom > 0 ? visibility : Visibility.Collapsed;
            HoverBottomRightRect.Visibility = BorderRight > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;

            visibility = ActiveSource == null || Selected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            ActiveTopLeftRect.Visibility = BorderLeft > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            ActiveTopRect.Visibility = BorderTop > 0 ? visibility : Visibility.Collapsed;
            ActiveTopRightRect.Visibility = BorderRight > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            ActiveLeftRect.Visibility = BorderLeft > 0 ? visibility : Visibility.Collapsed;
            ActiveCenterRect.Visibility = visibility;
            ActiveRightRect.Visibility = BorderRight > 0 ? visibility : Visibility.Collapsed;
            ActiveBottomLeftRect.Visibility = BorderLeft > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;
            ActiveBottomRect.Visibility = BorderBottom > 0 ? visibility : Visibility.Collapsed;
            ActiveBottomRightRect.Visibility = BorderRight > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;

            visibility = SelectedNormalSource == null || !Selected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            SelectedNormalTopLeftRect.Visibility = BorderLeft > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalTopRect.Visibility = BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalTopRightRect.Visibility = BorderRight > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalLeftRect.Visibility = BorderLeft > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalCenterRect.Visibility = visibility;
            SelectedNormalRightRect.Visibility = BorderRight > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalBottomLeftRect.Visibility = BorderLeft > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalBottomRect.Visibility = BorderBottom > 0 ? visibility : Visibility.Collapsed;
            SelectedNormalBottomRightRect.Visibility = BorderRight > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;

            visibility = SelectedActiveSource == null || !Selected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            SelectedActiveTopLeftRect.Visibility = BorderLeft > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveTopRect.Visibility = BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveTopRightRect.Visibility = BorderRight > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveLeftRect.Visibility = BorderLeft > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveCenterRect.Visibility = visibility;
            SelectedActiveRightRect.Visibility = BorderRight > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveBottomLeftRect.Visibility = BorderLeft > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveBottomRect.Visibility = BorderBottom > 0 ? visibility : Visibility.Collapsed;
            SelectedActiveBottomRightRect.Visibility = BorderRight > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;

            visibility = SelectedHoverSource == null || !Selected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            SelectedHoverTopLeftRect.Visibility = BorderLeft > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverTopRect.Visibility = BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverTopRightRect.Visibility = BorderRight > 0 && BorderTop > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverLeftRect.Visibility = BorderLeft > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverCenterRect.Visibility = visibility;
            SelectedHoverRightRect.Visibility = BorderRight > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverBottomLeftRect.Visibility = BorderLeft > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverBottomRect.Visibility = BorderBottom > 0 ? visibility : Visibility.Collapsed;
            SelectedHoverBottomRightRect.Visibility = BorderRight > 0 && BorderBottom > 0 ? visibility : Visibility.Collapsed;

            if (NormalSource != null)
            {
                NormalTopLeft.Viewbox = new Rect(0, 0, Border.Left, Border.Top);
                NormalTop.Viewbox = new Rect(Border.Left, 0, NormalSource.Width - Border.Left - Border.Right, Border.Top);
                NormalTopRight.Viewbox = new Rect(NormalSource.Width - Border.Right, 0, Border.Right, Border.Top);
                NormalLeft.Viewbox = new Rect(0, Border.Top, Border.Left, NormalSource.Height - Border.Top - Border.Bottom);
                NormalCenter.Viewbox = new Rect(Border.Left, Border.Top, NormalSource.Width - Border.Left - Border.Right, NormalSource.Height - Border.Top - Border.Bottom);
                NormalRight.Viewbox = new Rect(NormalSource.Width - Border.Right, Border.Top, Border.Right, NormalSource.Height - Border.Top - Border.Bottom);
                NormalBottomLeft.Viewbox = new Rect(0, NormalSource.Height - Border.Bottom, Border.Left, Border.Bottom);
                NormalBottom.Viewbox = new Rect(Border.Left, NormalSource.Height - Border.Bottom, NormalSource.Width - Border.Left - Border.Right, Border.Bottom);
                NormalBottomRight.Viewbox = new Rect(NormalSource.Width - Border.Right, NormalSource.Height - Border.Bottom, Border.Right, Border.Bottom);

                HoverTopLeft.Viewbox = NormalTopLeft.Viewbox;
                HoverTop.Viewbox = NormalTop.Viewbox;
                HoverTopRight.Viewbox = NormalTopRight.Viewbox;
                HoverLeft.Viewbox = NormalLeft.Viewbox;
                HoverCenter.Viewbox = NormalCenter.Viewbox;
                HoverRight.Viewbox = NormalRight.Viewbox;
                HoverBottomLeft.Viewbox = NormalBottomLeft.Viewbox;
                HoverBottom.Viewbox = NormalBottom.Viewbox;
                HoverBottomRight.Viewbox = NormalBottomRight.Viewbox;

                ActiveTopLeft.Viewbox = NormalTopLeft.Viewbox;
                ActiveTop.Viewbox = NormalTop.Viewbox;
                ActiveTopRight.Viewbox = NormalTopRight.Viewbox;
                ActiveLeft.Viewbox = NormalLeft.Viewbox;
                ActiveCenter.Viewbox = NormalCenter.Viewbox;
                ActiveRight.Viewbox = NormalRight.Viewbox;
                ActiveBottomLeft.Viewbox = NormalBottomLeft.Viewbox;
                ActiveBottom.Viewbox = NormalBottom.Viewbox;
                ActiveBottomRight.Viewbox = NormalBottomRight.Viewbox;

                SelectedNormalTopLeft.Viewbox = NormalTopLeft.Viewbox;
                SelectedNormalTop.Viewbox = NormalTop.Viewbox;
                SelectedNormalTopRight.Viewbox = NormalTopRight.Viewbox;
                SelectedNormalLeft.Viewbox = NormalLeft.Viewbox;
                SelectedNormalCenter.Viewbox = NormalCenter.Viewbox;
                SelectedNormalRight.Viewbox = NormalRight.Viewbox;
                SelectedNormalBottomLeft.Viewbox = NormalBottomLeft.Viewbox;
                SelectedNormalBottom.Viewbox = NormalBottom.Viewbox;
                SelectedNormalBottomRight.Viewbox = NormalBottomRight.Viewbox;

                SelectedHoverTopLeft.Viewbox = NormalTopLeft.Viewbox;
                SelectedHoverTop.Viewbox = NormalTop.Viewbox;
                SelectedHoverTopRight.Viewbox = NormalTopRight.Viewbox;
                SelectedHoverLeft.Viewbox = NormalLeft.Viewbox;
                SelectedHoverCenter.Viewbox = NormalCenter.Viewbox;
                SelectedHoverRight.Viewbox = NormalRight.Viewbox;
                SelectedHoverBottomLeft.Viewbox = NormalBottomLeft.Viewbox;
                SelectedHoverBottom.Viewbox = NormalBottom.Viewbox;
                SelectedHoverBottomRight.Viewbox = NormalBottomRight.Viewbox;

                SelectedActiveTopLeft.Viewbox = NormalTopLeft.Viewbox;
                SelectedActiveTop.Viewbox = NormalTop.Viewbox;
                SelectedActiveTopRight.Viewbox = NormalTopRight.Viewbox;
                SelectedActiveLeft.Viewbox = NormalLeft.Viewbox;
                SelectedActiveCenter.Viewbox = NormalCenter.Viewbox;
                SelectedActiveRight.Viewbox = NormalRight.Viewbox;
                SelectedActiveBottomLeft.Viewbox = NormalBottomLeft.Viewbox;
                SelectedActiveBottom.Viewbox = NormalBottom.Viewbox;
                SelectedActiveBottomRight.Viewbox = NormalBottomRight.Viewbox;
            }
        }
    }
}
