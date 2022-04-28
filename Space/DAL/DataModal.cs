using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataModal
    {
        [JsonProperty("description")]
        public string Desription { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
