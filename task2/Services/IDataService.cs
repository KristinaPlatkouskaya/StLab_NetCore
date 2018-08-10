using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2.Models;

namespace task2.Services
{
    public interface IDataService
    {
        Task<StarShipsModel> GetDataAsync(string url);
        StarShipsModel GetData(string url);
        void FillArray(List<StarShipModel> stars);
    }
}
