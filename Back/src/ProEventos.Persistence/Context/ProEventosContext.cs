

using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventosAPI
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(pe => new { pe.EventoId, pe.PalestranteId });


            modelBuilder.Entity<Evento>().HasMany<Lote>(s => s.Lotes).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evento>().HasMany<RedeSocial>(rs => rs.RedesSociais).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>().HasMany<RedeSocial>(rs => rs.RedesSociais).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}