using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var result = _superHeroService.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var result = _superHeroService.GetSingleHero(id);
            if(result is null)
            {
                return NotFound("Sorry, but hero with the given id " + id + " doesn't exists.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("AddHero")]
        public async Task<IActionResult> AddHero([FromForm] SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateHero")]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if(result is null)
            {
                return NotFound("Hero is not found");
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteHero")]
        public async Task<IActionResult> DeleteHero(int id)
        {
           var result = _superHeroService.DeleteHero(id);
            if(result == null)
            {
                return NotFound("Hero is not Found");
            }
            return Ok(result);
        }
    }
}
