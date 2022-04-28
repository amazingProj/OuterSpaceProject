using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class HazardsModal
    {
        [JsonProperty("element_count")]
        public int elementCount { get; set; }

        [JsonProperty("near_earth_objects")]
        public JObject nearEarthObjects { get; set; }
    }
}
