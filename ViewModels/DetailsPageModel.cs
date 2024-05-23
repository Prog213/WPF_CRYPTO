using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Stores;
using WPF_CRYPTO.ViewModelBases;

namespace WPF_CRYPTO.ViewModels
{
    public class DetailsPageModel : ViewModelBase
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

        public DetailsPageModel(CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
        }
    }
}
