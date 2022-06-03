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

        public async Task<IEnumerable<Director>> GetAllDirectorsAsync()
        {
            return await dbContext.Directors.ToListAsync();
        }

        public async Task<Director> GetDirectorByIdAsync(int id)
        {
            return await dbContext.Directors
                .Include(d => d.Movies)
                .SingleAsync(d => d.Id == id);
        }
    }
}
