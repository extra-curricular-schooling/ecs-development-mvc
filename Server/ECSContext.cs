using System;
using ecs_dev_server.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ecs_dev_server.ECSContext
{
    public class ECSContext : DBContext
    {
        public ECSContext() : base("ECSContext")
        {
        }

        public DBSet<Account> Accounts { get; set; }

        public DBSet<AccountType> AccountTypes { get; set; }

        public DBSet<InterestTag> InterestTags { get; set; }

        public DBSet<SecurityQuestion> SecurityQuestions { get; set; }

        public DBSet<SweepStakeEntry> SweepStakeEntries { get; set; }

        public DBSet<SweepStakes> SweepStakes { get; set; }

        public DBSet<User> Users { get; set; }

        public DBSet<ZipLocation> ZipLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}