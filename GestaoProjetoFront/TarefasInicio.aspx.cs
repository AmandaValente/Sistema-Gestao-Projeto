
using GestaoProjetoFront.Service;
using System;
using System.Collections.Generic;
using System.Web.UI;
using GestaoProjetoFront.Models;
using System.Web.UI.WebControls;


namespace GestaoProjetoFront
{
    public partial class TarefasInicio : System.Web.UI.Page
    {
        private readonly string _apiUrltarefa = "https://localhost:44318/api/v1/tarefa";

        private readonly TarefaService _tarefaService = new TarefaService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string idTarefa = txtId.Text.Trim();


            List<TarefaModels> tarefas = new List<TarefaModels>();

            if (int.TryParse(idTarefa, out int id))
            {
                TarefaModels tarefa = _tarefaService.BuscarPorId(id);
                tarefas = tarefa != null ? new List<TarefaModels> { tarefa } : new List<TarefaModels>();
            }
            else
            {
                tarefas = _tarefaService.ListarTarefas();
            }

            gvTarefas.DataSource = tarefas;
            gvTarefas.DataBind();
        }
        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarefaNovo.aspx");
        }
        protected void BtnAtualizar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string TarefaId = btn.CommandArgument;
            Response.Redirect($"TarefaAtualiza.aspx?TarefaId={TarefaId}");
        }
        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            // Obtem o ID do projeto a partir do CommandArgument
            Button btnExcluir = (Button)sender;
            int TarefaId = Convert.ToInt32(btnExcluir.CommandArgument);


            if (ConfirmarExclusao())
            {
                try
                {
                    _tarefaService.Deletar(TarefaId);
                    CarregarTarefas(); 
                }
                catch (Exception ex)
                {
                    MostrarMensagem($"Erro ao excluir o projeto: {ex.Message}");
                }
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
        private void CarregarTarefas()
        {
            try
            {
                List<TarefaModels> tarefas = _tarefaService.ListarTarefas();
                gvTarefas.DataSource = tarefas;
                gvTarefas.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensagem($"Erro ao carregar projetos: {ex.Message}");
            }
        }


    }
}