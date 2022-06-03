using AdvancedWebDev_Lab3.DataAccess.Models;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess.Repos
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;
        public MovieRepo(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await dbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await dbContext.Movies
                .Include(m => m.Genres)
                .Include(m => m.Cast)
                .Include(m => m.Directors)
                .Include(m => m.Keywords)
                .Include(m => m.Productioncompanies)
                .SingleAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByKeywordAsync(string keyword)
        {
            return await dbContext.Movies
                .Where(m => m.Keywords.Select(x => x.Name).Any(x => keyword.Contains(x)))
                .ToListAsync();
        }
    }
}
