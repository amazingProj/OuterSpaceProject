using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiameterMinMaxModal
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameter_Min { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double estimated_diameter_max { get; set; }
    }
}
