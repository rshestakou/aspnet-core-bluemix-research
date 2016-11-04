﻿using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBluemixResearch.Web.Models
{
  public class MobileContext : DbContext
  {
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Order> Orders { get; set; }

    public MobileContext(DbContextOptions<MobileContext> options)
        : base(options)
    {
    }
  }
}
