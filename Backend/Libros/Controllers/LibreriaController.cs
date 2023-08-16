using Libros.Models;
using Libros.Services;
using Microsoft.AspNetCore.Mvc;

namespace Libros.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class LibreriaController : ControllerBase
{
    ILibreriaService service;

    public LibreriaController(ILibreriaService servicio)
    {
        service = servicio;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.Mostrar());
    }

    [HttpGet]
    [Route("{action}")]
    public IActionResult GetPaidos()
    {
        return Ok(service.MostrarEditorialPaidos());
    }

    [HttpPost]
    [Route("{action}")]
    public IActionResult Post(Libreria libreria)
    {
        service.Insertar(libreria);
        return Ok();
    }

    [HttpDelete("{codigo}")]
    public IActionResult Delete(int codigo)
    {
        service.Delete(codigo);
        return Ok();
    }    
}