using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IKeywordRepo
    {
        /// <summary>
        /// Get all keywords.
        /// </summary>
        Task<IEnumerable<Keyword>> GetAllKeywordsAsync();
    }
}
