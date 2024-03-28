using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet7WebAPIExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> _superHeroes = new List<SuperHero>()
        {
            new SuperHero(){Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "NY"},
            new SuperHero(){Id = 2, Name = "Iron Man", FirstName = "Tony", LastName = "Stark", Place = "Malibu"},
        };
            
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(_superHeroes);
        }
        
        [HttpGet]
        [Route("GetSingleHero/{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = _superHeroes.FirstOrDefault(x => x.Id == id);
            if (hero is null)
            {
                return NotFound();
            }
            
            return Ok(hero);
        }
    }
}
