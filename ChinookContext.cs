using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChinookContext{
    public class ChinookDatabase : DbContext{
        public DbSet<Albums>Albums{get; set;}
        public DbSet<Artists>Artists{get; set;}
        public DbSet<Tracks>Tracks{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Filename=chinook.db");
        }
    }
}