using Microsoft.EntityFrameworkCore;
using System.Reflection;
using W_01.Core.Models;

namespace W_01.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<BaseCar> BaseCars { get; set; }
        DbSet<Bmw> Bmw { get; set; }
        DbSet<Audi> Audi { get; set; }
        DbSet<Mercedes> Mercedes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
