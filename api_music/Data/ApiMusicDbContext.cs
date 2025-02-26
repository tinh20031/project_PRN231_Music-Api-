using api_music.Models;
using Microsoft.EntityFrameworkCore;

namespace api_music.Data
{
    public class ApiMusicDbContext : DbContext
    {
        public ApiMusicDbContext() { }
        public ApiMusicDbContext(DbContextOptions<ApiMusicDbContext> options) : base(options) { }


        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Artist_Song> Artist_Songs { get; set; }
        public virtual DbSet<Favorite_Playlist> Favorite_Songs { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Playlist_Song> Playlists_Songs { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Streaming_History> Streaming_History { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Likes> User_Likes { get; set; }
        public virtual DbSet<User_RecentlyPlayed> User_RecentlyPlayed { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                    .HasOne(s => s.Album)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(s => s.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
             .HasOne(s => s.Genre)
             .WithMany(g => g.Songs)
             .HasForeignKey(t => t.GenreID)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Album>()
     .HasOne(a => a.Artist)
     .WithMany(art => art.Albums)
     .HasForeignKey(a => a.ArtistID)
     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Playlist>()
    .HasOne(p => p.User)
    .WithMany(u => u.Playlists)
    .HasForeignKey(p => p.UserID)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Streaming_History>()
                .HasOne(sh => sh.User)
                .WithMany(u => u.Streaming_History)
                .HasForeignKey(sh => sh.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Streaming_History>()
                .HasOne(sh => sh.Song)
                .WithMany(s => s.Streaming_History)
                .HasForeignKey(sh => sh.SongID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favorite_Playlist>()
              .HasOne(f => f.User)
              .WithMany(u => u.Favorite_Playlist)
              .HasForeignKey(f => f.UserID)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favorite_Playlist>()
                .HasOne(f => f.Playlist)
                .WithMany(p => p.Favorite_Playlists)
                .HasForeignKey(f => f.PlaylistID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Favorite_Playlist>()
                .HasKey(f => new { f.UserID, f.PlaylistID });

            modelBuilder.Entity<Playlist_Song>()
                .HasOne(p => p.Song)
                .WithMany(s => s.Playlists_Songs)
                .HasForeignKey(t => t.SongID)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Playlist_Song>()
                .HasOne(p => p.Playlist)
                .WithMany(s => s.Playlist_Songs)
                .HasForeignKey(t => t.PlaylistID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Playlist_Song>()
                .HasKey(f => new { f.SongID, f.PlaylistID });


            modelBuilder.Entity<User_Likes>()
                .HasOne(p => p.User)
                .WithMany(u => u.User_Likes)
                .HasForeignKey(t => t.User_ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User_Likes>()
                .HasOne(p => p.Song)
                .WithMany(s => s.User_Likes)
                .HasForeignKey(t => t.Song_ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User_Likes>()
                .HasKey(f => new { f.User_ID, f.Song_ID });
            modelBuilder.Entity<User_RecentlyPlayed>()
                .HasOne(u => u.User)
                .WithMany(s => s.User_RecentlyPlayeds)
                .HasForeignKey(f => f.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User_RecentlyPlayed>()
                .HasOne(r => r.Song)
.WithMany(s => s.User_RecentlyPlayed)
.HasForeignKey(s => s.SongID)
.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User_RecentlyPlayed>()
                .HasKey(f => new { f.SongID, f.UserID });


            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Email = "tinh@gmail.com", Password = "123", UserName = "tinh", }


                );

            modelBuilder.Entity<Artist>().HasData(
             new Artist { ArtistID = "1", Name = "Taylor Swift", Country = "vn", SpotifyURL ="dsfj" },
             new Artist { ArtistID = "2", Name = "Ed Sheeran" ,Country = "vn", SpotifyURL ="dd"}
         );


            modelBuilder.Entity<Album>().HasData(
       new Album { AlbumID = 1, Title = "Divide", ReleaseYear = 2017, ArtistID = "1", ImageURL = "https://example.com/divide.jpg" },
       new Album { AlbumID = 2, Title = "After Hours", ReleaseYear = 2020, ArtistID = "2", ImageURL = "https://example.com/afterhours.jpg" }
   );

         








        }


    }
}
