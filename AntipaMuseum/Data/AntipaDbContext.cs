using AntipaMuseum.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace AntipaMuseum.Data
{
    public  class AntipaDbContext: DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public AntipaDbContext(DbContextOptions<AntipaDbContext> options)
            :base(options)
        {

        }
    }
}