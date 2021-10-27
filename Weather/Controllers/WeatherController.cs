using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;

namespace Weather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IConvertService _converter;
        private readonly IDataService _dataService;

        public WeatherController(IDataService dataService, IConvertService converter)
        {
            _dataService = dataService;
            _converter = converter;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetForecast(Coordinates coordinates)
        {
            var serverData = await _dataService.GetData(coordinates);
            var chartData = _converter.Convert(serverData);
            var stringifyedData = JsonConvert.SerializeObject(chartData);

            return Json(stringifyedData);
        }

        public async Task<IActionResult> GetForecastForMVC(Coordinates coordinates)
        {
            var serverData = await _dataService.GetData(coordinates);
            var chartData = _converter.Convert(serverData);

            return PartialView("Forecast", chartData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
