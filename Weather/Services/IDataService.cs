using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Services
{
    public interface IDataService
    {
        Task<DataResponse> GetData(Coordinates coordinates);
    }
}
