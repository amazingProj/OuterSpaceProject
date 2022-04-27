using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for GalleryView.xaml
    /// </summary>
    public partial class GalleryView : UserControl
    {
        BL.IBL bL;
        public GalleryView()
        {
            InitializeComponent();
            bL = new BL.BL();
        }

        private async void GetStartedButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> picturesStringFormatted = await bL.RetriveAllImagesFromFireBase();
            foreach (string picture in picturesStringFormatted)
            {

            }
        }
    }
}
