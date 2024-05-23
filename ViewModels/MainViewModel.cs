using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Views;
using WPF_CRYPTO.Stores;
using WPF_CRYPTO.ViewModelBases;

namespace WPF_CRYPTO.ViewModels
{
    public class MainViewModel : NavigateViewModelBase
    {
        private CurrencyStore _currencyStore;
        public ICommand CurrencyPageButton_Click { get; }

        public ICommand DetailPageButton_Click { get; }

        public ICommand SearchPageButton_Click { get; }

        public ICommand ConvertPageButton_Click { get; }

        public ICommand SettingsPageButton_Click { get; }

        public MainViewModel(CurrencyStore currencyStore, INavigationService navigationService) : base(navigationService)
        {
            _currencyStore = currencyStore;

            CurrencyPageButton_Click = new RelayCommand(Navigation.NavigateTo<CurrenciesPageModel>);
            DetailPageButton_Click = new RelayCommand(Navigation.NavigateTo<DetailsPageModel>);
            SearchPageButton_Click = new RelayCommand(Navigation.NavigateTo<SearchPageModel>);
            ConvertPageButton_Click = new RelayCommand(Navigation.NavigateTo<ConvertPageModel>);
            SettingsPageButton_Click = new RelayCommand(Navigation.NavigateTo<SettingsPageModel>);
        }
    }
}
