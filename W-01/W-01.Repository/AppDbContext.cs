using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using W_01.Core.Models;

namespace W_01.Repository
{
    public class AppDbContext: DbContext
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
