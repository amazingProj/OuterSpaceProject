using UI.Core;

namespace UI.MVVM.ViewModel
{
    class TodayPictureViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;

        public TodayPictureViewModel()
        {

        }

        public TodayPictureViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
