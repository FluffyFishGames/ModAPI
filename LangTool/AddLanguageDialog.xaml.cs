using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MODAPI_LangTool.Helpers;
using MODAPI_LangTool.Models;

namespace MODAPI_LangTool
{
    public partial class AddLanguageDialog : Window
    {
        public string IsoCode  => IsoCodeBox.Text.Trim().ToLower();
        public string LangCode => LangCodeBox.Text.Trim().ToUpper();
        public string LangName => LangNameBox.Text.Trim();

        public AddLanguageDialog(IEnumerable<string> usedIsoCodes)
        {
            InitializeComponent();
            LoadCountryList(usedIsoCodes);
        }

        private void LoadCountryList(IEnumerable<string> usedIsoCodes)
        {
            var usedSet = new HashSet<string>(
                usedIsoCodes.Select(c => c.ToLower()));

            var list = IsoCountryList.All
                .Select(c => new IsoCountry
                {
                    IsoCode  = c.IsoCode,
                    Name     = c.Name,
                    LangCode = c.LangCode,
                    IsUsed   = usedSet.Contains(c.IsoCode)
                })
                .OrderBy(c => c.IsUsed)   // 미사용 먼저
                .ThenBy(c => c.Name)
                .ToList();

            CountryComboBox.ItemsSource = list;
        }

        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = CountryComboBox.SelectedItem as IsoCountry;
            if (selected == null) return;

            // ISO 코드 자동 입력 (읽기전용)
            IsoCodeBox.Text = selected.IsoCode.ToLower();

            // LangCode 자동 입력 (편집 가능)
            LangCodeBox.Text = selected.LangCode;
        }

        private string GetRes(string key)
        {
            try { return Application.Current.Resources[key] as string; }
            catch { return null; }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(IsoCode))
            {
                ShowError("국가를 선택해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(LangCode))
            {
                ShowError(GetRes("Lang.LangTool.AddDialog.LangCode") ?? "언어파일 코드를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(LangName))
            {
                ShowError(GetRes("Lang.LangTool.AddDialog.LangName") ?? "언어명을 입력해주세요.");
                return;
            }

            // 이미 사용 중인 ISO 코드 재확인
            var selected = CountryComboBox.SelectedItem as IsoCountry;
            if (selected != null && selected.IsUsed)
            {
                ShowError(GetRes("Lang.LangTool.Msg.NoDuplicate") ?? "이미 추가된 언어입니다.");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ShowError(string message)
        {
            ErrorText.Text = message;
            ErrorText.Visibility = Visibility.Visible;
        }
    }
}
