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
    public class ConvertPageModel : ViewModelBase
    {
        private CurrencyStore _currencyStore;
        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;

        public ConvertPageModel(CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
            amountFromText = "0";
        }

        private Cryptocurrency selectedCurrencyFrom;
        public Cryptocurrency SelectedCurrencyFrom
        {
            get { return selectedCurrencyFrom; }
            set
            {
                if (selectedCurrencyFrom != value)
                {
                    selectedCurrencyFrom = value;
                    OnPropertyChanged(nameof(SelectedCurrencyFrom));
                    UpdateConvertedAmount();
                }
            }
        }

        private Cryptocurrency selectedCurrencyTo;
        public Cryptocurrency SelectedCurrencyTo
        {
            get { return selectedCurrencyTo; }
            set
            {
                if (selectedCurrencyTo != value)
                {
                    selectedCurrencyTo = value;
                    OnPropertyChanged(nameof(SelectedCurrencyTo));
                    UpdateConvertedAmount();
                }
            }
        }

        private string amountFromText;
        public string AmountFromText
        {
            get { return amountFromText; }
            set
            {
                if (amountFromText != value)
                {
                    amountFromText = value;
                    OnPropertyChanged(nameof(AmountFromText));
                    UpdateConvertedAmount();
                }
            }
        }

        private decimal amountTo;
        public decimal AmountTo
        {
            get { return amountTo; }
            set
            {
                if (amountTo != value)
                {
                    amountTo = value;
                    OnPropertyChanged(nameof(AmountTo));
                }
            }
        }

        private void UpdateConvertedAmount()
        {
            if (SelectedCurrencyFrom != null && SelectedCurrencyTo != null && !string.IsNullOrEmpty(AmountFromText))
            {
                decimal amountFrom = decimal.Parse(AmountFromText);
                AmountTo = Math.Round((SelectedCurrencyFrom.PriceUsd * amountFrom) / SelectedCurrencyTo.PriceUsd, 5);
            }
            else
            {
                AmountTo = 0m;
            }
        }
    }
}
