using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task3.Domain.EF;
using task3.Domain.Entities;
using task3.Models;

namespace task3.Services
{
    public class FilmService : IFilmService
    {
        private readonly FilmsStoreDbContext _context;
        private readonly IMapper _mapper;
        public FilmService(FilmsStoreDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            if (!this._context.Films.Any())
            {
                this._context.Films.Add(new Film { Name = "The Lake House", Country = "United States", Year = 2006, Producer = "Doug Davison" });
                this._context.Films.Add(new Film { Name = "Lucky Number Slevin", Country = "Germany, Canada, United Kingdom, United States", Year = 2006, Producer = "Chris Roberts" });
                this._context.Films.Add(new Film { Name = "Catch Me If You Can", Country = "United States", Year = 2002, Producer = "Steven Spielberg" });
                this._context.Films.Add(new Film { Name = "The Social Network", Country = "United States", Year = 2010, Producer = "Scott Rudin" });
                this._context.SaveChanges();
            }
        }
        public async Task<ICollection<FilmModel>> GetFilmsAsync()
        {
            List<Film> films = await this._context.Films.ToListAsync();
            return _mapper.Map<List<Film>, List<FilmModel>>(films);
        }
        public async Task<FilmModel> GetFilmByIdAsync(int id)
        {
            Film film = await this._context.Films.FirstOrDefaultAsync(f => f.Id == id);
            return _mapper.Map<Film, FilmModel>(film);
        }
        public async Task<FilmModel> DeleteFilmAsync(int id)
        {
            Film deletedFilm = await this._context.Films.FindAsync(id);
            if (deletedFilm != null)
            {
                this._context.Films.Remove(deletedFilm);
                await this._context.SaveChangesAsync();
            }
            return _mapper.Map<Film,FilmModel>(deletedFilm);
        }
        public async Task AddFilmAsync(FilmModel filmModel)
        {
            Film film = _mapper.Map<FilmModel, Film>(filmModel);
            this._context.Films.Add(film);
            await this._context.SaveChangesAsync();
        }
        public async Task EditFilmAsync(FilmModel filmModel)
        {
            Film film = _mapper.Map<FilmModel, Film>(filmModel);
            if (this._context.Films.Any(f => f.Id == film.Id))
            {
                this._context.Films.Update(film);
            }
            await this._context.SaveChangesAsync();
        }
    }
}
