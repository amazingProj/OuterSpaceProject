using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.MVVM.Model
{
    public class Planet
    {
        public string Name { get; set; }
        public string ImagesPath { get; set; }

        public double mass { get; set; }
        public double diameter { get; set; }
        public double density { get; set; }
        public double gravity { get; set; }
        public double rotation_period { get; set; }
        public double distance_from_sun { get; set; }
        public double mean_temperature { get; set; }

        public string Description { get; set; }

    }
}
