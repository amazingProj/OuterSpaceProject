using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using UI.Core;
using UI.MVVM.Model;

namespace UI.MVVM.ViewModel
{
    class TodayPictureViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;
        private TodayPictureModel TodayPictureModel { get; set; }
        private BL.IBL bl { get; set; }
        public TodayPictureViewModel()
        {
            bl = new BL.BL();
        }

        public TodayPictureViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
