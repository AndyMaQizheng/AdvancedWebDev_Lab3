using AdvancedWebDev_Lab3.DataAccess.Models;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess.Repos
{
    public class CastRepo : ICastRepo
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;

        public CastRepo(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get all cast members.
        /// </summary>
        public async Task<IEnumerable<Cast>> GetAllCastAsync()
        {
            return await dbContext.Casts
                .Where(c => !string.IsNullOrWhiteSpace(c.Name))
                .ToListAsync();
        }
    }
}
