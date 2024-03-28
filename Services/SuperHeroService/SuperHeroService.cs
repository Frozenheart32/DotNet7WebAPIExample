using DotNet7WebAPIExample.Models;

namespace DotNet7WebAPIExample.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private static List<SuperHero> _superHeroes = new List<SuperHero>()
    {
        new SuperHero(){Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "NY"},
        new SuperHero(){Id = 2, Name = "Iron Man", FirstName = "Tony", LastName = "Stark", Place = "Malibu"},
    };
    
    public List<SuperHero> GetAllHeroes()
    {
        return _superHeroes;
    }

    public SuperHero? GetSingleHero(int id)
    {
        return _superHeroes.FirstOrDefault(x => x.Id == id);
    }

    public List<SuperHero> AddHero(SuperHero newHero)
    {
        _superHeroes.Add(newHero);
        return _superHeroes;
    }

    public List<SuperHero>? UpdateHero(int id, SuperHero request)
    {
        var hero = _superHeroes.FirstOrDefault(x => x.Id == id);
        if (hero is null)
        {
            return null;
        }

        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Name = request.Name;
        hero.Place = request.Place;

        return _superHeroes;
    }

    public List<SuperHero>? DeleteHero(int id)
    {
        var hero = GetSingleHero(id);
        if (hero is null)
        {
            return null;
        }
        _superHeroes.Remove(hero);

        return _superHeroes;
    }
}