using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.Models;

namespace WPF_CRYPTO.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private API api;
        private ObservableCollection<Cryptocurrency> topCurrencies;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Cryptocurrency> TopCurrencies
        {
            get { return topCurrencies; }
            set
            {
                topCurrencies = value;
                OnPropertyChanged(nameof(TopCurrencies));
            }
        }

        public MainViewModel()
        {
            api = new API();
            TopCurrencies = new ObservableCollection<Cryptocurrency>();
        }

        public async Task LoadTopCurrencies(int count)
        {
            var currencies = await api.GetTopCurrencies(count);
            if (currencies != null)
            {
                TopCurrencies.Clear();
                foreach (var currency in currencies)
                {
                    TopCurrencies.Add(currency);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
