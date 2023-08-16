using Libros.Models;

namespace Libros.Services;

public class LibreriaService: ILibreriaService
{
    LibrosContext context;

    public LibreriaService(LibrosContext contexto)
    {
        context = contexto;
    }

    public IEnumerable<Libreria> Mostrar()
    {
        return context.librerias;
    }

    public IEnumerable<Libreria> MostrarEditorialPaidos()
    {
        return context.librerias.Where(p=> p.Editorial=="Paidos");
    }

    public async Task Insertar (Libreria libreria)
    {
        await context.AddAsync(libreria);
        context.SaveChanges();
    }

    public async Task Delete(int codigo)
    {
        var libroActual = context.librerias.Find(codigo);

        if(libroActual != null)
        {
            context.Remove(libroActual);
            await context.SaveChangesAsync();
        }  
    }
}

public interface ILibreriaService
{
    IEnumerable<Libreria> Mostrar();
    IEnumerable<Libreria> MostrarEditorialPaidos();
    Task Insertar (Libreria libreria);
    Task Delete(int codigo);
}

