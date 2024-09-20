using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;

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
        public EquipeModels BuscarPorNome(string nome)
        {
            return _equipeRepository.BuscarPorNome(nome);
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