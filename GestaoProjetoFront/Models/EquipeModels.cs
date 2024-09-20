using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoFront.Models
{
    public class EquipeModels
    {
            public int EquipeId { get; set; }
            public string Nome { get; set; }

            // Relacionamentos
          // public ICollection<MembroEquipeModels> Membros { get; set; }
            public ICollection<ProjetoModels> Projetos { get; set; }
        }
    }
