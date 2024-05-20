using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRYPTO.ViewModels;

namespace WPF_CRYPTO.Navigation
{
    public class NavigationService<TViewmodel>
    where TViewmodel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewmodel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewmodel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
