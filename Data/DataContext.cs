﻿using DotNet7WebAPIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet7WebAPIExample.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true");
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
}