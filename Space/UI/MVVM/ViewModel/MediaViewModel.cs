using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class MediaViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;

        public MediaViewModel()
        {

        }

        public MediaViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
