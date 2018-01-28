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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ModAPI.Components;
using ModAPI.Data;
using ModAPI.Data.Models;

public class ModProjectViewModel : INotifyPropertyChanged
{
    public ModProject Project;

    public ModProjectViewModel(ModProject project)
    {
        Project = project;
        if (Project.Name == null)
        {
            Project.Name = new MultilingualValue();
        }
        Project.Name.OnChange += NameChanged;
        Project.Description.OnChange += NameChanged;
        foreach (var langCode in Project.Languages)
        {
            AddLanguageButton(langCode);
            /*<Button Style="{StaticResource NormalButton}">
                                                    <StackPanel Orientation="Horizontal" Margin="-10,-17,-10,-16">
                                                        <TextBlock Text="Englisch" VerticalAlignment="Center" Margin="10,0,10,0" />
                                                        <Image Source="/resources/textures/Icons/Icon_Delete.png" Height="20" Margin="0,0,5,0" />
                                                    </StackPanel>
                                                </Button>*/
        }

        foreach (var button in project.Buttons)
        {
            var _button = new ModProjectButton
            {
                DataContext = new ModProjectButtonViewModel(this, button)
            };
            _Buttons.Add(_button);
        }

        CheckForErrors();
    }

    public void AddButton()
    {
        try
        {
            var button = new ModProject.Button
            {
                Project = Project
            };
            Project.Buttons.Add(button);
            var _button = new ModProjectButton
            {
                DataContext = new ModProjectButtonViewModel(this, button)
            };
            _Buttons.Add(_button);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void RemoveButton(ModProject.Button button)
    {
        Project.Buttons.Remove(button);
        for (var i = 0; i < _Buttons.Count; i++)
        {
            var vm = _Buttons[i];
            if (((ModProjectButtonViewModel) vm.DataContext).Button == button)
            {
                _Buttons.RemoveAt(i);
                return;
            }
        }
    }

    protected void NameChanged(object sender, EventArgs e)
    {
        Project.SaveConfiguration();
        CheckForErrors();
    }

    protected void DescriptionChanged(object sender, EventArgs e)
    {
        Project.SaveConfiguration();
        CheckForErrors();
    }

    protected void RemoveLanguage(object sender, EventArgs e)
    {
        var langCode = (string) (((Button) sender).DataContext);
        _Languages.Remove(langCode);
        Project.Languages.Remove(langCode);
        _LanguageButtons.Remove((Button) sender);
        CheckForErrors();
    }

    protected void AddLanguageButton(string langCode)
    {
        var newButton = new Button
        {
            Style = Application.Current.FindResource("NormalButton") as Style,
            DataContext = langCode
        };
        newButton.Click += RemoveLanguage;
        newButton.Margin = new Thickness(0, 0, 10, 4);

        var panel = new StackPanel
        {
            Orientation = Orientation.Horizontal
        };
        var image = new Image
        {
            Height = 20
        };
        var source = new BitmapImage();
        source.BeginInit();
        source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Lang_" + langCode + ".png");
        source.EndInit();
        image.Source = source;
        image.Margin = new Thickness(0, 0, 5, 0);
        panel.Children.Add(image);

        var image2 = new Image
        {
            Height = 24
        };
        var source2 = new BitmapImage();
        source2.BeginInit();
        source2.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Icon_Delete.png");
        source2.EndInit();
        image2.Source = source2;
        image2.Margin = new Thickness(5, 0, 0, 0);

        var label = new TextBlock
        {
            FontSize = 16
        };
        label.SetResourceReference(TextBlock.TextProperty, "Lang.Languages." + langCode);
        panel.Children.Add(label);
        panel.Children.Add(image2);

        newButton.Content = panel;
        _LanguageButtons.Add(newButton);
        _Languages.Add(langCode);
    }

    public string Version
    {
        get => Project.Version;
        set
        {
            Project.Version = value;
            Project.SaveConfiguration();
            OnPropertyChanged("Version");
            CheckForErrors();
        }
    }

    protected Visibility _VersionError = Visibility.Collapsed;
    protected Visibility _SettingsError = Visibility.Collapsed;
    protected Visibility _ButtonsError = Visibility.Collapsed;
    protected Visibility _LanguagesError = Visibility.Collapsed;
    protected Visibility _NameError = Visibility.Collapsed;
    protected Visibility _SaveError = Visibility.Collapsed;
    protected Visibility _Error = Visibility.Collapsed;

    public Visibility NameError => _NameError;
    public Visibility SaveError => _SaveError;
    public Visibility Error => _Error;
    public Visibility VersionError => _VersionError;
    public Visibility LanguagesError => _LanguagesError;
    public Visibility SettingsError => _SettingsError;
    public Visibility ButtonsError => _ButtonsError;

    public void CheckForErrors()
    {
        _VersionError = Mod.Header.VerifyModVersion(Project.Version) ? Visibility.Collapsed : Visibility.Visible;
        _LanguagesError = Project.Languages.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        _NameError = Visibility.Collapsed;
        _SaveError = Project.SaveFailed ? Visibility.Visible : Visibility.Collapsed;

        foreach (var langCode in Project.Languages)
        {
            if (Project.Name.GetString(langCode).Trim() == "")
            {
                _NameError = Visibility.Visible;
            }
        }

        _SettingsError = _VersionError == Visibility.Visible || _NameError == Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;

        _ButtonsError = Visibility.Collapsed;
        foreach (var button in Buttons)
        {
            var mv = (ModProjectButtonViewModel) button.DataContext;
            if (mv.Error == Visibility.Visible)
            {
                _ButtonsError = Visibility.Visible;
                break;
            }
        }

        _Error = _ButtonsError == Visibility.Visible || _SettingsError == Visibility.Visible || _LanguagesError == Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;

        OnPropertyChanged("LanguagesError");
        OnPropertyChanged("ButtonsError");
        OnPropertyChanged("VersionError");
        OnPropertyChanged("SettingsError");
        OnPropertyChanged("NameError");
        OnPropertyChanged("SaveError");
        OnPropertyChanged("Error");
    }

    public void AddProjectLanguage(string langCode)
    {
        Project.Languages.Add(langCode);
        AddLanguageButton(langCode);
        CheckForErrors();
    }

    public string Id
    {
        get => Project.Id;
        set
        {
            Project.Id = value;
            Project.SaveConfiguration();
            OnPropertyChanged("Id");
            CheckForErrors();
        }
    }

    public MultilingualValue Name => Project.Name;
    public MultilingualValue Description => Project.Description;
    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }

    protected ObservableCollection<Button> _LanguageButtons = new ObservableCollection<Button>();

    public ObservableCollection<Button> LanguageButtons => _LanguageButtons;
    protected ObservableCollection<ModProjectButton> _Buttons = new ObservableCollection<ModProjectButton>();

    public ObservableCollection<ModProjectButton> Buttons => _Buttons;
    protected ObservableCollection<string> _Languages = new ObservableCollection<string>();

    public ObservableCollection<string> Languages => _Languages;
}
