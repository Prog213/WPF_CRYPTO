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
using WPF_CRYPTO.Commands;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Views;
using WPF_CRYPTO.ViewModels;
using WPF_CRYPTO.Stores;

namespace WPF_CRYPTO.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private CurrencyStore _currencyStore;
        public ICommand CurrencyPageButton_Click { get; }

        public ICommand DetailPageButton_Click { get; }

        public ICommand SearchPageButton_Click { get; }

        public ICommand ConvertPageButton_Click { get; }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore, CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            CurrencyPageButton_Click = new NavigateCommand<CurrenciesPageModel>
                (new NavigationService<CurrenciesPageModel>(navigationStore, () => new CurrenciesPageModel(_currencyStore, _navigationStore)));
            DetailPageButton_Click = new NavigateCommand<DetailPageModel>
                (new NavigationService<DetailPageModel>(navigationStore, () => new DetailPageModel(_currencyStore)));
            SearchPageButton_Click = new NavigateCommand<SearchPageModel>
                (new NavigationService<SearchPageModel>(navigationStore, () => new SearchPageModel(_currencyStore, _navigationStore)));
            ConvertPageButton_Click = new NavigateCommand<ConvertPageModel>
                (new NavigationService<ConvertPageModel>(navigationStore, () => new ConvertPageModel(_currencyStore)));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }




        //public ICommand MainPageButton_Click => new RelayCommand(() => NavigationStore.NavigateCommand.Execute(new MainPage()));

        //public ICommand DetailPageButton_Click => new RelayCommand(() => NavigationStore.NavigateCommand.Execute(new DetailPage()));

        //public ICommand SearchPageButton_Click => new RelayCommand(() => NavigationStore.NavigateCommand.Execute(new SearchPage()));
    }
}
