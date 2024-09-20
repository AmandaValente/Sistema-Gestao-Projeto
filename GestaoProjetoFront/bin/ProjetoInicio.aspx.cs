using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoProjetoFront.Views.Projetos
{
    public partial class ProjetoInicio : System.Web.UI.Page
    {
        private readonly string _apiUrl = "https://localhost:44318/api/v1/projeto";

        private readonly ProjetoService _projetoService = new ProjetoService();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string idText = txtId.Text.Trim();
            string nome = txtNome.Text.Trim();

            List<ProjetoModels> projetos = new List<ProjetoModels>();

            // Verificar se o ID foi fornecido
            if (int.TryParse(idText, out int id))
            {
                ProjetoModels projeto = _projetoService.BuscarPorId(id);
                projetos = projeto != null ? new List<ProjetoModels> { projeto } : new List<ProjetoModels>();
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                var projeto = _projetoService.BuscarPorNome(nome);
                projetos = projeto != null ? new List<ProjetoModels> { projeto } : new List<ProjetoModels>();
            }
            else
            {
                projetos = _projetoService.ListarProjetos();
            }

            gvProjeto.DataSource = projetos;
            gvProjeto.DataBind();
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            // Navegar para a página de cadastro de novo projeto
            Response.Redirect("ProjetoNovo.aspx");
        }

        protected void BtnAtualizar_Click(object sender, EventArgs e)
        {
            // Obtem o ID do projeto a partir do CommandArgument
            Button btn = (Button)sender;
            string projetoId = btn.CommandArgument;
            // Navega para a página de edição do projeto
            Response.Redirect($"ProjetoAtualiza.aspx?ProjetoId={projetoId}");
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            // Obtem o ID do projeto a partir do CommandArgument
            Button btnExcluir = (Button)sender;
            int projetoId = Convert.ToInt32(btnExcluir.CommandArgument);

           
            if (ConfirmarExclusao())
            {
                try
                {
                    _projetoService.Deletar(projetoId);
                    CarregarProjetos(); // Recarregar a GridView após exclusão
                }
                catch (Exception ex)
                {
                    MostrarMensagem($"Erro ao excluir o projeto: {ex.Message}");
                }
            }
        }

        private void CarregarProjetos()
        {
            try
            {
                List<ProjetoModels> projetos = _projetoService.ListarProjetos();
                gvProjeto.DataSource = projetos;
                gvProjeto.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensagem($"Erro ao carregar projetos: {ex.Message}");
            }
        }

        private bool ConfirmarExclusao()
        {

            return true; 
        }

        private void MostrarMensagem(string mensagem)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }
    }
}