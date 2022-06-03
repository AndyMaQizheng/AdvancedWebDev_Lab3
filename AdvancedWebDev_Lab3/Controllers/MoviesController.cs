using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await unitOfWork.Movies.GetAllMoviesAsync();

            return Ok(movies);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await unitOfWork.Movies.GetMovieByIdAsync(id);

            return Ok(movie);
        }

        [HttpGet("keyword/{keyword}")]
        public async Task<IActionResult> GetByKeyword(string keyword)
        {
            var movies = await unitOfWork.Movies.GetMoviesByKeywordAsync(keyword);

            return Ok(movies);
        }
    }
}
