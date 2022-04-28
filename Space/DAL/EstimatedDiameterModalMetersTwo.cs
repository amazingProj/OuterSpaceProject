using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DAL
{
    public class EstimatedDiameterModalMetersTwo
    {
        [JsonProperty("meters")]

        public JObject meters { get; set; }
    }
}
