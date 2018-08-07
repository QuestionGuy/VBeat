﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using VBeat.Models;

namespace VBeat.Migrations
{
    [DbContext(typeof(VBeatDbContext))]
    partial class ArtistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VBeat.Models.BridgeModel.ArtistShowModel", b =>
                {
                    b.Property<int>("ShowId");

                    b.Property<int>("UserId");

                    b.HasKey("ShowId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ArtistShowModel");
                });

            modelBuilder.Entity("VBeat.Models.BridgeModel.ArtistSongModel", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("UserId");

                    b.HasKey("SongId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ArtistSongModel");
                });

            modelBuilder.Entity("VBeat.Models.BridgeModel.PlaylistSongModel", b =>
                {
                    b.Property<int>("PlaylistId");

                    b.Property<int>("SongId");

                    b.HasKey("PlaylistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongModel");
                });

            modelBuilder.Entity("VBeat.Models.PlaylistModel", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlaylistImage");

                    b.Property<string>("PlaylistName");

                    b.Property<bool>("Public");

                    b.Property<int?>("UserModelUserId");

                    b.HasKey("PlaylistId");

                    b.HasIndex("UserModelUserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("VBeat.Models.ShowModel", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("HouseNumber");

                    b.Property<string>("ShowName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("ShowTime");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ShowId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("VBeat.Models.SongModel", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("SongImagePath")
                        .IsRequired();

                    b.Property<string>("SongName")
                        .IsRequired();

                    b.Property<string>("SongPath")
                        .IsRequired();

                    b.HasKey("SongId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("VBeat.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<DateTime>("TimeOfLastLogin");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserModel");
                });

            modelBuilder.Entity("VBeat.Models.ArtistModel", b =>
                {
                    b.HasBaseType("VBeat.Models.UserModel");

                    b.Property<string>("ArtistImage");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.ToTable("ArtistModel");

                    b.HasDiscriminator().HasValue("ArtistModel");
                });

            modelBuilder.Entity("VBeat.Models.BridgeModel.ArtistShowModel", b =>
                {
                    b.HasOne("VBeat.Models.ShowModel", "Show")
                        .WithMany("ArtistList")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VBeat.Models.ArtistModel", "Artist")
                        .WithMany("Shows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VBeat.Models.BridgeModel.ArtistSongModel", b =>
                {
                    b.HasOne("VBeat.Models.SongModel", "Song")
                        .WithMany("ArtistList")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VBeat.Models.ArtistModel", "Artist")
                        .WithMany("SongList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VBeat.Models.BridgeModel.PlaylistSongModel", b =>
                {
                    b.HasOne("VBeat.Models.PlaylistModel", "Playlist")
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VBeat.Models.SongModel", "Song")
                        .WithMany("Playlists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VBeat.Models.PlaylistModel", b =>
                {
                    b.HasOne("VBeat.Models.UserModel", "UserModel")
                        .WithMany("SavedPlaylists")
                        .HasForeignKey("UserModelUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
