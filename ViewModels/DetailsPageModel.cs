using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Stores;

namespace WPF_CRYPTO.ViewModels
{
    public class DetailPageModel : ViewModelBase
    {
        private CurrencyStore _currencyStore;
        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;

        public Cryptocurrency SelectedCryptocurrency
        {
            get => _currencyStore.SelectedCryptocurrency;
            set
            {
                _currencyStore.SelectedCryptocurrency = value;
                OnPropertyChanged(nameof(SelectedCryptocurrency));
            }
        }

        public DetailPageModel(CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
        }
    }
}
