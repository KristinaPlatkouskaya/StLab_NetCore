using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task3.Attributes;
using task3.Models;
using task3.Services;

namespace task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ActionAttribute))]
    [ServiceFilter(typeof(ExceptionAttribute))]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _filmService;
        public FilmsController(IFilmService filmService)
        {
            this._filmService = filmService;
        }

        // GET api/films
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            ICollection<FilmModel> films = await this._filmService.GetFilmsAsync();
            return Ok(films);
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            FilmModel film = await this._filmService.GetFilmByIdAsync(id);
            if (film != null)
            {
                return Ok(film);
            }
            return NotFound();
        }

        // POST api/films
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FilmModel filmModel)
        {
            if (filmModel != null)
            {
                await this._filmService.AddFilmAsync(filmModel);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/films
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] FilmModel filmModel)
        {
            if (filmModel != null)
            {
                await this._filmService.EditFilmAsync(filmModel);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/films/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            FilmModel filmModel = await this._filmService.DeleteFilmAsync(id);
            if (filmModel != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}