using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IMovieRepo
    {
        /// <summary>
        /// Get all the movies in the database. Note that this call will take a long time.
        /// </summary>
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        /// <summary>
        /// Get all movies where id is in passed in list.
        /// </summary>
        Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<int> movieIds);

        /// <summary>
        /// Get a distinct list of all of the release years in the database.
        /// </summary>
        Task<IEnumerable<string?>> GetReleaseYearsAsync();

        /// <summary>
        /// Get a list of filtered movies from the database.
        /// </summary>
        /// <param name="filters">The filters to apply.</param>
        /// <param name="take">How many results to return.</param>
        Task<FilterResult> GetFilteredMoviesAsync(Dictionary<string, List<string>> filters, int take);
    }
}
