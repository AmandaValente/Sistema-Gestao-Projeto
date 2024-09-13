using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoAPI.Services
{
    public class ProjetoService
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetoService()
        {
            _projetoRepository = new ProjetoRepository();
        }

        public void AdicionarProjeto(ProjetoModels projeto)
        {
            _projetoRepository.Adicionar(projeto);
        }

        public ProjetoModels ObterProjetoPorId(int id)
        {
            return _projetoRepository.BuscarPorId(id);
        }

        public void AtualizarProjeto(ProjetoModels projeto)
        {
            _projetoRepository.Atualizar(projeto);
        }

        public void ExcluirProjeto(int id)
        {
            _projetoRepository.Excluir(id);
        }
    }
}