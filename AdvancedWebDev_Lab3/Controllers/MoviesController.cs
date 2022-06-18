using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using AdvancedWebDev_Lab3.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public MoviesController(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all movies. Note that this call will be very slow.
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await unitOfWork.Movies.GetAllMoviesAsync();

            return Ok(movies);
        }       

        /// <summary>
        /// Get distinct list of release years.
        /// </summary>
        [HttpGet("releaseYears")]
        public async Task<IActionResult> GetReleaseYears()
        {
            var releaseYears = await unitOfWork.Movies.GetReleaseYearsAsync();

            return Ok(releaseYears);
        }

        /// <summary>
        /// Get list of movies that match ids.
        /// </summary>
        [HttpPost("getByMovieIds")]
        public async Task<IActionResult> GetMoviesByIdAsync(IEnumerable<int> movieIds)
        {
            var results = await unitOfWork.Movies.GetMoviesByIdsAsync(movieIds);

            var mappedMovies = mapper
                .Map<IEnumerable<Movie>>(results)
                .OrderBy(m => m.Title);

            return Ok(new ApiResponse<IEnumerable<Movie>>(mappedMovies));
        }

        /// <summary>
        /// Get list of filtered movies.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> GetFilteredMoviesAsync(FilterRequest filterRequest)
        {
            var filterResults = await unitOfWork.Movies.GetFilteredMoviesAsync(filterRequest.Filters, filterRequest.NumOfResults);

            var mappedMovies = mapper
                .Map<List<Movie>>(filterResults.Movies)
                .OrderByDescending(m => m.Relevance)
                .ThenBy(m => m.Title);

            foreach (var movie in mappedMovies)
            {
                movie.Relevance = filterResults.Relevances[movie.Id] * 100;
            }

            return Ok(new ApiResponse<IEnumerable<Movie>>(mappedMovies));
        }
    }
}
