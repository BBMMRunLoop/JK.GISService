using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessMysqlProvider
{
    public class DomainModelMysqlContext : DbContext
    {

        public DomainModelMysqlContext(DbContextOptions<DomainModelMysqlContext> options) : base(options) {

        }

        public DbSet<tabBaseInfo> tabBaseInfo { get; set; }
        public DbSet<tabProjectInfo> tabProjectInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<tabBaseInfo>().HasKey(m => m.id);
            builder.Entity<tabProjectInfo>().HasKey(m => m.id);

            base.OnModelCreating(builder);
        }
    }
}
