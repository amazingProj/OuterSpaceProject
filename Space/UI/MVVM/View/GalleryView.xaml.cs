using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        ObservableCollection<BitmapImage> results = new ObservableCollection<BitmapImage>();
        BackgroundWorker backGroundWorker = new BackgroundWorker();

        public GalleryView()
        {
            InitializeComponent();
            bL = new BL.BL();
            //ListViewGallery.DataContext = results;
            backGroundWorker.DoWork += GetAllFirebaseImages;
            backGroundWorker.RunWorkerAsync();

        }

        public System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private async void GetAllFirebaseImages(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            List<string> picturesStringFormatted = await bL.RetriveAllImagesFromFireBase();
            this.Dispatcher.Invoke(() =>
            {
                foreach (string picture in picturesStringFormatted)
                {
                    byte[] binaryData = Convert.FromBase64String(picture);

                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(binaryData);
                    bi.EndInit();

                    results.Add(bi);

                    ListViewGallery.ItemsSource = results;
                }

                           
            });
            
        }

        private async void GetStartedButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> picturesStringFormatted = await bL.RetriveAllImagesFromFireBase();

            results.Clear();
            foreach (string picture in picturesStringFormatted)
            {
                byte[] binaryData = Convert.FromBase64String(picture);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                results.Add(bi);

                ListViewGallery.ItemsSource = results;
            }

           
        }
    }
}
