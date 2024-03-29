﻿using Microsoft.EntityFrameworkCore;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Infrastructure;

public class TeslaCarSharingDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    public TeslaCarSharingDbContext(DbContextOptions options) : base(options)
    {      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}
