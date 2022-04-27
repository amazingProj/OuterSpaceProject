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
    public class Planet  // JUST FOR TEST !!    deplace this to DAL
    {
        public string Name { get; set; }
        public int Mean_Temperature { get; set; }
        public int Distance { get; set; }

        public string ImagesPath { get; set; }
        public string Description { get; set; }
        
    }


    public partial class SolarSystemView : UserControl
    {         
        double offset = 0;

        public SolarSystemView()
        {
            InitializeComponent();

            List<Planet> items = new List<Planet>();
            items.Add(new Planet() { ImagesPath= "/Icons/jupiter.png", Name = "JUPITER", Mean_Temperature= 31  , Distance = 45, Description = "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often called the .[17][18] The latter refers to the effect of the iron oxide prevalent on Mars's surface, which gives it a striking reddish appearance in the sky.[19] Mars is a terrestrial planet with a thin atmosphere, with surface features such as impact craters, valleys, dunes, and polar ice caps." });
            items.Add(new Planet() { ImagesPath = "/Icons/earth.png", Name = "EARTH", Mean_Temperature = 25, Distance = 80 , Description = " While Earth is only the fifth largest planet in the solar system, it is the only world in our solar system with liquid water on the surface. Just slightly larger than nearby Venus, Earth is the biggest of the four planets closest to the Sun, all of which are made of rock and metal" });
            items.Add(new Planet() { ImagesPath = "/Icons/mercury.png", Name = "MERCURY", Mean_Temperature = 46, Distance = 80, Description = "The smallest planet in our solar system and nearest to the Sun, Mercury is only slightly larger than Earth's Moon.From the surface of Mercury, the Sun would appear more than three times as large as it does when viewed from Earth, and the sunlight would be as much as seven times brighter.Despite its proximity to the Sun, Mercury is not the hottest planet in our solar system – that title belongs to nearby Venus,                thanks to its dense atmosphere.Because of Mercury's elliptical – egg-shaped – orbit, and sluggish rotation, the Sun appears to rise briefly, set, and rise again from some parts of the planet's surface.The same thing happens in reverse at sunset." });
            items.Add(new Planet() { ImagesPath = "/Icons/mars.png", Name = "MARS", Mean_Temperature = 67, Distance = 80, Description = "Small PLANET AND.......??" });
            items.Add(new Planet() { ImagesPath = "/Icons/venus.png", Name = "VENUS", Mean_Temperature = 38, Distance = 80, Description = "Small PLANET AND.......??" });
            items.Add(new Planet() { ImagesPath = "/Icons/saturn.png", Name = "SATURN", Mean_Temperature = 78, Distance = 80, Description = "Small PLANET AND.......??" });
            items.Add(new Planet() { ImagesPath = "/Icons/uranus.png", Name = "URANUS", Mean_Temperature = 69, Distance = 1230, Description = "Small PLANET AND.......??" });
            items.Add(new Planet() { ImagesPath = "/Icons/neptune.png", Name = "NEPTUNE", Mean_Temperature = 31, Distance = 1230, Description = "Small PLANET AND.......??" });

            lb.ItemsSource = items ;


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
    }
}
