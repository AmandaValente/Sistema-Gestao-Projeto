using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;
using System;
using System.Web.UI;

namespace GestaoProjetoFront
{
    public partial class ProjetoNovo : System.Web.UI.Page
    {
        private readonly ProjetoService _projetoService = new ProjetoService();

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
                string equipeIdText = txtEquipeId.Text.Trim();
                string status = ddlStatus.SelectedValue;
                string dataInicioText = txtDataInicio.Text.Trim();
                string dataFimText = txtDataFim.Text.Trim();

                // Validar e converter os campos conforme necessário
                if (!int.TryParse(equipeIdText, out int equipeId))
                {
                    MostrarMensagem("ID da equipe inválido.");
                    return;
                }

                if (!DateTime.TryParse(dataInicioText, out DateTime dataInicio))
                {
                    MostrarMensagem("Data de Início inválida.");
                    return;
                }

                DateTime? dataFim = null;
                if (!string.IsNullOrEmpty(dataFimText))
                {
                    if (!DateTime.TryParse(dataFimText, out DateTime parsedDataFim))
                    {
                        MostrarMensagem("Data de Fim inválida.");
                        return;
                    }
                    dataFim = parsedDataFim;
                }

                // Criar um novo objeto ProjetoModels
                ProjetoModels novoProjeto = new ProjetoModels
                {
                    Nome = nome,
                    Descricao = descricao,
                    EquipeId = equipeId,
                    StatusProjeto = status,
                    DataInicio = dataInicio,
                    DataFim = dataFim
                };

                // Adicionar o projeto utilizando a API
                _projetoService.Adicionar(novoProjeto);

               
                MostrarMensagem("Projeto cadastrado com sucesso!");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MostrarMensagem($"Erro ao cadastrar o projeto: {ex.Message}");
            }
        }

        private void MostrarMensagem(string mensagem)
        {
           
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }

        private void LimparFormulario()
        {
            // Limpar os campos do formulário
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtEquipeId.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            txtDataInicio.Text = string.Empty;
            txtDataFim.Text = string.Empty;
        }
    }
}

