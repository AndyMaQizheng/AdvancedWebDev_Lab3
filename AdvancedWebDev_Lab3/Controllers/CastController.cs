using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CastController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCast()
        {
            var cast = await unitOfWork.CastRepo.GetAllCastAsync();

            return Ok(cast);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cast = await unitOfWork.CastRepo.GetCastByIdAsync(id);

            return Ok(cast);
        }
    }
}
