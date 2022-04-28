using Newtonsoft.Json;

namespace DAL
{
    public class LinksImageModal
    {
        [JsonProperty("href")]
        public string Url { get; set; }
    }
}
