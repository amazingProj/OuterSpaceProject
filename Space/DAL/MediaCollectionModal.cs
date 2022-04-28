using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class MediaCollectionModal
    {
        [JsonProperty("collection")]

        public JObject Collection { get; set; }
    }
}
