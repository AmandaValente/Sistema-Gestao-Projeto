using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;

namespace GestaoProjetoFront.Views.Projetos
{
    public partial class ProjetoInicio : System.Web.UI.Page
    {
        private readonly string _apiUrl = "https://localhost:44318/api/v1/projeto";

        private readonly ProjetoService _projetoService = new ProjetoService();
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!IsPostBack)
            {
                try
                {
                    ProjetoService projetoService = new ProjetoService();
                    var projetos = projetoService.ListarProjetos();
                    
                    gvProjeto.DataSource = projetos; // Exibir a lista de projetos em um controle, como um GridView
                    gvProjeto.DataBind();
                }
                catch (Exception ex)
                {
                    // Tratar o erro e exibir uma mensagem ao usuário
                    Response.Write($"Erro: {ex.Message}");
                }
            }*/
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
            Response.Redirect("CadastroProjeto.aspx");
        }

        protected void BtnAtualizar_Click(object sender, EventArgs e)
        {
            // Obter o ID do projeto a partir do CommandArgument
            Button btn = (Button)sender;
            string projetoId = btn.CommandArgument;
            // Navegar para a página de edição do projeto
            Response.Redirect($"ProjetoAtualiza.aspx?ProjetoId={projetoId}");
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            // Obter o ID do projeto a partir do CommandArgument
            Button btnExcluir = (Button)sender;
            int projetoId = Convert.ToInt32(btnExcluir.CommandArgument);

            // Confirmar exclusão
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

            return true; // Retornar true se confirmado
        }

        private void MostrarMensagem(string mensagem)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }
    }
}