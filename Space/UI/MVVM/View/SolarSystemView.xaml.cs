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

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for SolarSystemView.xaml
    /// </summary>
    /// 
    public class Planet  // JUST FOR TEST
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public string Description { get; set; }
        
    }


    public partial class SolarSystemView : UserControl
    {         
        double offset = 0;

        public SolarSystemView()
        {
            InitializeComponent();

            List<Planet> items = new List<Planet>();
            items.Add(new Planet() { Name = "MARS", Distance = 45, Description = "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often called the .[17][18] The latter refers to the effect of the iron oxide prevalent on Mars's surface, which gives it a striking reddish appearance in the sky.[19] Mars is a terrestrial planet with a thin atmosphere, with surface features such as impact craters, valleys, dunes, and polar ice caps." });
            items.Add(new Planet() { Name = "VENUS", Distance = 80 , Description = "Small PLANET AND.......??" });
            items.Add(new Planet() { Name = "VENUS2", Distance = 80 });
            items.Add(new Planet() { Name = "VENUS3", Distance = 80 });
            items.Add(new Planet() { Name = "VENUS4", Distance = 80 });
            items.Add(new Planet() { Name = "VENUS5", Distance = 80 });
            items.Add(new Planet() { Name = "JUPITER", Distance = 1230 });

            lb.ItemsSource =items ;


        }

        private void Button_Click_Right(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Primitives.RepeatButton btn = sender as System.Windows.Controls.Primitives.RepeatButton;
            ScrollViewer sv = btn.Tag as ScrollViewer;
             offset += 2;
            if (offset > sv.ScrollableWidth)
                offset = sv.ScrollableWidth;
            sv.ScrollToHorizontalOffset(offset);
        }

        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Primitives.RepeatButton btn = sender as System.Windows.Controls.Primitives.RepeatButton;
            ScrollViewer sv = btn.Tag as ScrollViewer;

            offset -= 2;
            if (offset < 0)
                offset = 0;
            sv.ScrollToHorizontalOffset(offset);
        }
    }
}
