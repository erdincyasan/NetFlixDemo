using Microsoft.EntityFrameworkCore;
using Netflix.DataAccess.Configurations;
using Netflix.Entities;

namespace Netflix.DataAccess
{
    public class NetflixDbContext : DbContext
    {
        public NetflixDbContext(DbContextOptions<NetflixDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MovieCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

    }
}
