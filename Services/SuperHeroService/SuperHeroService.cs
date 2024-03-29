using DotNet7WebAPIExample.Data;
using DotNet7WebAPIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet7WebAPIExample.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetAllHeroes()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<SuperHero?> GetSingleHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        return hero;
    }

    public async Task<List<SuperHero>> AddHero(SuperHero newHero)
    {
        await _context.SuperHeroes.AddAsync(newHero);
        await _context.SaveChangesAsync();

        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Name = request.Name;
        hero.Place = request.Place;

        await _context.SaveChangesAsync();

        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<List<SuperHero>?> DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return null;
        }
        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();

        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }
}