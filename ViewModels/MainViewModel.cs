using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_CRYPTO.Models;
using WPF_CRYPTO.Views;

namespace WPF_CRYPTO.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Page Main;
        private Page Detail;
        private Page Search;

        private Page _currentPage;
        public Page CurrentPage
        {
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
            get { return _currentPage; }
        }

        public MainViewModel()
        {
            Main = new MainPage();
            Detail = new DetailPage();
            Search = new SearchPage();

            CurrentPage = Main;
        }

        public ICommand MainPageButton_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Main);
            }
        }

        public ICommand DetailPageButton_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Detail);
            }
        }

        public ICommand SearchPageButton_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Search);
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
