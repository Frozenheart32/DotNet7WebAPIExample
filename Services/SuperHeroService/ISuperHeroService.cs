using DotNet7WebAPIExample.Models;

namespace DotNet7WebAPIExample.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllHeroes();
    Task<SuperHero?> GetSingleHero(int id);
    Task<List<SuperHero>> AddHero(SuperHero newHero);
    Task<List<SuperHero>?> UpdateHero(int id, SuperHero request);
    Task<List<SuperHero>?> DeleteHero(int id);
}