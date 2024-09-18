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

        public void Adicionar(ProjetoModels projeto)
        {
            _projetoRepository.Adicionar(projeto);
        }

        public ProjetoModels BuscarPorId(int id)
        {
            return _projetoRepository.BuscarPorId(id);
        }

        public ProjetoModels BuscarPorNome(string nome)
        {
            return _projetoRepository.BuscarPorNome(nome);
        }


        public void Atualizar(ProjetoModels projeto)
        {
            _projetoRepository.Atualizar(projeto);
        }

        public void Excluir(int id)
        {
            _projetoRepository.Excluir(id);
        }
    }
}