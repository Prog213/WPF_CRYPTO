using Microsoft.Extensions.DependencyInjection;
using System;
using System.CodeDom;
using System.Configuration;
using System.Data;
using System.Windows;
using WPF_CRYPTO.Navigation;
using WPF_CRYPTO.Stores;
using WPF_CRYPTO.ViewModelBases;
using WPF_CRYPTO.ViewModels;

namespace WPF_CRYPTO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<CurrencyStore>();

            services.AddSingleton(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider =>
                viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            services.AddSingleton<ViewModelBase>();
            services.AddSingleton<NavigateViewModelBase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<CurrenciesPageModel>();
            services.AddSingleton<DetailsPageModel>();
            services.AddSingleton<SearchPageModel>();
            services.AddSingleton<ConvertPageModel>();
            services.AddSingleton<SettingsPageModel>();

            services.AddSingleton<INavigationService, NavigationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            navigationService.Initialize<CurrenciesPageModel>();

            var mainwindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainwindow.Show();
            base.OnStartup(e);
        }
    }

}
