using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IGenreRepo
    {
        /// <summary>
        /// Get all genres.
        /// </summary>
        Task<IEnumerable<Genre>> GetAllGenresAsync();
    }
}