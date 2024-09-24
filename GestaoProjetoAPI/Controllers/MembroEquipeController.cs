﻿using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System.Collections.Generic;
using System.Web.Http;



namespace GestaoProjetoAPI.Controllers
{
    [RoutePrefix("api/v1/membroequipe")]
    public class MembroEquipeController : ApiController
    {
        private readonly MembroEquipeRepository _membroEquipeRepository;

        public MembroEquipeController()
        {
            _membroEquipeRepository = new MembroEquipeRepository();
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<MembroEquipeModels> ListarProjetos()
        {
            return _membroEquipeRepository.ListarTodosMembros();
        }


        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarMembroPorId(int id)
        {
            var membro = _membroEquipeRepository.BuscarPorId(id);
            if (membro != null)
                return Ok(membro);

            return NotFound();
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult AdicionarMembro([FromBody] MembroEquipeModels membro)
        {
            _membroEquipeRepository.Adicionar(membro);
            return Ok(membro);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult AtualizarMembro(int id, [FromBody] MembroEquipeModels membro)
        {
            if (id != membro.MembroId || membro == null)
                return BadRequest("Id do membro ou dados inválidos.");

            var existente = _membroEquipeRepository.BuscarPorId(id);
            if (existente == null)
                return NotFound();

            _membroEquipeRepository.Atualizar(membro);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeletarMembro(int id)
        {
            var membro = _membroEquipeRepository.BuscarPorId(id);
            if (membro == null)
                return NotFound();

            _membroEquipeRepository.Excluir(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
        [HttpDelete]
        [Route("busca/{equipeid:int}")]
        public IHttpActionResult DeletarPorEdquipeId(int equipeid)
        {
            var membro = _membroEquipeRepository.BuscarPorEquipeId( equipeid);
            if (membro == null)
                return NotFound();

            _membroEquipeRepository.ExcluirMembros(equipeid);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("equipe/{equipeId:int}")]
        public IHttpActionResult ListarPorEquipeId(int equipeId)
        {
            var membros = _membroEquipeRepository.ListarPorEquipeId(equipeId);

            return Ok(membros);
        }

    }
}

