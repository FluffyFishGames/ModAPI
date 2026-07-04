using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModAPI.Windows.SubWindows
{
    public partial class SelectGameDialog : Window
    {
        public string SelectedGameId { get; private set; } = null;

        private static readonly Dictionary<string, string> GameDisplayNames =
            new Dictionary<string, string>
            {
                { "TheForest",        "The Forest" },
                { "Subnautica",       "Subnautica" },
                { "Raft",             "Raft" },
                { "EscapeThePacific", "Escape The Pacific" },
                { "GH",               "Green Hell" },
            };

        // 클래식 테마 여부
        private bool _isClassic = false;

        public SelectGameDialog(IEnumerable<string> installedGameIds)
        {
            InitializeComponent();
            ApplyClassicThemeFix();
            BuildButtons(installedGameIds);
        }

        private void ApplyClassicThemeFix()
        {
            var bgBrush = Application.Current.Resources["FluentBgBrush"] as SolidColorBrush;
            if (bgBrush == null || bgBrush.Color.A == 0)
            {
                _isClassic = true;
                var border = (Border)Content;
                border.Background = new SolidColorBrush(Color.FromRgb(30, 20, 0));
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            }
        }

        private Style BuildButtonStyle(
            Brush normalBg, Brush hoverBg,
            Brush normalFg, Brush hoverFg)
        {
            var style = new Style(typeof(Button));

            var template = new ControlTemplate(typeof(Button));
            var borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(2));
            borderFactory.SetBinding(Border.BackgroundProperty,
                new System.Windows.Data.Binding("Background")
                {
                    RelativeSource = new System.Windows.Data.RelativeSource(
                        System.Windows.Data.RelativeSourceMode.TemplatedParent)
                });
            var cpFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            cpFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            cpFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            cpFactory.SetValue(ContentPresenter.MarginProperty, new Thickness(12, 0, 12, 0));
            borderFactory.AppendChild(cpFactory);
            template.VisualTree = borderFactory;

            style.Setters.Add(new Setter(Button.BackgroundProperty, normalBg));
            style.Setters.Add(new Setter(Button.ForegroundProperty, normalFg));
            style.Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(0)));
            style.Setters.Add(new Setter(Button.TemplateProperty, template));
            style.Setters.Add(new Setter(Button.CursorProperty,
                System.Windows.Input.Cursors.Hand));

            var hoverTrigger = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true
            };
            hoverTrigger.Setters.Add(new Setter(Button.BackgroundProperty, hoverBg));
            hoverTrigger.Setters.Add(new Setter(Button.ForegroundProperty, hoverFg));
            style.Triggers.Add(hoverTrigger);

            var pressedTrigger = new Trigger
            {
                Property = Button.IsPressedProperty,
                Value = true
            };
            pressedTrigger.Setters.Add(new Setter(Button.BackgroundProperty, hoverBg));
            pressedTrigger.Setters.Add(new Setter(Button.ForegroundProperty, hoverFg));
            style.Triggers.Add(pressedTrigger);

            return style;
        }

        private void BuildButtons(IEnumerable<string> gameIds)
        {
            // 테마별 색상 결정
            Brush normalBg, hoverBg, normalFg, hoverFg;
            Brush cancelBg, cancelHoverBg, cancelFg, cancelHoverFg;

            if (_isClassic)
            {
                normalBg = new SolidColorBrush(Color.FromRgb(60, 40, 0));
                hoverBg = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                normalFg = new SolidColorBrush(Colors.White);
                hoverFg = new SolidColorBrush(Colors.Black);
                cancelBg = new SolidColorBrush(Color.FromRgb(40, 25, 0));
                cancelHoverBg = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                cancelFg = new SolidColorBrush(Color.FromRgb(200, 200, 200));
                cancelHoverFg = new SolidColorBrush(Colors.Black);
            }
            else
            {
                normalBg = Application.Current.Resources["FluentSurfaceBrush"] as Brush
                                ?? new SolidColorBrush(Color.FromRgb(30, 30, 50));
                hoverBg = Application.Current.Resources["FluentAccentBrush"] as Brush
                                ?? new SolidColorBrush(Color.FromRgb(0, 120, 212));
                normalFg = Application.Current.Resources["FluentTextPrimaryBrush"] as Brush
                                ?? new SolidColorBrush(Colors.White);
                hoverFg = new SolidColorBrush(Colors.White);
                cancelBg = Application.Current.Resources["FluentCardBrush"] as Brush
                                ?? new SolidColorBrush(Color.FromRgb(50, 50, 85));
                cancelHoverBg = Application.Current.Resources["FluentBorderBrush"] as Brush
                                ?? new SolidColorBrush(Color.FromRgb(80, 80, 120));
                cancelFg = Application.Current.Resources["FluentTextSecondaryBrush"] as Brush
                                ?? new SolidColorBrush(Color.FromRgb(200, 200, 200));
                cancelHoverFg = new SolidColorBrush(Colors.White);
            }

            var gameStyle = BuildButtonStyle(normalBg, hoverBg, normalFg, hoverFg);
            var cancelStyle = BuildButtonStyle(cancelBg, cancelHoverBg, cancelFg, cancelHoverFg);

            foreach (var id in gameIds)
            {
                var displayName = GameDisplayNames.ContainsKey(id)
                    ? GameDisplayNames[id] : id;

                var btn = new Button
                {
                    Content = displayName,
                    Margin = new Thickness(0, 0, 0, 8),
                    Padding = new Thickness(12, 10, 12, 10),
                    FontSize = 13,
                    FontWeight = FontWeights.SemiBold,
                    Style = gameStyle,
                };

                var capturedId = id;
                btn.Click += (s, e) =>
                {
                    SelectedGameId = capturedId;
                    DialogResult = true;
                    Close();
                };

                GameButtonPanel.Children.Add(btn);
            }

            // 취소 버튼
            var cancelText = Application.Current.Resources["Lang.Windows.GameNoSignature.Cancel"]
                             as string ?? "Cancel";
            var cancelBtn = new Button
            {
                Content = cancelText,
                Margin = new Thickness(0, 4, 0, 0),
                Padding = new Thickness(12, 8, 12, 8),
                FontSize = 12,
                Style = cancelStyle,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };
            cancelBtn.Click += (s, e) =>
            {
                SelectedGameId = null;
                DialogResult = false;
                Close();
            };
            GameButtonPanel.Children.Add(cancelBtn);
        }
    }
}