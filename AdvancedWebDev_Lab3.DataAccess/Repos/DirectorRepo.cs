using AdvancedWebDev_Lab3.DataAccess.Models;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess.Repos
{
    public class DirectorRepo : IDirectorRepo
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;

        public DirectorRepo(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get all directors.
        /// </summary>
        public async Task<IEnumerable<Director>> GetAllDirectorsAsync()
        {
            return await dbContext.Directors.ToListAsync();
        }
    }
}
