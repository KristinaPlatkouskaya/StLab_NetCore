using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ActionResult Get(SumResultModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(new SumResultModel { A = model.A, B = model.B, Sum = (int)(model.A + model.B) });
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
