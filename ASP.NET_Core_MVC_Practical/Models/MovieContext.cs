using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC_Practical.Models;

public partial class MovieContext : DbContext
{
    public MovieContext()
    {
    }

    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Movie;Integrated Security=True;Trust Server Certificate=True;");
        //}

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-C97SHFV;Initial Catalog=Movie;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK__Director__26C69E46B3357A6F");

            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.DirectorName).HasMaxLength(100);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385057E0EEB2CF1");

            entity.Property(e => e.GenreName).HasMaxLength(50);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2941A50544FC7");

            entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK_Director");

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Genre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
