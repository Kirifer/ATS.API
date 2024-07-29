﻿using Ats.Core.Database;
using Ats.Core.Database.Abstraction;
using Ats.Core.Database.Abstraction.Interface;
using Ats.Datalayer.Entities;

using Microsoft.EntityFrameworkCore;

namespace Ats.Datalayer
{
    public class AtsDbContext : DbContextBase
    {
        public DbSet<User> Users { get; set; }

        public DbSet<JobList> JobLists { get; set; }

        public DbSet<Recruitment> Recruitments { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public AtsDbContext(DbContextOptions<DbContextBase> options)
           : base(options)
        {
        }

        public AtsDbContext(IDbConfig dbConfig, IDbUserContext dbUserContext, IDbMigration dbMigration)
            : base(dbConfig, dbUserContext, dbMigration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
