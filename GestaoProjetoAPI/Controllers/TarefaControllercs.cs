using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
using System;
using System.Linq;
using System.Web.Http;

namespace GestaoProjetoAPI.Controllers
{
    public class TarefaControllercs
    {
        [RoutePrefix("api/v1/tarefa")]
        public class TarefaController : ApiController
        {
            private readonly TarefaRepository _tarefaRepository;

            public TarefaController()
            {
                _tarefaRepository = new TarefaRepository();
            }

            // GET api/v1/tarefa
            [HttpGet]
            [Route("")]
            public IHttpActionResult ListarTarefas()
            {
                var tarefas = _tarefaRepository.ListarTodos();
                if (tarefas.Any())
                    return Ok(tarefas);

                return NotFound();
            }

            // GET api/v1/tarefa/{id}
            [HttpGet]
            [Route("{id:int}")]
            public IHttpActionResult BuscarPorId(int id)
            {
                var tarefa = _tarefaRepository.BuscarPorId(id);
                if (tarefa != null)
                    return Ok(tarefa);

                return NotFound();
            }

            // POST api/v1/tarefa
            [HttpPost]
            [Route("")]
            public IHttpActionResult AdicionarTarefa([FromBody] TarefaModels tarefa)
            {
                _tarefaRepository.Adicionar(tarefa);
                return Ok(tarefa);
            }

            // PUT api/v1/tarefa/{id}
            [HttpPut]
            [Route("{id:int}")]
            public IHttpActionResult AtualizarTarefa(int id, [FromBody] TarefaModels tarefa)
            {
                try
                {
                    _tarefaRepository.Atualizar(tarefa);
                    return Ok($"Tarefa atualizada com sucesso");

                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro ao atualizar o tarefa: {ex.Message}");
                }

            }

            // DELETE api/v1/tarefa/{id}
            [HttpDelete]
            [Route("{id:int}")]
            public IHttpActionResult DeletarTarefa(int id)
            {
                try
                {
                    _tarefaRepository.Excluir(id);
                    return Ok($"Tarefa deletada com sucesso");

                }
                catch
                {
                    return BadRequest($"Erro ao deletar tarefa com Id{id}");
                }
            }
        }
    }
}