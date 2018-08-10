using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ActionResult Get(ValueModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(new SumResultModel { A = (int)model.A, B = (int)model.B, Sum = (int)(model.A + model.B) });
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
