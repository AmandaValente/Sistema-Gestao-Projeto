using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProjetoAPI.Services
{
    public class EquipeService
    {
        private readonly EquipeRepository _equipeRepository;

        public EquipeService()
        {
            _equipeRepository = new EquipeRepository();
        }

        public void AdicionarEquipe(EquipeModels equipe)
        {
            _equipeRepository.Adicionar(equipe);
        }

        public EquipeModels ObterEquipePorId(int id)
        {
            return _equipeRepository.BuscarPorId(id);
        }

        public void AtualizarEquipe(EquipeModels equipe)
        {
            _equipeRepository.Atualizar(equipe);
        }

        public void ExcluirEquipe(int id)
        {
            _equipeRepository.Excluir(id);
        }
    }
}