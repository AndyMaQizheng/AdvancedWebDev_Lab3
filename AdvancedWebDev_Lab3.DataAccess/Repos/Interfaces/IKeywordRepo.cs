using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IKeywordRepo
    {
        Task<IEnumerable<Keyword>> GetAllKeywordsAsync();
    }
}
