﻿using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebDev_Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public GenresController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await unitOfWork.GenreRepo.GetAllGenresAsync();

            return Ok(genres);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await unitOfWork.GenreRepo.GetGenreByIdAsync(id);

            return Ok(genre);
        }
    }
}
