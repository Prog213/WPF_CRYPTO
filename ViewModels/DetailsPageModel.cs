using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.Models;

namespace WPF_CRYPTO.ViewModels
{
    public class DetailPageModel : ViewModelBase
    {
        private API api;
        private ObservableCollection<Cryptocurrency> cryptocurrencies;
        private Cryptocurrency selectedCryptocurrency;

        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get { return cryptocurrencies; }
            set
            {
                cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }

        public Cryptocurrency SelectedCryptocurrency
        {
            get { return selectedCryptocurrency; }
            set
            {
                selectedCryptocurrency = value;
                OnPropertyChanged(nameof(SelectedCryptocurrency));
            }
        }

        public DetailPageModel()
        {
            api = new API();
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>();
            LoadTopCurrencies(10);
        }

        public async void LoadTopCurrencies(int count)
        {
            var currencies = await api.GetTopCurrencies(count);
            if (currencies != null)
            {
                Cryptocurrencies.Clear();
                foreach (var currency in currencies)
                {
                    Cryptocurrencies.Add(currency);
                }
            }
            SelectedCryptocurrency = Cryptocurrencies[0];
        }
    }
}
