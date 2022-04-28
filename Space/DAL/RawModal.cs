using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RawModal
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("neo_reference_id")]
        public string NeoRefernceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonProperty("absolute_magnitude")]
        public string AbsoluteMagnitude { get; set; }

        [JsonProperty("estimated_diameter")]
        public JObject EstimatedDiameter { get; set; }

        [JsonProperty("close_approach_data")]
        public JArray CloseApproachData { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroids { get; set; }
    }
}
