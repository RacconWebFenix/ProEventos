
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string descricao { get; set; }
        public string imagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public ICollection<RedeSocial> RedesSociais { get; set; }
        public ICollection<PalestranteEvento> PalestrantesEventos { get; set; }

    }
}