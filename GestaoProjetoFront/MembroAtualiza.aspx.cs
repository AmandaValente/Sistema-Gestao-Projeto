using System;
using System.Web.UI.WebControls;
using GestaoProjetoFront.Models;
using GestaoProjetoFront.Service;

namespace GestaoProjetoFront
{
    public partial class MembroAtualiza : System.Web.UI.Page
    {
        private readonly string _apiUrl = "https://localhost:44318/api/v1/membroequipe/{id}";

        private readonly MembroEquipeService _membroequipeService = new MembroEquipeService();
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["MembroId"];
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int membroId))
                {

                    CarregarDadosMembro(membroId);
                    MembroId.Value = id;
                }
            }

        }
        private void CarregarDadosMembro(int membroId)
        {
            try
            {

                var membro = _membroequipeService.BuscarPorId(membroId);

                if (membro != null)
                {

                    txtNome.Text = membro.Nome;
                    txtEmail.Text = membro.Email;
                    txtEquipeId.Text = membro.EquipeId.ToString();

                }

                else
                {

                    Response.Write("Membro da equipe não encontrado.");
                }
            }
            catch (Exception ex)
            {

                Response.Write($"Erro ao carregar Membro a equipe: {ex.Message}");
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text.Trim();
                string email = txtEmail.Text.Trim();


                string equipeIdValue = txtEquipeId.Text.Trim();
                if (!int.TryParse(equipeIdValue, out int equipeId))
                {
                    Response.Write("ID da equipe inválido.");
                    return;
                }

                string idValue = MembroId.Value.Trim();
                if (int.TryParse(idValue, out int membroID))
                {
                    var membroAtualizado = new MembroEquipeModels
                    {
                        MembroId = membroID,
                        Nome = nome,
                        Email = email,
                        EquipeId = equipeId
                    };


                    _membroequipeService.Atualizar(membroAtualizado, membroID);

                    Response.Write("Membro da equipe atualizado com sucesso.");
                }
                else
                {
                    Response.Write("ID do membro inválido.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Erro ao atualizar o membro da equipe: {ex.Message}");
            }

        }
    }
}