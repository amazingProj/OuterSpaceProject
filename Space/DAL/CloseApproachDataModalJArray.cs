using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CloseApproachDataModalJArrayFirst
    {
        [JsonProperty("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        [JsonProperty("relative_velocity")]
        public JObject RelativeVelocity { get; set; }

        [JsonProperty("miss_distance")]
        public JObject MissDistance { get; set; }
    }
}
