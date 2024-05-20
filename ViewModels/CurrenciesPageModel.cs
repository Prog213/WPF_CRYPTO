using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_CRYPTO.Models;

namespace WPF_CRYPTO.ViewModels
{
    public class CurrenciesPageModel : ViewModelBase
    {
        public ICommand DetailPageCommand { get; }

        private API api;

        private ObservableCollection<Cryptocurrency> cryptocurrencies;

        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get { return cryptocurrencies; }
            set
            {
                cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }

        public CurrenciesPageModel()
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
        }
    }
}
