using Newtonsoft.Json;
using System;

namespace Weather.Models
{
    [Serializable]
    public class DataCollectionObject
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public DataCollectionObject()
        {

        }
    }
    [Serializable]
    public class Data
    { 
        public int dt { get; set; }
        public Main main { get; set; }
        public Data()
        {

        }
    }

    [Serializable]
    public class Main
    {
        [JsonProperty("temp")]
        public double temperature { get; set; }
        public Main()
        {

        }
    }
}
