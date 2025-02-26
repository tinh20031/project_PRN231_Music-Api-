﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_music.Data;

#nullable disable

namespace api_music.Data.Migrations
{
    [DbContext(typeof(ApiMusicDbContext))]
    [Migration("20250225161804_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_music.Models.Album", b =>
                {
                    b.Property<int>("AlbumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumID"));

                    b.Property<string>("ArtistID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumID");

                    b.HasIndex("ArtistID");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumID = 1,
                            ArtistID = "1",
                            ImageURL = "https://example.com/divide.jpg",
                            ReleaseYear = 2017,
                            Title = "Divide"
                        },
                        new
                        {
                            AlbumID = 2,
                            ArtistID = "2",
                            ImageURL = "https://example.com/afterhours.jpg",
                            ReleaseYear = 2020,
                            Title = "After Hours"
                        });
                });

            modelBuilder.Entity("api_music.Models.Artist", b =>
                {
                    b.Property<string>("ArtistID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpotifyURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistID");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistID = "1",
                            Country = "vn",
                            Name = "Taylor Swift",
                            SpotifyURL = "dsfj"
                        },
                        new
                        {
                            ArtistID = "2",
                            Country = "vn",
                            Name = "Ed Sheeran",
                            SpotifyURL = "dd"
                        });
                });

            modelBuilder.Entity("api_music.Models.Artist_Song", b =>
                {
                    b.Property<string>("ArtistID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArtistID1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.HasKey("ArtistID");

                    b.HasIndex("ArtistID1");

                    b.HasIndex("SongID");

                    b.ToTable("Artist_Songs");
                });

            modelBuilder.Entity("api_music.Models.Favorite_Playlist", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FavoritedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID", "PlaylistID");

                    b.HasIndex("PlaylistID");

                    b.ToTable("Favorite_Songs");
                });

            modelBuilder.Entity("api_music.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("api_music.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PlaylistID");

                    b.HasIndex("UserID");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("api_music.Models.Playlist_Song", b =>
                {
                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SongID", "PlaylistID");

                    b.HasIndex("PlaylistID");

                    b.ToTable("Playlists_Songs");
                });

            modelBuilder.Entity("api_music.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpotifyURL")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("api_music.Models.Streaming_History", b =>
                {
                    b.Property<int>("HistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryID"));

                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("HistoryID");

                    b.HasIndex("SongID");

                    b.HasIndex("UserID");

                    b.ToTable("Streaming_History");
                });

            modelBuilder.Entity("api_music.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "tinh@gmail.com",
                            Password = "123",
                            UserName = "tinh"
                        });
                });

            modelBuilder.Entity("api_music.Models.User_Likes", b =>
                {
                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<int>("Song_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LikeAt")
                        .HasColumnType("datetime2");

                    b.HasKey("User_ID", "Song_ID");

                    b.HasIndex("Song_ID");

                    b.ToTable("User_Likes");
                });

            modelBuilder.Entity("api_music.Models.User_RecentlyPlayed", b =>
                {
                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlayedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SongID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("User_RecentlyPlayed");
                });

            modelBuilder.Entity("api_music.Models.Album", b =>
                {
                    b.HasOne("api_music.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("api_music.Models.Artist_Song", b =>
                {
                    b.HasOne("api_music.Models.Artist", "Artist")
                        .WithMany("Artist_Songs")
                        .HasForeignKey("ArtistID1");

                    b.HasOne("api_music.Models.Song", "Song")
                        .WithMany("Artist_Songs")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("api_music.Models.Favorite_Playlist", b =>
                {
                    b.HasOne("api_music.Models.Playlist", "Playlist")
                        .WithMany("Favorite_Playlists")
                        .HasForeignKey("PlaylistID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_music.Models.User", "User")
                        .WithMany("Favorite_Playlist")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_music.Models.Playlist", b =>
                {
                    b.HasOne("api_music.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_music.Models.Playlist_Song", b =>
                {
                    b.HasOne("api_music.Models.Playlist", "Playlist")
                        .WithMany("Playlist_Songs")
                        .HasForeignKey("PlaylistID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_music.Models.Song", "Song")
                        .WithMany("Playlists_Songs")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("api_music.Models.Song", b =>
                {
                    b.HasOne("api_music.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_music.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("api_music.Models.Streaming_History", b =>
                {
                    b.HasOne("api_music.Models.Song", "Song")
                        .WithMany("Streaming_History")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_music.Models.User", "User")
                        .WithMany("Streaming_History")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Song");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_music.Models.User_Likes", b =>
                {
                    b.HasOne("api_music.Models.Song", "Song")
                        .WithMany("User_Likes")
                        .HasForeignKey("Song_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_music.Models.User", "User")
                        .WithMany("User_Likes")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Song");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_music.Models.User_RecentlyPlayed", b =>
                {
                    b.HasOne("api_music.Models.Song", "Song")
                        .WithMany("User_RecentlyPlayed")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_music.Models.User", "User")
                        .WithMany("User_RecentlyPlayeds")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Song");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_music.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("api_music.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Artist_Songs");
                });

            modelBuilder.Entity("api_music.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("api_music.Models.Playlist", b =>
                {
                    b.Navigation("Favorite_Playlists");

                    b.Navigation("Playlist_Songs");
                });

            modelBuilder.Entity("api_music.Models.Song", b =>
                {
                    b.Navigation("Artist_Songs");

                    b.Navigation("Playlists_Songs");

                    b.Navigation("Streaming_History");

                    b.Navigation("User_Likes");

                    b.Navigation("User_RecentlyPlayed");
                });

            modelBuilder.Entity("api_music.Models.User", b =>
                {
                    b.Navigation("Favorite_Playlist");

                    b.Navigation("Playlists");

                    b.Navigation("Streaming_History");

                    b.Navigation("User_Likes");

                    b.Navigation("User_RecentlyPlayeds");
                });
#pragma warning restore 612, 618
        }
    }
}
