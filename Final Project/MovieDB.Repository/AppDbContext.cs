using Microsoft.EntityFrameworkCore;
using MovieDB.Core.Models;
using System.Reflection;

namespace MovieDB.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Award> Awards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieAward> MoviesAwards { get; set; }
        public DbSet<AwardType> AwardsType { get; set; }
        public DbSet<MovieCategory> MoviesCategories { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MoviePerformer> MoviePerformers { get; set; }
        public DbSet<MovieProducer> MovieProducers { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Popularity> Populatiries { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
