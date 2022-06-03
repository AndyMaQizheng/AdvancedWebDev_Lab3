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

        public async Task<IEnumerable<Cast>> GetAllCastAsync()
        {
            return await dbContext.Casts.ToListAsync();
        }

        public async Task<Cast> GetCastByIdAsync(int id)
        {
            return await dbContext.Casts
                .Include(c => c.Movies)
                .SingleAsync(c => c.Id == id);
        }
    }
}
