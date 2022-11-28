
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IPalestrantePersist
    {
        // Palestrantes
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includesEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includesEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includesEventos);

    }
}