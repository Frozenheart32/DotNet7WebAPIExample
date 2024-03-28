using DotNet7WebAPIExample.Models;

namespace DotNet7WebAPIExample.Services.SuperHeroService;

public interface ISuperHeroService
{
    List<SuperHero> GetAllHeroes();
    SuperHero? GetSingleHero(int id);
    List<SuperHero> AddHero(SuperHero newHero);
    List<SuperHero>? UpdateHero(int id, SuperHero request);
    List<SuperHero>? DeleteHero(int id);
}