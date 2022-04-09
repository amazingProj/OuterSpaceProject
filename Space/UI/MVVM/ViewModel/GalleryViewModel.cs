using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class GalleryViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;
        public GalleryViewModel()
        {
           
        }

        public GalleryViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
