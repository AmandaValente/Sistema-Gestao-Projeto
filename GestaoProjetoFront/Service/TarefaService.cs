using GestaoProjetoFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace GestaoProjetoFront.Service
{
    public class TarefaService
    {
        private readonly string _ApiUrltarefa;

        public TarefaService()
        {
            _ApiUrltarefa = ConfigurationManager.AppSettings["ApiUrltarefa"];
        }
        public List<TarefaModels> ListarTarefas()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                 
                    var resposta = client.GetStringAsync(_ApiUrltarefa).Result;
                    return JsonConvert.DeserializeObject<List<TarefaModels>>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar  tarefas: {ex.Message}", ex);
            }
        }

        public TarefaModels BuscarPorId(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var resposta = client.GetStringAsync($"{_ApiUrltarefa}/{id}").Result;
                    return JsonConvert.DeserializeObject<TarefaModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar projeto por ID: {ex.Message}", ex);
            }
        }
       

        public void Adicionar(TarefaModels tarefa)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonContent = JsonConvert.SerializeObject(tarefa);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PostAsync(_ApiUrltarefa, contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar tarefa: {ex.Message}", ex);
            }
        }

        public void Atualizar(TarefaModels tarefa, int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonContent = JsonConvert.SerializeObject(tarefa);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PutAsync($"{_ApiUrltarefa}/{id}", contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao atualizar projeto: {ex.Message}", ex);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.DeleteAsync($"{_ApiUrltarefa}/{id}").Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar projeto: {ex.Message}", ex);
            }
        }
    }
}