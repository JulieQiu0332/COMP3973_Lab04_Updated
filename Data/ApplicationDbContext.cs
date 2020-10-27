using System;
using System.Collections.Generic;
using System.Text;
using Lab04.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
