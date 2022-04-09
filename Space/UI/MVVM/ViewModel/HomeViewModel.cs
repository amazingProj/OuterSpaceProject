using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;

        public HomeViewModel()
        {

        }

        public HomeViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
