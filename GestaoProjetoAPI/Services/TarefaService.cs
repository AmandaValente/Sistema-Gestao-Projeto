using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoAPI.Services
{
    public class TarefaService
    {
        private readonly TarefaRepository _tarefaRepository;

        public TarefaService()
        {
            _tarefaRepository = new TarefaRepository();
        }

        public void CriarTarefa(TarefaModels tarefa)
        {
            
            if (string.IsNullOrEmpty(tarefa.Nome))
            {
                throw new ArgumentException("O nome da tarefa é obrigatório.");
            }

            
            _tarefaRepository.Adicionar(tarefa);
        }

        public TarefaModels ObterTarefaPorId(int id)
        {
            return _tarefaRepository.BuscarPorId(id);
        }

        public void AtualizarTarefa(TarefaModels tarefa)
        {
            _tarefaRepository.Atualizar(tarefa);
        }

        public void ExcluirTarefa(int id)
        {
            _tarefaRepository.Excluir(id);
        }
    }
}