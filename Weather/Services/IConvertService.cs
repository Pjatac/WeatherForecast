using System.Collections.Generic;
using Weather.Models;

namespace Weather.Services
{
    public interface IConvertService
    {
        public (List<int>, List<double>, string) Convert(DataResponse data);
    }
}
