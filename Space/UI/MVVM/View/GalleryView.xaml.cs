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
        ObservableCollection<BitmapImage> results = new ObservableCollection<BitmapImage>();

        public GalleryView()
        {
            InitializeComponent();
            bL = new BL.BL();
            //ListViewGallery.DataContext = results;


        }

        private async void GetStartedButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> picturesStringFormatted = await bL.RetriveAllImagesFromFireBase();



            foreach (string picture in picturesStringFormatted)
            {
                byte[] binaryData = Convert.FromBase64String(picture);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                results.Add(bi);

                //imagetest.Source = bi; // 

            }

            ListViewGallery.ItemsSource = results;
            //ListViewGallery.Items.Refresh();


        }

      
    }
}
