using LibrosService.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrosService.Data;

public class LibrosDbContext : DbContext
{
    public LibrosDbContext(DbContextOptions<LibrosDbContext> options)
        : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Nombre).IsRequired().HasMaxLength(120);
            entity.Property(a => a.Nacionalidad).HasMaxLength(80);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Titulo).IsRequired().HasMaxLength(150);
            entity.Property(l => l.ISBN).IsRequired().HasMaxLength(20);
            entity.Property(l => l.Categoria).IsRequired().HasMaxLength(80);
            entity.HasIndex(l => l.ISBN).IsUnique();

            entity.HasOne(l => l.Autor)
                  .WithMany(a => a.Libros)
                  .HasForeignKey(l => l.AutorId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
