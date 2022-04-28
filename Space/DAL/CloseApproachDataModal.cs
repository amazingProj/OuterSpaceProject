using Newtonsoft.Json;

namespace DAL
{
    public class CloseApproachDataModal
    {
        [JsonProperty("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }
}
