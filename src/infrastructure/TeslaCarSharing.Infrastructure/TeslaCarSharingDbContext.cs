using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Infrastructure;

public class TeslaCarSharingDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Car> Cars { get; set; }

    public TeslaCarSharingDbContext(DbContextOptions<TeslaCarSharingDbContext> options) : base(options)
    {      
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(message => Debug.WriteLine(message));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
