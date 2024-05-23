using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Stores;
using WPF_CRYPTO.ViewModelBases;

namespace WPF_CRYPTO.ViewModels
{
    public class CurrenciesPageModel : NavigateViewModelBase
    {
        public ICommand ListBox_Changed { get; }

        private CurrencyStore _currencyStore;

        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;
        public Cryptocurrency SelectedCryptocurrency
        {
            get { return null; }
            set
            {
                _currencyStore.SelectedCryptocurrency = value;
                OnPropertyChanged(nameof(SelectedCryptocurrency));
            }
        }

        public CurrenciesPageModel(CurrencyStore currencyStore, INavigationService navigationService) : base(navigationService)
        {
            _currencyStore = currencyStore;
            ListBox_Changed = new RelayCommand(Navigation.NavigateTo<DetailsPageModel>);
        }
    }
}
