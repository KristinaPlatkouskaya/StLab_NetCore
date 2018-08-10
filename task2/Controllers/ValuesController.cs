using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task2.Services;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IDataService _dataService;
        public ValuesController(IDataService dataService)
        {
            this._dataService = dataService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            string url = "https://swapi.co/api/starships";
            return Ok(_dataService.GetData(url));
        }

        // GET api/values/async
        [HttpGet("async")]
        public async Task<ActionResult> GetAsync()
        {
            string url = "https://swapi.co/api/starships";
            return Ok(await _dataService.GetDataAsync(url));
        }
    }
}
