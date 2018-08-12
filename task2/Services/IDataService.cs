using System.Collections.Generic;
using System.Threading.Tasks;
using task2.Models;

namespace task2.Services
{
    public interface IDataService
    {
        Task<StarShipsModel> GetDataAsync();
        StarShipsModel GetData();
    }
}
