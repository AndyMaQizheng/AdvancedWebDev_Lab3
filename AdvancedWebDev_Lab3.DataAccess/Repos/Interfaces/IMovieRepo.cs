using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IMovieRepo
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<Movie> GetMovieByIdAsync(int id);

        Task<IEnumerable<Movie>> GetMoviesByKeywordAsync(string keyword);
    }
}
