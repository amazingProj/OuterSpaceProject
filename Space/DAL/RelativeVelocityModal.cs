using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RelativeVelocityModal
    {
        [JsonProperty("kilometers_per_hour")]

        public double kilometers_per_hour { get; set; }
    }
}
