using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace MODAPI_VersionTool
{
    public partial class MainWindow : Window
    {
        private static readonly string AssemblyInfoPath =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\ModAPI\Properties\AssemblyInfo.cs"));
        private static readonly string AppXamlCsPath =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\ModAPI\App.xaml.cs"));

        public MainWindow()
        {
            InitializeComponent();
            LoadCurrentVersion();
        }

        private void LoadCurrentVersion()
        {
            try
            {
                if (!File.Exists(AppXamlCsPath))
                {
                    CurrentVersionText.Text = "(App.xaml.cs not found)";
                    CurrentVersionText.Foreground = new SolidColorBrush(Color.FromRgb(255, 100, 100));
                    return;
                }
                var content = File.ReadAllText(AppXamlCsPath);
                var match = Regex.Match(content,
                    @"public static string Version\s*=\s*""([^""]+)"";");
                CurrentVersionText.Text = match.Success ? match.Groups[1].Value : "(unknown)";
            }
            catch (Exception ex)
            {
                CurrentVersionText.Text = $"(error: {ex.Message})";
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            var version = VersionInput.Text.Trim();

            if (!Regex.IsMatch(version, @"^\d+\.\d+\.\d+$"))
            {
                MessageBox.Show("버전 형식이 올바르지 않습니다.\n올바른 형식: 2.0.9618",
                    "형식 오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var assemblyVersion = version + ".0";
            try
            {
                if (!File.Exists(AssemblyInfoPath))
                    throw new FileNotFoundException(
                        "AssemblyInfo.cs를 찾을 수 없습니다.\n" + AssemblyInfoPath);

                var asmContent = File.ReadAllText(AssemblyInfoPath);
                asmContent = Regex.Replace(asmContent,
                    @"\[assembly: AssemblyVersion\(""[^""]*""\)\]",
                    $@"[assembly: AssemblyVersion(""{assemblyVersion}"")]");
                asmContent = Regex.Replace(asmContent,
                    @"\[assembly: AssemblyFileVersion\(""[^""]*""\)\]",
                    $@"[assembly: AssemblyFileVersion(""{assemblyVersion}"")]");
                File.WriteAllText(AssemblyInfoPath, asmContent);

                if (!File.Exists(AppXamlCsPath))
                    throw new FileNotFoundException(
                        "App.xaml.cs를 찾을 수 없습니다.\n" + AppXamlCsPath);

                var appContent = File.ReadAllText(AppXamlCsPath);
                appContent = Regex.Replace(appContent,
                    @"public static string Version\s*=\s*""[^""]*"";",
                    $@"public static string Version = ""{version}"";");
                File.WriteAllText(AppXamlCsPath, appContent);

                CurrentVersionText.Text = version;

                MessageBox.Show(
                    $"버전이 성공적으로 적용되었습니다.\n\n" +
                    $"AssemblyInfo.cs  →  {assemblyVersion}\n" +
                    $"App.xaml.cs       →  {version}",
                    "완료", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다.\n\n{ex.Message}",
                    "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
