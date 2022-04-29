using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        BL.IBL bl = new BL.BL();

        public HomeView()
        {
            InitializeComponent();
           // backgroundWorker.DoWork += UpdateImage;
            //backgroundWorker.RunWorkerAsync();
        }

        /*public async void UpdateImage(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            this.Dispatcher.Invoke(()
                =>
            {
                string url = bl.GetNormalTodayPicture();

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(url);
                bitmapImage.EndInit();
                TodayPicture.Source = bitmapImage;
            });
        }*/
    }
}
