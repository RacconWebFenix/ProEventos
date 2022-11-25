using Microsoft.AspNetCore.Mvc;
using ProEventosAPI.Data;
using ProEventosAPI.Models;

namespace ProEventosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    private readonly DataContext _context;

    public EventoController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(e => e.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "exemplo post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"exemplo put = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"exemplo delete = {id}";
    }
}
