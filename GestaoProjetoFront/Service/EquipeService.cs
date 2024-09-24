using GestaoProjetoFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace GestaoProjetoFront.Service
{
    public class EquipeService
    {
        private readonly string _apiUrlequipes;

        public EquipeService()
        {
            _apiUrlequipes = ConfigurationManager.AppSettings["ApiUrlequipes"];
        }
        public List<EquipeModels> ListarEquipes()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string resposta = client.GetStringAsync(_apiUrlequipes).Result;
                    return JsonConvert.DeserializeObject<List<EquipeModels>>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar equipes: {ex.Message}", ex);
            }
        }

        public EquipeModels BuscarPorId(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    var resposta = client.GetStringAsync($"{_apiUrlequipes}/{id}").Result;
                    return JsonConvert.DeserializeObject<EquipeModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar Equipe por ID: {ex.Message}", ex);
            }
        }

        public EquipeModels BuscarPorNome(string nome)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                   
                    var resposta = client.GetStringAsync($"{_apiUrlequipes}/nome/{nome}").Result;
                    return JsonConvert.DeserializeObject<EquipeModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar equipe por nome: {ex.Message}", ex);
            }
        }

        public void Adicionar(EquipeModels equipe)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // POST /api/v1/projeto
                    var jsonContent = JsonConvert.SerializeObject(equipe);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PostAsync(_apiUrlequipes, contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar equipe: {ex.Message}", ex);
            }
        }

        public void Atualizar(EquipeModels equipe, int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                  
                    var jsonContent = JsonConvert.SerializeObject(equipe);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PutAsync($"{_apiUrlequipes}/{id}", contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao atualizar equipe: {ex.Message}", ex);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                   
                    var response = client.DeleteAsync($"{_apiUrlequipes }/{id}").Result;
                    response.EnsureSuccessStatusCode();
                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar equipe: {ex.Message}", ex);
            }
        }
    }
}
