using System;
using ecs_dev_server.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ecs_dev_server.ECSContext
{
    public class ECSContext : DbContext
    {
        public ECSContext() : base("ECSContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<InterestTag> InterestTags { get; set; }

        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        public DbSet<SweepStakeEntry> SweepStakeEntries { get; set; }

        public DbSet<SweepStakes> SweepStakes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ZipLocation> ZipLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}