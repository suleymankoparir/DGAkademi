using ClassStudent.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClassStudent.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
