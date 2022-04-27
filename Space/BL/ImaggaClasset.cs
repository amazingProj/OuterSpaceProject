using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BL
{
    public class ImaggaClasset
    {
        [JsonProperty("result")]

        public JObject HypthesesList;
    }
}
