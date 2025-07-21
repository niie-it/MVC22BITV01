using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DemoMidTerm.Models;

namespace DemoMidTerm.Data;

public partial class Mvc22bitv01TestContext : DbContext
{
    public Mvc22bitv01TestContext()
    {
    }

    public Mvc22bitv01TestContext(DbContextOptions<Mvc22bitv01TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__70DAFC340A5E6C62");

            entity.ToTable("Author");

            entity.Property(e => e.Bio).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C2077CF53724");

            entity.ToTable("Book");

            entity.Property(e => e.CoverImagePath).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Book__AuthorId__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<DemoMidTerm.Models.AuthorVM> AuthorVM { get; set; } = default!;
}
