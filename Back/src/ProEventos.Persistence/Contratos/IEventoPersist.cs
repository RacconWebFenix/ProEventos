
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IEventoPersist
    {
        // Eventos
        Task<Evento[]> GetAllEventosAsync(bool includesPalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includesPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includesPalestrantes = false);
    }
}