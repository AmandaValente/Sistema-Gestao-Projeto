using System;
using GestaoProjetoFront.Service;
using GestaoProjetoFront.Models;
using System.Web.UI.WebControls;

namespace GestaoProjetoFront
{
    public partial class EquipeAtualiza : System.Web.UI.Page
    {
        private readonly string _apiUrlequipes = "https://localhost:44318/api/v1/equipes/";
        private readonly string _apiUrlmembroequipe = "https://localhost:44318/api/v1/membroequipe";


        private readonly EquipeService _equipeService = new EquipeService();
        private readonly MembroEquipeService _membroEquipeService = new MembroEquipeService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["EquipeId"];
                 if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int equipeId))
               
                {
                    _carregarEquipe(equipeId);
                    CarregarMembros(equipeId);
                    idequipe.Value = id;
                }
            }

        }
        private void _carregarEquipe(int EquipeId)
        {            
            try
            {

                var equipe = _equipeService.BuscarPorId(EquipeId);

                if (equipe != null)
                {

                    txtNome.Text = equipe.Nome;
                }
                else
                {

                    Response.Write("Equipe não encontrado.");
                }
            }
            catch (Exception ex)
            {

                Response.Write($"Erro ao carregar equipe: {ex.Message}");
            }
            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                string nome = txtNome.Text.Trim();
                string idValue = idequipe.Value.Trim();
                if (int.TryParse(idValue, out int equipeId))

                {

                    var equipeAtualizado = new EquipeModels
                    {
                        EquipeId = equipeId,
                        Nome = nome,

                    };


                    _equipeService.Atualizar(equipeAtualizado, equipeId);


                    Response.Write("Equipe atualizada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Erro ao atualizar Equipe: {ex.Message}");
            }
        }

        protected void CarregarMembros(int equipeId)
        {
            var membros = _membroEquipeService.ListarPorEquipeId(equipeId);
            gvMembros.DataSource = membros;
            gvMembros.DataBind();
        }
        protected void btnNovoMembro_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("MembroNovo.aspx?EquipeId=" + idequipe.Value);
        }


        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int membroId = int.Parse((sender as Button).CommandArgument);
            
            _membroEquipeService.Deletar(membroId);
           
            CarregarMembros(int.Parse(idequipe.Value)); 
        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            int membroId = Convert.ToInt32(btn.CommandArgument);

            
            Response.Redirect($"MembroAtualiza.aspx?membroId={membroId}");
        }


    }
}