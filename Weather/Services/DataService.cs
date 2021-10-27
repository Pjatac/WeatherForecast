using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Extentions;
using Weather.Models;

namespace Weather.Services
{
    public class DataService : IDataService
    {
        private readonly IConfiguration Configuration;
        private readonly string _requestPathTemplate;
        private readonly HttpClient _httpCient = new HttpClient();
        public DataService(IConfiguration config)
        {
            Configuration = config;
            _requestPathTemplate = Configuration["ApiAddress"];
        }
        public async Task<DataResponse> GetData(Coordinates coordinates)
        {
            string apiAddress = BuildRequestPath(coordinates);

            var response = await _httpCient.GetAsync(apiAddress);
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<DataResponse>(content);
        }

        private string BuildRequestPath(Coordinates coordinates)
        {
            string template = _requestPathTemplate;
            int[] positions = _requestPathTemplate.GetCoordsIndexes("{}").ToArray(); ;

            string apiAddress = _requestPathTemplate.Remove(positions[0], Math.Min(2, _requestPathTemplate.Length - positions[0]))
        .Insert(positions[0], coordinates.Latitude.ToString());
            apiAddress = apiAddress.Remove(positions[1] + coordinates.Latitude.ToString().Count() - 2, Math.Min(2, apiAddress.Length - positions[1]))
        .Insert(positions[1] + coordinates.Latitude.ToString().Count() - 2, coordinates.Longitude.ToString());

            return apiAddress;
        }
    }
}
