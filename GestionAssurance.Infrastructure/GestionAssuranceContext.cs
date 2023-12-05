
using GestionAssurance.ApplicationCore.Domain;
using GestionAssurance.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GestionAssurance.Infrastructure
{
    public class GestionAssuranceContext : DbContext
    {
        public DbSet<Assurance> Assurances { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Sinistre> Sinistres { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AGS_ChalghoumiKaisSE;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssuranceConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertiseConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

    }
}