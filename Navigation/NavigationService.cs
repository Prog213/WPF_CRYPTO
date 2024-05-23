using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.ViewModelBases;
using WPF_CRYPTO.ViewModels;

namespace WPF_CRYPTO.Navigation
{
    public interface INavigationService
    {
        public ViewModelBase CurrentView { get; }
        void Initialize<TViewModel>() where TViewModel : ViewModelBase;
        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
    }
    class NavigationService : ViewModelBase, INavigationService
    {
        private ViewModelBase _currentView;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void Initialize<TViewModel>() where TViewModel : ViewModelBase
        {
            CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
