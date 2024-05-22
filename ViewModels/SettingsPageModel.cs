using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_CRYPTO.ViewModels
{
    public class SettingsPageModel : ViewModelBase
    {
        public ICommand LightThemeCommand { get; }
        public ICommand DarkThemeCommand { get; }

        public SettingsPageModel()
        {
            LightThemeCommand = new RelayCommand(ApplyLightTheme);
            DarkThemeCommand = new RelayCommand(ApplyDarkTheme);
        }

        public void ChangeTheme(Uri uri)
        {
            ResourceDictionary theme = new ResourceDictionary
            {
                Source = uri
            };

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(theme);
        }

        private void ApplyLightTheme()
        {
            ChangeTheme(new Uri("Themes/DarkTheme.xaml", UriKind.Relative));
        }

        private void ApplyDarkTheme()
        {
            ChangeTheme(new Uri("Themes/LightTheme.xaml", UriKind.Relative));
        }
    }
}
