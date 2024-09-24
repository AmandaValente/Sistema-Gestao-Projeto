using GestaoProjetoFront.Service;
using System;
using System.Web.UI;
using GestaoProjetoFront.Models;

namespace GestaoProjetoFront
{
    public partial class EquipeNovo : System.Web.UI.Page
    {
        private readonly EquipeService _equipeService = new EquipeService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                string nome = txtNome.Text.Trim();


                EquipeModels novaequipe = new EquipeModels
                {
                    Nome = nome,

                };

                _equipeService.Adicionar(novaequipe);


                MostrarMensagem("Equipe cadastrado com sucesso!");
                LimparFormulario();
                Response.Redirect("MembroNovo.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensagem($"Erro ao cadastrar nova equipe: {ex.Message}");
            }
        }

        private void MostrarMensagem(string mensagem)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }

        private void LimparFormulario()
        {

            txtNome.Text = string.Empty;

        }
    }
}
