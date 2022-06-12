using System.Text;
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

        /// <summary>
        /// Get all the movies in the database. Note that this call will take a long time.
        /// </summary>
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await dbContext.Movies.ToListAsync();
        }

        /// <summary>
        /// Get a distinct list of all of the release years in the database.
        /// </summary>
        public async Task<IEnumerable<string?>> GetReleaseYearsAsync()
        {
            return await dbContext.Movies
                .Select(x => x.ReleaseYear)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Get a list of filtered movies from the database.
        /// </summary>
        /// <param name="filters">The filters to apply.</param>
        /// <param name="take">How many results to return.</param>
        public async Task<FilterResult> GetFilteredMoviesAsync(Dictionary<string, List<string>> filters, int take = 30)
        {
            /*
             * To speed up execution time, we start by going through each filter and simply getting
             * the movie ids that match the result. We then go though at the end and get a distinct 
             * list of movie data using the data.
             */

            var movieIds = new List<int>();
            int appliedFiltersCount = 0;

            // Get release year movie ids.
            var releaseYearResult = await GetReleaseYearFilters(filters);
            movieIds.AddRange(releaseYearResult.Ids);
            if (releaseYearResult.FilterApplied)
            {
                appliedFiltersCount++;
            }

            // Get cast filter movie ids.
            var castResult = await GetCastFilters(filters);
            movieIds.AddRange(castResult.Ids);
            if (castResult.FilterApplied)
            {
                appliedFiltersCount++;
            }

            // Get directors filter movie ids.
            var directorsResult = await GetDirectorFilters(filters);
            movieIds.AddRange(directorsResult.Ids);
            if (directorsResult.FilterApplied)
            {
                appliedFiltersCount++;
            }

            // Get genre filter movie ids.
            var genresResult = await GetGenreFilters(filters);
            movieIds.AddRange(genresResult.Ids);
            if (genresResult.FilterApplied)
            {
                appliedFiltersCount++;
            }

            // Get prod companies movie ids.
            var prodCompaniesResult = await GetProdCompanyFilters(filters);
            movieIds.AddRange(prodCompaniesResult.Ids);
            if (prodCompaniesResult.FilterApplied)
            {
                appliedFiltersCount++;
            }

            // Get popularity movie ids.
            var popularityResult = await GetPopularityFilters(filters);
            movieIds.AddRange(popularityResult.Ids);
            if (popularityResult.FilterApplied)
            {
                appliedFiltersCount++;
            }

            // If no filters applied or no movies matched, return empty result.
            if (appliedFiltersCount <= 0 || !movieIds.Any())
            {
                return new FilterResult();
            }

            // Group the movies by their id. This will help us to:
            // 1. Determine how many movies are in each group. We'll use this to calculate relevance.
            // 2. Prevent duplicate calls for db objects.
            var groupedIds = movieIds.GroupBy(_ => _)
                .Select(x => new { Id = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(take);

            // Load all of the movie data from the db.
            var movies = await dbContext.Movies
                .Where(m => groupedIds.Select(x => x.Id).Contains(m.Id))
                .Include(m => m.Directors)
                .Include(m => m.Casts)
                .Include(m => m.Genres)
                .Include(m => m.Keywords)
                .Include(m => m.Productioncompanies)
                .ToListAsync();

            // New up our result, passing in our movies.
            var filterResults = new FilterResult
            {
                Movies = movies
            };

            // Calculate the relevance by counting how many times a movie was in a group,
            // and divide that by number of applied filters. For example, if a movie appears twice
            // in it's group, and there 4 applied filters, it would have a relavance of .5.
            foreach (var item in groupedIds)
            {
                var movie = movies.FirstOrDefault(x => x.Id == item.Id);

                if (movie != null)
                {
                    filterResults.Relevances.Add(item.Id, item.Count / (double)appliedFiltersCount);
                }
            }

            return filterResults;
        }

        /*
         * With the exception of popularity, all of these are similar. See if the filters object contains that filter,
         * and query the database if it does. Then return the results back to the caller.
         */
        private async Task<FilterExecutionResult> GetReleaseYearFilters(Dictionary<string, List<string>> filters)
        {
            var result = new FilterExecutionResult();

            if (filters.TryGetValue("requestedReleaseYearFilters", out var releaseYearFilters) && releaseYearFilters.Any())
            {
                result.Ids = await dbContext.Movies
                    .Where(m => releaseYearFilters.Contains(m.ReleaseYear))
                    .Select(m => m.Id)
                    .ToListAsync();

                result.FilterApplied = true;
            }

            return result;
        }

        private async Task<FilterExecutionResult> GetCastFilters(Dictionary<string, List<string>> filters)
        {
            var result = new FilterExecutionResult();

            if (filters.TryGetValue("requestedCastFilters", out var castFilters) && castFilters.Any())
            {
                result.Ids = await dbContext.Casts
                    .Where(c => castFilters.Contains(c.Name))
                    .SelectMany(c => c.Movies)
                    .Select(m => m.Id)
                    .ToListAsync();

                result.FilterApplied = true;
            }

            return result;
        }

        private async Task<FilterExecutionResult> GetDirectorFilters(Dictionary<string, List<string>> filters)
        {
            var result = new FilterExecutionResult();

            if (filters.TryGetValue("requestedDirectorFilters", out var directorFilters) && directorFilters.Any())
            {
                result.Ids = await dbContext.Directors
                    .Where(c => directorFilters.Contains(c.Name))
                    .SelectMany(c => c.Movies)
                    .Select(m => m.Id)
                    .ToListAsync();

                result.FilterApplied = true;
            }

            return result;
        }

        private async Task<FilterExecutionResult> GetGenreFilters(Dictionary<string, List<string>> filters)
        {
            var result = new FilterExecutionResult();

            if (filters.TryGetValue("requestedGenreFilters", out var genreFilters) && genreFilters.Any())
            {
                result.Ids = await dbContext.Genres
                    .Where(c => genreFilters.Contains(c.Name))
                    .SelectMany(c => c.Movies)
                    .Select(m => m.Id)
                    .ToListAsync();

                result.FilterApplied = true;
            }

            return result;
        }

        private async Task<FilterExecutionResult> GetProdCompanyFilters(Dictionary<string, List<string>> filters)
        {
            var result = new FilterExecutionResult();

            if (filters.TryGetValue("requestedProdCompanyFilters", out var prodCompanyFilters) && prodCompanyFilters.Any())
            {
                result.Ids = await dbContext.ProductionCompanies
                    .Where(c => prodCompanyFilters.Contains(c.Name))
                    .SelectMany(c => c.Movies)
                    .Select(m => m.Id)
                    .ToListAsync();

                result.FilterApplied = true;
            }

            return result;
        }

        private async Task<FilterExecutionResult> GetPopularityFilters(Dictionary<string, List<string>> filters)
        {
            var result = new FilterExecutionResult();

            if (filters.TryGetValue("requestedPopularityFilters", out var popularityFilters) && popularityFilters.Any())
            {
                // Filter comes from frontend like this: "2.0 - 2.5", so we have to split those apart.
                // Also because there can be multiple filters, we have to dynamically build a SQL WHERE
                // query using OR.

                var sb = new StringBuilder();
                sb.Append("SELECT Id FROM Movies");

                bool firstFilterCompleted = false;

                foreach (var filter in popularityFilters)
                {
                    // Get each side of the '-'.
                    var values = filter.Split('-');

                    // If there isn't 2 results, something bad happended and continue in loop.
                    if (values.Count() != 2)
                    {
                        continue;
                    }

                    // If both values can be parsed to a double...
                    if (double.TryParse(values[0], out var min) && double.TryParse(values[1], out var max))
                    {
                        // Add to the qurey depending on if it's the first one or not.
                        if (firstFilterCompleted)
                        {
                            sb.Append(" OR");
                        }
                        else
                        {
                            sb.Append(" WHERE");
                        }

                        sb.Append($" Popularity BETWEEN {min} AND {max}");
                        firstFilterCompleted = true;
                    }
                }

                result.Ids = await dbContext.Movies
                    .FromSqlRaw(sb.ToString())
                    .Select(m => m.Id)
                    .ToListAsync();

                result.FilterApplied = true;
            }

            return result;
        }
    }

    public class FilterExecutionResult
    {
        public List<int> Ids = new List<int>();
        public bool FilterApplied { get; set; }
    }
}
