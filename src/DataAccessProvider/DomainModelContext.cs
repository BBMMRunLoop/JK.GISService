using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DomainModel;

namespace DataAccessManager
{
    public class DomainModelContext : DbContext
    {

        public DomainModelContext(DbContextOptions<DomainModelContext> options) : base(options) {

        } 

        public DbSet<tabBaseInfo> tabBaseInfo { get; set; }
        public DbSet<tabProjectInfo> tabProjectInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<tabBaseInfo>().HasKey(m => m.id);
            builder.Entity<tabProjectInfo>().HasKey(m => m.id);

            base.OnModelCreating(builder);
        }


    }
}
