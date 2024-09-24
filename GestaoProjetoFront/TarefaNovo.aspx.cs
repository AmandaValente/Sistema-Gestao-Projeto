using System;
using GestaoProjetoFront.Service;
using GestaoProjetoFront.Models;
using System.Web.UI;

namespace GestaoProjetoFront
{
    public partial class TarefaNovo : System.Web.UI.Page
    {
        private readonly TarefaService _tarefaService = new TarefaService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Coletar os dados do formulário
                string nome = txtNome.Text.Trim();
                string descricao = txtDescricao.Text.Trim();
                string ProjetoId = txtProjetoId.Text.Trim();
                string status = ddlStatus.SelectedValue;
                string dataCriacao = txtDataInicio.Text.Trim();
                string dataFim = txtDataFim.Text.Trim();
                string prioridade = Prioridade.SelectedValue;
                int? responsavelId = null;

                if (!int.TryParse(ProjetoId, out int projetoId))
                {
                    MostrarMensagem("ID do Projeto inválido.");
                    return;
                }

                if (!DateTime.TryParse(dataCriacao, out DateTime dataInicio))
                {
                    MostrarMensagem("Data de Início inválida.");
                    return;
                }

                DateTime? dataConclusao = null;
                if (!string.IsNullOrWhiteSpace(dataFim))
                {
                    if (DateTime.TryParse(dataFim, out DateTime parsedDataFim))
                    {
                        dataConclusao = parsedDataFim;
                    }
                    else
                    {
                        MostrarMensagem("Data de Conclusão inválida.");
                        return;
                    }
                }

                if (int.TryParse(txtResponsavelId.Text.Trim(), out int parsedResponsavelId))
                {
                    responsavelId = parsedResponsavelId;
                }

                // Criar um novo objeto ProjetoModels
                TarefaModels novaTarefa = new TarefaModels
                {
                    Nome = nome,
                    Descricao = descricao,
                    ProjetoId = projetoId,
                    StatusTarefa = status,
                    DataCriacao = dataInicio,
                    DataConclusao = dataConclusao,
                    Prioridade = prioridade,
                    ResponsavelId = responsavelId,

                };

                _tarefaService.Adicionar(novaTarefa);


                MostrarMensagem("Tarefa cadastrada com sucesso!");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MostrarMensagem($"Erro ao cadastrar tarefa: {ex.Message}");
            }
        }

        private void MostrarMensagem(string mensagem)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }

        private void LimparFormulario()
        {
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtProjetoId.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            txtDataInicio.Text = string.Empty;
            txtDataFim.Text = string.Empty;
            txtProjetoId.Text = string.Empty;
            Prioridade.SelectedIndex = 0;

        }
    }

}
