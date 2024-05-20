using System.Configuration;
using System.Data;
using System.Windows;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Stores;
using WPF_CRYPTO.ViewModels;

namespace WPF_CRYPTO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private CurrencyStore _currencyStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _currencyStore = new CurrencyStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new CurrenciesPageModel(_currencyStore, _navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _currencyStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
