using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BL
{
    public class Hypotheses
    {
        [JsonProperty("tags")]
        public JArray Tags { get; set; }
    }
}
