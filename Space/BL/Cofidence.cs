using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cofidence
    {
        [JsonProperty("confidence")]
        public double Confiedence { get; set; }

        [JsonProperty("tag")]
        public JObject tag { get; set; }
    }
}
