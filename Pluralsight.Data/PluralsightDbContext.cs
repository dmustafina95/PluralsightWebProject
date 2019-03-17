using Microsoft.EntityFrameworkCore;
using Pluralsight.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.Data
{
    public class PluralsightDbContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; }

        public PluralsightDbContext(DbContextOptions<PluralsightDbContext> options)
            : base(options)
        {

        }

    }
}
