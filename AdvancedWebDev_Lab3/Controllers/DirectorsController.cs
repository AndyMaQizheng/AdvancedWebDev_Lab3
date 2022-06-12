using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DirectorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all directors.
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> GetAllDirectors()
        {
            var directors = await unitOfWork.DirectorRepo.GetAllDirectorsAsync();

            return Ok(directors);
        }
    }
}
