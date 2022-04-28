using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemsModal
    {
        [JsonProperty("Items")]
        public JArray jArray { get; set; }
    }
}
