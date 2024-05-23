using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.Navigation;

namespace WPF_CRYPTO.ViewModelBases
{
    public class NavigateViewModelBase : ViewModelBase
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }

        public NavigateViewModelBase(INavigationService navigation)
        {
            _navigation = navigation;
        }
    }
}
