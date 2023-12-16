using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Infra.Data.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaltaDesafioBlazor.Infra.Data;

public class DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : IdentityDbContext(options)
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<Locality> Localities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(LocalityMap).Assembly);
    }
}
