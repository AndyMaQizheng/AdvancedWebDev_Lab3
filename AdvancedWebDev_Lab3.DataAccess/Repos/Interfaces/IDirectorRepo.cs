using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IDirectorRepo
    {
        /// <summary>
        /// Get all directors.
        /// </summary>
        Task<IEnumerable<Director>> GetAllDirectorsAsync();
    }
}