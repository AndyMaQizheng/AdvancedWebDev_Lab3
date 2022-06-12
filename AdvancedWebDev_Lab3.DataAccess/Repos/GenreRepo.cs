using AdvancedWebDev_Lab3.DataAccess.Models;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess.Repos
{
    public class GenreRepo : IGenreRepo
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;

        public GenreRepo(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get all genres.
        /// </summary>
        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await dbContext.Genres.ToListAsync();
        }
    }
}
