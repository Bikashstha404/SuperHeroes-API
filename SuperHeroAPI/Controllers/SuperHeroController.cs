using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
             new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "NewYork"
                },
             new SuperHero
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "NewYork"
                }
        };

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleHeroes(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero is null)
            {
                return NotFound("Sorry, but hero with the given id " + id + " doesn't exists.");
            }
            return Ok(hero);
        }

        [HttpPost]
        [Route("AddHero")]
        public async Task<IActionResult> AddHero([FromForm] SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut]
        [Route("UpdateHero")]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero is null)
            {
                return NotFound("Sorry, but hero with the given id " + id + " doesn't exists.");
            };
            
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name  = request.Name;  
            hero.Place = request.Place;

            return Ok(superHeroes);
        }

        [HttpDelete]
        [Route("DeleteHero")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return NotFound("Sorry, but hero with the given id " + id + " doesn't exists.");
            };
            superHeroes.Remove(hero);

            return Ok(superHeroes);
        }
    }
}
