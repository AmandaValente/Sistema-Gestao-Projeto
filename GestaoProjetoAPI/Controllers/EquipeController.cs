using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace GestaoProjetoAPI.Controllers
{

    [RoutePrefix("api/v1/equipes")]
    public class EquipeController : ApiController
    {
        private readonly EquipeRepository _equipeRepository;
        private readonly MembroEquipeRepository _membroEquipeRepository;

        public EquipeController()
        {
            _equipeRepository = new EquipeRepository();
            _membroEquipeRepository = new MembroEquipeRepository();
        }

        // GET api/v1/equipes
        [HttpGet]
        [Route("")]
        public IHttpActionResult ListarTodas()
        {
            
            var equipes = _equipeRepository.ListarTodas();
            if (equipes.Any())
                return Ok(equipes);

            return NotFound();
        }

        // GET api/v1/equipes/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            var equipe = _equipeRepository.BuscarPorId(id);

            if (equipe != null)
                return Ok(equipe);

            return NotFound();
        }
        [HttpGet]
        [Route("nome/{nome}")]
        public IHttpActionResult BuscarPorNome(string nome)
        {
            try
            {
                var equipe = _equipeRepository.BuscarPorNome(nome);

                if (equipe == null)
                {
                    return NotFound();
                }

                return Ok(equipe);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao buscar equipe: {ex.Message}");
            }

        }

        // POST api/v1/equipes
        [HttpPost]
        [Route("")]
        public IHttpActionResult Adicionar([FromBody] EquipeModels equipe)
        {
            if (equipe == null)
                return BadRequest("Equipe não pode ser nula.");

            _equipeRepository.Adicionar(equipe);
            return CreatedAtRoute("DefaultApi", new { id = equipe.EquipeId }, equipe);
        }

        // PUT api/v1/equipes/{id}
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Atualizar(int id, [FromBody] EquipeModels equipe)
        {
            if (id != equipe.EquipeId || equipe == null)
                return BadRequest("ID da equipe não corresponde ao ID do corpo da requisição.");

            _equipeRepository.Atualizar(equipe);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/v1/equipes/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Excluir(int id)
        {
            var equipe = _equipeRepository.BuscarPorId(id);
            if (equipe == null)
                return NotFound();

            _membroEquipeRepository.ExcluirMembros(id);
            _equipeRepository.Excluir(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
