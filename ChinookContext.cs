using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChinookContext{
    public class ChinookDatabase : DbContext{
        public DbSet<Album>Albums{get; set;}
        public DbSet<Artist>Artists{get; set;}
        public DbSet<Track>Tracks{get; set;}

        public DbSet<Genre>Genres{get; set;}
        public DbSet<MediaType>Media_Types{get; set;}
        public DbSet<InvoiceItem>Invoice_Items{get; set;}
        public DbSet<Playlist>Playlists{get; set;}
        public DbSet<PlaylistTrack>Playlist_Track{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Filename=chinook.db");
        }
    }
}