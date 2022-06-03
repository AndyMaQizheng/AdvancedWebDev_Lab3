using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public KeywordsController(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKeywords()
        {
            var keywords = await unitOfWork.KeywordRepo.GetAllKeywordsAsync();

            return Ok(keywords);
        }
    }
}
