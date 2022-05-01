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
using System.Collections.ObjectModel;



namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for SolarSystemView.xaml
    /// </summary>
    /// 
     


    public partial class SolarSystemView : UserControl
    {         
        double offset = 0;
        BL.IBL bl = new BL.BL();

        //ObservableCollection<BL.Planet> Planets_list;  // ADD REFERENCE

        public SolarSystemView()
        {
            InitializeComponent();

            //Planets_list = new ObservableCollection<BL.Planet>(BL.getPlanets());

            List<Dictionary<string, string>> Listdictionary = bl.RetrieveDataFromSQLServer() ;

            lb.ItemsSource = Listdictionary ;



            //foreach (var dic in Listdictionary)
            //{
            //    lb.ItemsSource = dic[];
            //}


            //List<Dictionary<string, string>> RetrieveDataFromSQLServer()




        }

        private void Button_Click_Right(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Primitives.RepeatButton btn = sender as System.Windows.Controls.Primitives.RepeatButton;
            ScrollViewer sv = btn.Tag as ScrollViewer;
             offset += 1;
            if (offset > sv.ScrollableWidth)
                offset = sv.ScrollableWidth;
            sv.ScrollToHorizontalOffset(offset);
        }

        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Primitives.RepeatButton btn = sender as System.Windows.Controls.Primitives.RepeatButton;
            ScrollViewer sv = btn.Tag as ScrollViewer;

            offset -= 1;
            if (offset < 0)
                offset = 0;
            sv.ScrollToHorizontalOffset(offset);
        }

        private void Motre_Details_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://nssdc.gsfc.nasa.gov/planetary/factsheet/");
        }

    }
}
