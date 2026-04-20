using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasMaxLength(24)
                .IsRequired();

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<Movie>()
                .Property(m => m.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Rating)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Budget)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Revenue)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Trailer>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Trailers)
                .HasForeignKey(t => t.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}