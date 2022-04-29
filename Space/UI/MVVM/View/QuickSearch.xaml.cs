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
    /// Interaction logic for QuickSearch.xaml
    /// </summary>
    public partial class QuickSearch : UserControl
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        BL.IBL bl = new BL.BL();
        
        string dateNow;

        string future;

        public QuickSearch()
        {
            InitializeComponent();
            dateNow = DateTime.UtcNow.ToString("yyyy-MM-dd");
            Now.Text = DateTime.UtcNow.ToString("MM-dd-yyyy"); ;
            future = DateTime.UtcNow.AddDays(30).ToString("yyyy-MM-dd");
            Future.Text = DateTime.UtcNow.AddDays(30).ToString("MM-dd-yyyy");
            backgroundWorker.DoWork += IntializeListViewAsync;
            backgroundWorker.RunWorkerAsync();
        }

        private void IntializeListViewAsync(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            List<Dictionary<string, string>> dictionary = bl.GetOnlyDangerous(dateNow, future);
            List<string> values = new List<string>();
            foreach (var dic in dictionary)
            {
                foreach (var key in dic.Keys)
                {
                    values.Add(dic[key]);
                }
            }
            int x = 0;
        }
    }
}
