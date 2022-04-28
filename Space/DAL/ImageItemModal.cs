using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class ImageItemModal
    {
        [JsonProperty("data")]
        public JArray Data { get; set; }

        [JsonProperty("links")]
        public JArray Links { get; set; }
    }
}
