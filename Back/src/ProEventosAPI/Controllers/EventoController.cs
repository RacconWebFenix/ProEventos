using Microsoft.AspNetCore.Mvc;
using ProEventosAPI.Models;

namespace ProEventosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public IEnumerable<Evento> _evento = new Evento[] {
            new Evento()
        {
            EventoId = 1,
            Local = "Belo Horizonte",
            Tema = "Angular 11",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = $"{DateTime.Now.AddDays(2)}",
            ImagemURL = "c:\teste.jps",
        },
            new Evento()
        {
            EventoId = 2,
            Local = "São Paulo",
            Tema = "Angular 12",
            Lote = "2º Lote",
            QtdPessoas = 350,
            DataEvento = $"{DateTime.Now.AddDays(2)}",
            ImagemURL = "c:\teste.jpsadas",
        }
    };
    public EventoController()
    {
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(e => e.EventoId == id);
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
