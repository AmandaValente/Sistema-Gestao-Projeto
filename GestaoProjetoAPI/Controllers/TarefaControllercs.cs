using GestaoProjetoAPI.Models;
using GestaoProjetoAPI.Repositories;
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
                if (tarefa == null)
                    return BadRequest("Tarefa inválida.");

                _tarefaRepository.Adicionar(tarefa);
                return CreatedAtRoute(nameof(BuscarPorId), new { id = tarefa.TarefaId }, tarefa);
            }

            // PUT api/v1/tarefa/{id}
            [HttpPut]
            [Route("{id:int}")]
            public IHttpActionResult AtualizarTarefa(int id, [FromBody] TarefaModels tarefa)
            {
                if (id != tarefa.TarefaId || tarefa == null)
                    return BadRequest("Dados da tarefa inválidos.");

                _tarefaRepository.Atualizar(tarefa);
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            // DELETE api/v1/tarefa/{id}
            [HttpDelete]
            [Route("{id:int}")]
            public IHttpActionResult DeletarTarefa(int id)
            {
                var tarefa = _tarefaRepository.BuscarPorId(id);
                if (tarefa == null)
                    return NotFound();

                _tarefaRepository.Excluir(id);
                return StatusCode(System.Net.HttpStatusCode.NoContent); 
            }
        }
    }
}