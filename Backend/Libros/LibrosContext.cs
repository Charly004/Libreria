using Libros.Models;
using Microsoft.EntityFrameworkCore;

namespace Libros;

public class LibrosContext: DbContext
{
    public DbSet<Libreria> librerias {get;set;}

    public LibrosContext(DbContextOptions<LibrosContext> options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libreria>(Libreria=>
        {
            Libreria.ToTable("Libreria");
            Libreria.HasKey(p=> p.CodigoLibro);
            Libreria.Property(p=>p.Titulo).HasMaxLength(100);
            Libreria.Property(p=>p.Imagen).HasMaxLength(500);
            Libreria.Property(p=>p.Categoria).HasMaxLength(100);
            Libreria.Property(p=>p.Autor).HasMaxLength(100);
            Libreria.Property(p=>p.Editorial).HasMaxLength(100);
        });
    }
}