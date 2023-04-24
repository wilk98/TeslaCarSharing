using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Infrastructure;

public class TeslaCarSharingContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public TeslaCarSharingContext(DbContextOptions<TeslaCarSharingContext> options) : base(options)
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
