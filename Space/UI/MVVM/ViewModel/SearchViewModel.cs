using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class SearchViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;

        public SearchViewModel()
        {

        }

        public SearchViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
