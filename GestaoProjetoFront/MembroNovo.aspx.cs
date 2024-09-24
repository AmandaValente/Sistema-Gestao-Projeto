using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;
using System;
using System.Web.UI;

namespace GestaoProjetoFront
{
    public partial class MembroNovo : System.Web.UI.Page
    {
        private readonly MembroEquipeService _membroequipeService = new MembroEquipeService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                string nome = txtNome.Text.Trim();
                string EquipeId = txtEquipeId.Text.Trim();
                string email = txtEmail.Text.Trim();


                if (!int.TryParse(EquipeId, out int equipeId))
                {
                    MostrarMensagem("ID da equipe inválido.");
                    return;
                }


                MembroEquipeModels novomembro = new MembroEquipeModels
                {
                    Nome = nome,
                    EquipeId = equipeId,
                    Email = email,

                };

                _membroequipeService.Adicionar(novomembro);


                MostrarMensagem("Membro cadastrado com sucesso!");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MostrarMensagem($"Erro ao cadastrar novo membro: {ex.Message}");
            }
        }

        private void MostrarMensagem(string mensagem)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{mensagem}');", true);
        }

        private void LimparFormulario()
        {

            txtNome.Text = string.Empty;
            txtEquipeId.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
    }
}



