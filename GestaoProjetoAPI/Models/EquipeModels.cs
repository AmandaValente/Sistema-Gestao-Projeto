using System.Collections.Generic;

namespace GestaoProjetoAPI.Models
{
    public class EquipeModels
    {
        public int EquipeId { get; set; }
        public string Nome { get; set; }

        // Relacionamentos
        public ICollection<MembroEquipeModels> Membros { get; set; }
        public ICollection<ProjetoModels> Projetos { get; set; }
    }
}