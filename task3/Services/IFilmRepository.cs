using System.Collections.Generic;
using System.Threading.Tasks;
using task3.Domain.Entities;
namespace task3.Services
{
    public interface IFilmRepository
    {
        Task<ICollection<Film>> GetFilmsAsync();
        Task<Film> GetFilmByIdAsync(int id);
        Task<Film> DeleteFilmAsync(int id);
        Task AddFilmAsync(Film film);
        Task EditFilmAsync(Film film);
    }
}
