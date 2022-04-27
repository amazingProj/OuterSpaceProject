using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand SearchViewCommand { get; set; }

        public RelayCommand MediaViewCommand { get; set; }

        public RelayCommand SolarSystemViewCommand { get; set; }

        public RelayCommand TodayPictureViewCommand { get; set; }

        public RelayCommand MyGalleryViewCommand { get; set; }

        public RelayCommand UploadImageViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public SearchViewModel SearchVM { get; set; }

        public MediaViewModel MediaVM { get; set; }

        public SolarSystemViewModel SolarSystemVM;

        public TodayPictureViewModel TodayPictureVM;

        public GalleryViewModel MyGalleryVM;

        public UploadImageViewModel UploadImageVM;

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel(this);
            SearchVM = new SearchViewModel(this);
            MediaVM = new MediaViewModel(this);
            SolarSystemVM = new SolarSystemViewModel(this);
            TodayPictureVM = new TodayPictureViewModel(this);
            MyGalleryVM = new GalleryViewModel(this);
            UploadImageVM = new UploadImageViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(s =>
            {
                CurrentView = HomeVM;
            });

            SearchViewCommand = new RelayCommand(s =>
            {
                CurrentView = SearchVM;
            });

            MediaViewCommand = new RelayCommand(s =>
            {
                CurrentView = MediaVM;
            });

            SolarSystemViewCommand = new RelayCommand(s =>
            {
                CurrentView = SolarSystemVM;
            });

            TodayPictureViewCommand = new RelayCommand(s =>
            {
                CurrentView = TodayPictureVM;
            });

            MyGalleryViewCommand = new RelayCommand(s =>
            {
                CurrentView = MyGalleryVM;
            });

            UploadImageViewCommand = new RelayCommand(s =>
            {
                CurrentView = UploadImageVM;
            });
        }
    }
}
