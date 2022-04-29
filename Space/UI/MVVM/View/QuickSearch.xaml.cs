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

        List<string> ListAsteroidNames = new List<string>(); 


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
            List<Dictionary<string, string>> Listdictionary = bl.GetOnlyDangerous(dateNow, future);

            foreach (var dic in Listdictionary)
            {
               
                    ListAsteroidNames.Add(dic["Name"]);
              

                //    foreach (var KEYVALUE in dic)  
                //    {
                //        if (KEYVALUE.Key = "name") { 
                //            string name = KEYVALUE.Value;}
                //    }

            }

            Dispatcher.Invoke(() =>
            {
                List_asteroids.DataContext = ListAsteroidNames;   

            });




            int x = 0;
        }

        private void List_asteroids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (List_asteroids.SelectedItem != null)
                {
                    List<Dictionary<string, string>> Listdictionary = bl.GetOnlyDangerous(dateNow, future);

                    foreach (var dic in Listdictionary)
                    {

                        if (dic["Name"] == (List_asteroids.SelectedItem).ToString())
                        {
                            try {
                                DateTB.Text = dic["Date"];
                                NameTB.Text = dic["Name"]; }

                            catch { }

                        }



                        //name = ((Listdictionary.SelectedItem as BO.Station).name);

                    }
                }
            
        }
            
            catch { }
        }
    }
}
