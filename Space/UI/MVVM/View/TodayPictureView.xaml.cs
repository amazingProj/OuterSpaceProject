using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using UI.MVVM.ViewModel;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for TodayPictureView.xaml
    /// </summary>
    public partial class TodayPictureView : UserControl
    {
        BackgroundWorker backGroundWorker = new BackgroundWorker();
        public TodayPictureView()
        {
            InitializeComponent();
            backGroundWorker.DoWork += UpdateTodayPictureUserInterface;
            backGroundWorker.RunWorkerAsync();

        }
        private void UpdateTodayPictureUserInterface(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            this.Dispatcher.Invoke(()
                =>
            {
                BL.IBL bl = new BL.BL();
                Dictionary<string, string> dic = bl.GetPictureOfTheDay();
               
                content.Text = dic["Explanation"];
                title.Text = dic["PicTitle"];
                
                date.Text = dic["Date"];
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(dic["HDPicUrl"]);
                bitmapImage.EndInit();
                img.ImageSource = bitmapImage;
            });
        }

        
    }
}
