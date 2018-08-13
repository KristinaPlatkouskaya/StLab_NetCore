using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using task3.Attributes;
using task3.Domain.Entities;
using task3.Models;
using task3.Services;

namespace task3.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ActionAttribute))]
    [ServiceFilter(typeof(ExceptionAttribute))]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmService;
        private readonly IMapper _mapper;
        public FilmsController(IFilmRepository filmService, IMapper mapper)
        {
            this._filmService = filmService;
            this._mapper = mapper;
        }

        // GET api/films
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            ICollection<Film> films = await this._filmService.GetFilmsAsync();
            return Ok(films);
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Film film = await this._filmService.GetFilmByIdAsync(id);
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
            if (ModelState.IsValid)
            {
                Film film = _mapper.Map<FilmModel, Film>(filmModel);
                await this._filmService.AddFilmAsync(film);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT api/films
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] FilmModel filmModel)
        {
            if (ModelState.IsValid)
            {
                Film film = _mapper.Map<FilmModel, Film>(filmModel);
                await this._filmService.EditFilmAsync(film);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/films/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Film film = await this._filmService.DeleteFilmAsync(id);
            if (film != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}