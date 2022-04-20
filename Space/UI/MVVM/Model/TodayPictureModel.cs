using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using UI.Core;

namespace UI.MVVM.Model
{
    class TodayPictureModel : ObservableObject
    {
        private BitmapImage _todayPicture;

        public BitmapImage TodayPicture
        {
            get { return _todayPicture; }
            set
            {
                _todayPicture = value;
                OnPropertyChanged();
            }
        }


        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }


        private string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }



    }
}
