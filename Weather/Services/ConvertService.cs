using System.Collections.Generic;
using Weather.Models;

namespace Weather.Services
{
    public class ConvertService : IConvertService
    {
        public (List<int>, List<double>, string) Convert(DataResponse data)
        {
            List<double> temperatures = new List<double>();
            List<int> times = new List<int>();
            foreach (var timeData in data.List)
            {
                temperatures.Add(timeData.main.temperature);
                times.Add(timeData.dt);
            }
            var formattedData = (times, temperatures, data.City.Name);

            return formattedData;
        }
    }
}
