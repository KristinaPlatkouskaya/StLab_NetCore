using System.Collections.Generic;
using System.Threading.Tasks;
using task3.Models;

namespace task3.Services
{
    public interface IFilmService
    {
        Task<ICollection<FilmModel>> GetFilmsAsync();
        Task<FilmModel> GetFilmByIdAsync(int id);
        Task<FilmModel> DeleteFilmAsync(int id);
        Task AddFilmAsync(FilmModel filmModel);
        Task EditFilmAsync(FilmModel filmModel);
    }
}
