﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class SearchPageModel : NavigateViewModelBase
    {
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

        public ICommand SearchCommand { get; }

        public ICommand ListBox_Changed { get; }

        public SearchPageModel(CurrencyStore currencyStore, INavigationService navigationService) : base(navigationService)
        {
            _currencyStore = currencyStore;

            SearchResults = new ObservableCollection<Cryptocurrency>();

            SearchCommand = new RelayCommand(SearchCryptocurrencies);

            ListBox_Changed = new RelayCommand(Navigation.NavigateTo<DetailsPageModel>);
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
