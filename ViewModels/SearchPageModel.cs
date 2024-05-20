using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_CRYPTO.Models;

namespace WPF_CRYPTO.ViewModels
{
    class SearchPageModel : ViewModelBase
    {
        private API api;
        private ObservableCollection<Cryptocurrency> Cryptocurrencies;
        private ObservableCollection<Cryptocurrency> searchResults;

        public ObservableCollection<Cryptocurrency> SearchResults
        {
            get { return searchResults; }
            set
            {
                searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                searchKeyword = value;
                OnPropertyChanged(nameof(SearchKeyword));
                SearchCryptocurrencies();
            }
        }

        public ICommand SearchCommand { get; private set; }

        public SearchPageModel()
        {
            api = new API();
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>();
            SearchResults = new ObservableCollection<Cryptocurrency>();
            LoadCurrencies(10);
            SearchCommand = new RelayCommand(SearchCryptocurrencies);
        }

        public async void LoadCurrencies(int count)
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

        private void SearchCryptocurrencies()
        {
            if (string.IsNullOrWhiteSpace(SearchKeyword))
            {
                SearchResults.Clear();
                return;
            }

            var results = Cryptocurrencies.Where(c => c.Name.ToLower().Contains(SearchKeyword.ToLower()));
            SearchResults.Clear();
            foreach (var result in results)
            {
                SearchResults.Add(result);
            }
        }
    }
}
