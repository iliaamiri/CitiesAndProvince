using CitiesAndProvince.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesAndProvince.Data;

public class CitiesProvinceDbContext : DbContext
{
    public CitiesProvinceDbContext(DbContextOptions<CitiesProvinceDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Province>().Property(p => p.ProvinceCode).IsRequired();

        builder.Entity<City>().Property(c => c.CityName).IsRequired();

        builder.Entity<Province>().ToTable("Team");
        builder.Entity<City>().ToTable("City");

        builder.Seed();
    }

    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
}