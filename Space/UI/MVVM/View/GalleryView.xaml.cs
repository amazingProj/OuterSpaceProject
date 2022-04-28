using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UI.MVVM.Model;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for GalleryView.xaml
    /// </summary>
    public partial class GalleryView : UserControl
    {
        BL.IBL bL;
        ObservableCollection<ImageSource> results = new ObservableCollection<ImageSource>();

        public GalleryView()
        {
            InitializeComponent();
            bL = new BL.BL();
            //ListViewGallery.DataContext = results;


        }

        private async void GetStartedButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] pictureBytes;
            List<string> picturesStringFormatted = await bL.RetriveAllImagesFromFireBase();

            //var imageList = new ImageList();


            foreach (string picture in picturesStringFormatted)
            {
                pictureBytes = Encoding.ASCII.GetBytes(picture);
                using (var stream = new MemoryStream(pictureBytes))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.Freeze();
                    results.Add(bitmap);
                }

            }
            ListViewGallery.ItemsSource = results;
            ListViewGallery.Items.Refresh();



        }


    }
}
