using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductionCompaniesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductionCompaniesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all production companies.
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> GetAllProductionCompanies()
        {
            var prodCompanies = await unitOfWork.ProdCompanyRepo.GetAllProductionCompaniesAsync();

            return Ok(prodCompanies);
        }
    }
}
