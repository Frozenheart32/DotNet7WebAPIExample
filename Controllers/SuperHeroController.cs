using DotNet7WebAPIExample.Models;
using DotNet7WebAPIExample.Services.SuperHeroService;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7WebAPIExample.Controllers
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
        [Route("GetAllHeroes")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(_superHeroService.GetAllHeroes());
        }
        
        [HttpGet]
        [Route("GetSingleHero/{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = _superHeroService.GetSingleHero(id);
            if (hero is null)
            {
                return NotFound();
            }
            
            return Ok(hero);
        }
        
        [HttpPost]
        [Route("AddHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero newHero)
        {
            return Ok(_superHeroService.AddHero(newHero));
        }
        
        [HttpPut]
        [Route("UpdateHero/{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, [FromBody]SuperHero request)
        {
            var heroes = _superHeroService.UpdateHero(id, request);
            if (heroes is null)
            {
                return NotFound();
            }

            return Ok(heroes);
        }
        
        [HttpDelete]
        [Route("DeleteHero/{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroes = _superHeroService.DeleteHero(id);
            if (heroes is null)
            {
                return NotFound();
            }

            return Ok(heroes);
        }
    }
}
