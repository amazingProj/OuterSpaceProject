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
            TodayPictureModel = new TodayPictureModel();
            SetTodayPicture();
        }

        public void SetTodayPicture()
        {
            Dictionary<string, string> dic = bl.GetPictureOfTheDay();

            TodayPictureModel.Content = dic["Explanation"];
            TodayPictureModel.Title = dic["PicTitle"];

            TodayPictureModel.Date = dic["Date"];
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(dic["HDPicUrl"]);
            bitmapImage.EndInit();
            TodayPictureModel.TodayPicture = bitmapImage;
        }
        public TodayPictureViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
    }
}
