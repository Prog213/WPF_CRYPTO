using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_CRYPTO.Commands;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Stores;

namespace WPF_CRYPTO.ViewModels
{
    public class CurrenciesPageModel : ViewModelBase
    {
        public ICommand ListBox_Changed { get; }

        private CurrencyStore _currencyStore;
        private NavigationStore _navigationStore;

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

        public CurrenciesPageModel(CurrencyStore currencyStore, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _currencyStore = currencyStore;
            ListBox_Changed = new NavigateCommand<DetailPageModel>
                (new NavigationService<DetailPageModel>(navigationStore, () => new DetailPageModel(_currencyStore)));
        }
    }
}
