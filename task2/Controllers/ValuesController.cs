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
            return Ok(_dataService.GetData());
        }

        // GET api/values/async
        [HttpGet("async")]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _dataService.GetDataAsync());
        }
    }
}
