using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace GestaoProjetoAPI.Controllers
{

    [RoutePrefix("api/v1/projeto")]
    public class ProjetoController : ApiController
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetoController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        // GET api/v1/projeto
        [HttpGet]
        [Route("")]
        public IEnumerable<ProjetoModels> ListarProjetos()
        {
            return _projetoRepository.ListarTodos();
        }

        // GET api/v1/projeto/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            try
            {
                var projeto = _projetoRepository.BuscarPorId(id);

                if (projeto == null)
                {
                    return NotFound();
                }

                return Ok(projeto); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar projeto: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("nome/{nome}")]
        public IHttpActionResult BuscarPorNome(string nome)
        {
            try
            {
                var projeto = _projetoRepository.BuscarPorNome(nome);

                if (projeto == null)
                {
                    return NotFound();
                }

                return Ok(projeto);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao buscar projeto: {ex.Message}");
            }

        }

        // POST api/v1/projeto
        [HttpPost]
        [Route("")]
        public IHttpActionResult AdicionarProjeto([FromBody] ProjetoModels projeto)
        {                       
            
                _projetoRepository.Adicionar(projeto);
                return Ok(projeto);

         }

        // PUT api/v1/projeto/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Atualizar(int id, [FromBody] ProjetoModels projeto)
        {
            try
            {
                _projetoRepository.Atualizar(projeto);
                return Ok($"Projeto com ID {id}atualizado com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar o projeto com ID{id}: {ex.Message}");
            }

        }
        // DELETE api/v1/projeto/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeletarProjeto(int id)
        {
            try
            {
                _projetoRepository.Excluir(id);
                return Ok($"Projeto com ID {id} deletado com sucesso");

            }
            catch
            {
                return BadRequest($"Erro ao deletar o projeto com Id{id}");
            }
        }
    }
}