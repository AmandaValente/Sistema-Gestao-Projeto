using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;
using System;

namespace GestaoProjetoFront
{
    public partial class ProjetoAtualiza : System.Web.UI.Page
    {
        private readonly string _apiUrl = "https://localhost:44318/api/v1/projeto/{id}";

        private readonly ProjetoService _projetoService = new ProjetoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ProjetoId"];
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int projetoId))
                {
                    CarregarProjeto(projetoId);
                    idprojeto.Value = id;
                }
            }

        }
        private void CarregarProjeto(int projetoId)
        {
            
            try
            {
                
                var projeto = _projetoService.BuscarPorId(projetoId);

                if (projeto != null)
                {
                    
                    txtNome.Text = projeto.Nome;
                    txtDescricao.Text = projeto.Descricao;
                    txtEquipeId.Text = projeto.EquipeId.ToString();
                    txtDataInicio.Text = projeto.DataInicio.ToString("yyyy-MM-dd"); // Formatar a data para o formato adequado
                    txtDataFim.Text = projeto.DataFim.HasValue ? projeto.DataFim.Value.ToString("yyyy-MM-dd") : string.Empty;
                    ddlStatus.SelectedValue = projeto.StatusProjeto;
                }
                else
                {
                    
                    Response.Write("Projeto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                
                Response.Write($"Erro ao carregar projeto: {ex.Message}");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                string nome = txtNome.Text.Trim();
                string descricao = txtDescricao.Text.Trim();
                int equipeId = int.Parse(txtEquipeId.Text.Trim());
                DateTime dataInicio = DateTime.Parse(txtDataInicio.Text.Trim());
                DateTime? dataFim = DateTime.TryParse(txtDataFim.Text.Trim(), out DateTime dataFimTemp) ? (DateTime?)dataFimTemp : null;
                string status = ddlStatus.SelectedValue;

                string idValue =idprojeto.Value.Trim();
                if (int.TryParse(idValue, out int projetoId))

                {

                    var projetoAtualizado = new ProjetoModels
                    {
                        ProjetoId = projetoId,
                        Nome = nome,
                        Descricao = descricao,
                        EquipeId = equipeId,
                        DataInicio = dataInicio,
                        DataFim = dataFim,
                        StatusProjeto = status
                    };

                    _projetoService.Atualizar(projetoAtualizado, projetoId);


                    Response.Write("Projeto atualizado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Erro ao atualizar projeto: {ex.Message}");
            }
        }
    }
}


