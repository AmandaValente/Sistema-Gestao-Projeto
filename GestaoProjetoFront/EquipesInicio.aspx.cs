using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GestaoProjetoFront
{
    public partial class EquipesInicio : System.Web.UI.Page
    {
        private readonly string _apiUrl = "https://localhost:44318/api/v1/equipes";

        private readonly EquipeService _equipeService = new EquipeService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string idText = txtId.Text.Trim();
            string nome = txtNome.Text.Trim();

            List<EquipeModels> equipe = new List<EquipeModels>();

            // Verificar se o ID foi fornecido
            if (int.TryParse(idText, out int id))
            {
                EquipeModels equipes = _equipeService.BuscarPorId(id);
                equipe = equipe != null ? new List<EquipeModels> { equipes } : new List<EquipeModels>();
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                var equipes = _equipeService.BuscarPorNome(nome);
                equipe = equipe != null ? new List<EquipeModels> { equipes } : new List<EquipeModels>();
            }
            else
            {
                equipe = _equipeService.ListarEquipes();
            }

            gvEquipe.DataSource = equipe;
            gvEquipe.DataBind();
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("EquipeNovo.aspx");
        }

        protected void BtnAtualizar_Click(object sender, EventArgs e)
        {
            int equipeId = int.Parse((sender as Button).CommandArgument);

            Response.Redirect($"EquipeAtualiza.aspx?equipeId={equipeId}");
        }


        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            // Obtem o ID do projeto a partir do CommandArgument
            Button btnExcluir = (Button)sender;
            int equipeId = Convert.ToInt32(btnExcluir.CommandArgument);


            if (ConfirmarExclusao())
            {
                try
                {
                    _equipeService.Deletar(equipeId);
                    CarregarEquipes(); // Recarregar a GridView após exclusão
                }
                catch (Exception ex)
                {
                    MostrarMensagem($"Erro ao excluir o projeto: {ex.Message}");
                }
            }
        }

        private void CarregarEquipes()
        {
            try
            {
                List<EquipeModels> equipe = _equipeService.ListarEquipes();
                gvEquipe.DataSource = equipe;
                gvEquipe.DataBind();
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

