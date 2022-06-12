using AdvancedWebDev_Lab3.DataAccess.Models;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess.Repos
{
    public class KeywordRepo : IKeywordRepo
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;

        public KeywordRepo(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get all genres.
        /// </summary>
        public async Task<IEnumerable<Keyword>> GetAllKeywordsAsync()
        {
            return await dbContext.Keywords.ToListAsync();
        }
    }
}
