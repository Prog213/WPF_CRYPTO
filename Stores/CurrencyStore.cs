using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.ViewModels;

namespace WPF_CRYPTO.Stores
{
    public class CurrencyStore
    {
        public ObservableCollection<Cryptocurrency> Cryptocurrencies { get; }
        public Cryptocurrency SelectedCryptocurrency { get; set; }

        public CurrencyStore()
        {
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>();
            LoadTopCurrencies(10);
        }

        public async Task LoadTopCurrencies(int count)
        {
            API api = new API();
            var currencies = await api.GetTopCurrencies(count);
            if (currencies != null)
            {
                Cryptocurrencies.Clear();
                foreach (var currency in currencies)
                {
                    Cryptocurrencies.Add(currency);
                }
            }
            SelectedCryptocurrency = Cryptocurrencies.Count > 0 ? Cryptocurrencies[0] : null;
        }
    }
}
