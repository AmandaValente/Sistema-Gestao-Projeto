﻿using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoAPI.Services
{
    public class MembroEquipeService
    {
        private readonly MembroEquipeRepository _membroRepository;

        public MembroEquipeService()
        {
            _membroRepository = new MembroEquipeRepository();
        }

        public void AdicionarMembro(MembroEquipeModels membro)
        {
            _membroRepository.Adicionar(membro);
        }

        public MembroEquipeModels ObterMembroPorId(int id)
        {
            return _membroRepository.BuscarPorId(id);
        }

        public void AtualizarMembro(MembroEquipeModels membro)
        {
            _membroRepository.Atualizar(membro);
        }

        public void ExcluirMembro(int id)
        {
            _membroRepository.Excluir(id);
        }

        public List<MembroEquipeModels> ListarPorEquipeId(int id)
        {
            try
            {
                var membrosIList = _membroRepository.ListarPorEquipeId(id);

                return membrosIList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar membros da equipe com ID {id}: {ex.Message}", ex);
            }
        }
    }

}
