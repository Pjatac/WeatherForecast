using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class DataResponse
    {
        [JsonPropertyName("cod")]
        public string Cod { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("cnt")]
        public string Count { get; set; }
        [JsonPropertyName("list")]
        public List<DataCollectionObject> List { get; set; }
        [JsonPropertyName("city")]
        public City City { get; set; }

    }
}
