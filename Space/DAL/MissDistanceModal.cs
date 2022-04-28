using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MissDistanceModal
    {
        [JsonProperty("kilometers")]
        public double KilometersMissDistance { get; set; }
    }
}
