using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoAPI.Models
{
    public class MembroEquipeModels
    {
        public int MembroId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int EquipeId { get; set; }

        // Relacionamento com a equipe
        public EquipeModels Equipe { get; set; }

        // Relacionamento com tarefas
        public ICollection<TarefaModels> Tarefas { get; set; }
    }
}