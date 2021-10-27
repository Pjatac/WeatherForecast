using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather.Models
{
    [Serializable]
    public class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
