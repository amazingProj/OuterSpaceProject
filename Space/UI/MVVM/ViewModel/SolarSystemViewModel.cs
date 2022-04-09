using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class SolarSystemViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;

        public SolarSystemViewModel()
        {

        }

        public SolarSystemViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
