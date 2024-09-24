﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoFront.Models
{
    public class TarefaModels
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Prioridade { get; set; }
        public string StatusTarefa { get; set; }
        public int ProjetoId { get; set; }
        public int? ResponsavelId { get; set; }
    }
}