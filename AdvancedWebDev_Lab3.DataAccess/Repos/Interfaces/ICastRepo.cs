using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface ICastRepo
    {
        /// <summary>
        /// Get all cast members.
        /// </summary>
        Task<IEnumerable<Cast>> GetAllCastAsync();
    }
}