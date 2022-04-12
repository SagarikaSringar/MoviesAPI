using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoviesAPI.Models
{
    public partial class MoviesDBContext : DbContext
    {
        public MoviesDBContext()
        {
        }

        public MoviesDBContext(DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<MovieCasting> MovieCasting { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Producers> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=moviesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId);

                entity.Property(e => e.ActorId).HasColumnName("actorId");

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasColumnName("actorName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieCasting>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId });

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.ActorId).HasColumnName("actorId");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.DateOfRelease)
                    .HasColumnName("dateOfRelease")
                    .HasColumnType("date");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movieName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerId).HasColumnName("producerId");
            });

            modelBuilder.Entity<Producers>(entity =>
            {
                entity.HasKey(e => e.ProducerId);

                entity.Property(e => e.ProducerId).HasColumnName("producerId");

                entity.Property(e => e.ProducerName)
                    .IsRequired()
                    .HasColumnName("producerName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
