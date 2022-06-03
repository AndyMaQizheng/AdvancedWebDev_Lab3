using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IGenreRepo
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
    }
}