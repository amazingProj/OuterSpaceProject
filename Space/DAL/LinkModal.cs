using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LinkModal
    {
        [JsonProperty("id")]
        public string EstimatedDiameter { get; set; }

        [JsonProperty("neo_reference_id")]
        public string NeoRefernceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonProperty("absolute_magnitude")]
        public string AbsoluteMagnitude { get; set; }
    }
}
