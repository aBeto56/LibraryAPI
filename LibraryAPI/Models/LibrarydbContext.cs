using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }
    

    public virtual DbSet<Book> Books { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.Author_id, "author_id");

            entity.HasIndex(e => e.Category_id, "category_id");

            entity.Property(e => e.BookId)
                .HasColumnType("int(11)")
                .HasColumnName("book_id");
            entity.Property(e => e.Author_id)
                .HasColumnType("int(11)")
                .HasColumnName("author_id");
            entity.Property(e => e.Category_id)
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.PublishDate)
                .HasColumnType("date")
                .HasColumnName("publish_date");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
