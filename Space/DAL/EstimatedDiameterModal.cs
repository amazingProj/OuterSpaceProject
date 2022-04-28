using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class EstimatedDiameterModal
    {
        [JsonProperty("estimated_diameter")]
        public JObject EstimatedDiameter { get; set; }
    }
}
