using Libros;
using Microsoft.AspNetCore.Mvc;

namespace Remodelacion.Controllers;

[ApiController]
[Route("Api/[controller]")]

public class CreateController:ControllerBase
{
    LibrosContext context;

    public CreateController(LibrosContext contexto)
    {
        context = contexto;
    }

    [HttpGet]
    public IActionResult Crear()
    {
        context.Database.EnsureCreated();
        return Ok();
    }
}
