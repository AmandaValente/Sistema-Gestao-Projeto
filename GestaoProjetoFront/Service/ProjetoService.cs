using GestaoProjetoFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace GestaoProjetoFront.Service
{
    public class ProjetoService
    {
        private readonly string _apiUrl;

        public ProjetoService()
        {
            _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        }
        public List<ProjetoModels> ListarProjetos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // GET /api/v1/projeto
                    var resposta = client.GetStringAsync(_apiUrl).Result;
                    return JsonConvert.DeserializeObject<List<ProjetoModels>>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar projetos: {ex.Message}", ex);
            }
        }

        public ProjetoModels BuscarPorId(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // GET /api/v1/projeto/{id}
                    var resposta = client.GetStringAsync($"{_apiUrl}/{id}").Result;
                    return JsonConvert.DeserializeObject<ProjetoModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar projeto por ID: {ex.Message}", ex);
            }
        }

        public ProjetoModels BuscarPorNome(string nome)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // GET /api/v1/projeto/nome/{nome}
                    var resposta = client.GetStringAsync($"{_apiUrl}/nome/{nome}").Result;
                    return JsonConvert.DeserializeObject<ProjetoModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar projeto por nome: {ex.Message}", ex);
            }
        }

        public void Adicionar(ProjetoModels projeto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // POST /api/v1/projeto
                    var jsonContent = JsonConvert.SerializeObject(projeto);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PostAsync(_apiUrl, contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar projeto: {ex.Message}", ex);
            }
        }

        public void Atualizar(ProjetoModels projeto, int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // PUT /api/v1/projeto/{id}
                    var jsonContent = JsonConvert.SerializeObject(projeto);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PutAsync($"{_apiUrl}/{id}", contentString).Result;
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
                    // DELETE /api/v1/projeto/{id}
                    var response = client.DeleteAsync($"{_apiUrl}/{id}").Result;
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
