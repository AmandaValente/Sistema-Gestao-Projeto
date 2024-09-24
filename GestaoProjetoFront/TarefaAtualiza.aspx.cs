using System;
using GestaoProjetoFront.Service;
using GestaoProjetoFront.Models;
using System.Web.UI;

namespace GestaoProjetoFront
{
    public partial class TarefaAtualiza : System.Web.UI.Page
    {
        private readonly string _apiUrltarefa = "https://localhost:44318/api/v1/tarefa/{id}";

        private readonly TarefaService _tarefaService = new TarefaService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["TarefaId"];
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int tarefaId))
                {
                    CarregarTarefa(tarefaId);
                    idtarefa.Value = id;
                }
            }


        }
        private void CarregarTarefa(int tarefaId)
        {

            try
            {

                var tarefa = _tarefaService.BuscarPorId(tarefaId);

                if (tarefa != null)
                {
                    txtNome.Text = tarefa.Nome;
                    txtDescricao.Text = tarefa.Descricao;
                    txtProjetoId.Text = tarefa.ProjetoId.ToString();
                    txtDataInicio.Text = tarefa.DataCriacao.ToString("yyyy-MM-dd"); 
                    txtDataFim.Text = tarefa.DataConclusao.HasValue ? tarefa.DataConclusao.Value.ToString("yyyy-MM-dd") : string.Empty;
                    ddlStatus.SelectedValue = tarefa.StatusTarefa;
                    Prioridade.SelectedValue = tarefa.Prioridade;
                    txtResponsavelId.Text = tarefa.ResponsavelId.HasValue ? tarefa.ResponsavelId.ToString() : string.Empty;

                }
                else
                {

                    Response.Write("Tarefa não encontrado.");
                }
            }
            catch (Exception ex)
            {

                Response.Write($"Erro ao carregar tarefa: {ex.Message}");
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                string nome = txtNome.Text.Trim();
                string descricao = txtDescricao.Text.Trim();
                int projetoId = int.Parse(txtProjetoId.Text.Trim());
                DateTime dataInicio = DateTime.Parse(txtDataInicio.Text.Trim());
                DateTime? dataFim = DateTime.TryParse(txtDataFim.Text.Trim(), out DateTime dataFimTemp) ? (DateTime?)dataFimTemp : null;
                string status = ddlStatus.SelectedValue;
                string prioridade = Prioridade.SelectedValue;

                int? responsavelId = null;
                if (int.TryParse(txtResponsavelId.Text.Trim(), out int parsedResponsavelId))
                {
                    responsavelId = parsedResponsavelId;
                }

                string idValue = idtarefa.Value.Trim();
                if (int.TryParse(idValue, out int tarefaId))

                {

                    var tarefaAtualizada = new TarefaModels
                    {
                        TarefaId = tarefaId,
                        Nome = nome,
                        Descricao = descricao,
                        ProjetoId = projetoId,
                        DataCriacao = dataInicio,
                        DataConclusao = dataFim,
                        StatusTarefa = status,
                        Prioridade = prioridade,
                        ResponsavelId = responsavelId,
                    };

                    _tarefaService.Atualizar(tarefaAtualizada, tarefaId);


                    Response.Write("Tarefa atualizada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Erro ao atualizar tarefa: {ex.Message}");
            }
        }
        private void MostrarMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }

    }
}