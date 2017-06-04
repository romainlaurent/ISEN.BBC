using ISEN.BBC.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ISEN.BBC.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Ajouter les DbSets<> ici
        // ...
        public DbSet<Voyage> VoyageCollection { get; set; }
        public DbSet<Reservation> ReservationCollection { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Ajouter la définition des mappings d'entités avec les tables, et les relations ici
            // ...
            builder.Entity<Voyage>()
                .ToTable("Voyage");
            //.HasKey(p => p.Id);

            builder.Entity<Reservation>()
                .ToTable("Reservation");
        }
    }

    public class TempDbContextFactory :
        IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var dbContextBuilder = 
                new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextBuilder.UseSqlite("DataSource=.\\MyWebApp.db");
            return new ApplicationDbContext(dbContextBuilder.Options);
        }
    }
}
