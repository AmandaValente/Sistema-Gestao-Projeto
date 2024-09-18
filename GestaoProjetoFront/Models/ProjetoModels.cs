using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoFront.Models
{
            public class ProjetoModels
        {
            public int ProjetoId { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime? DataFim { get; set; }
            public string StatusProjeto { get; set; }
            public int EquipeId { get; set; }

            // Relacionamento com a equipe
           // public EquipeModels Equipe { get; set; }

            // Relacionamento com tarefas
            //public ICollection<TarefaModels> Tarefas { get; set; } = new List<TarefaModels>();
        }
    
}
