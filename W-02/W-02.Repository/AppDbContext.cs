using Microsoft.EntityFrameworkCore;
using System.Reflection;
using W_02.Core.Models;

namespace W_02.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
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
