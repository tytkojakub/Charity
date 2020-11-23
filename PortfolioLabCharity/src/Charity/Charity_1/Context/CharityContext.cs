using Charity.Models.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Context
{
    public class CharityContext : IdentityDbContext
    {
        public CharityContext(DbContextOptions<CharityContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Donation> Donations { get; set; }

    }
}
