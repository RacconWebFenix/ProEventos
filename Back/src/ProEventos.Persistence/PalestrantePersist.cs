using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventosAPI;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includesEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
            if (includesEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includesEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

            if (includesEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).AsNoTracking().Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includesEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

            if (includesEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(p => p.Id).AsNoTracking().Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
