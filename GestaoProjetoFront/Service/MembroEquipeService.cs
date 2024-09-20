using GestaoProjetoFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace GestaoProjetoFront.Service
{
    public class MembroEquipeService
    {
        private readonly string _apiUrlmembroequipe;

        public MembroEquipeService()
        {
            _apiUrlmembroequipe = ConfigurationManager.AppSettings["ApiUrlmembroequipe"];
        }
        public List<MembroEquipeModels> ListarMembroEquipe()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                   
                    var resposta = client.GetStringAsync(_apiUrlmembroequipe).Result;
                    return JsonConvert.DeserializeObject<List<MembroEquipeModels>>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar membros da equipe: {ex.Message}", ex);
            }
        }

        public MembroEquipeModels BuscarPorId(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // GET /api/v1/projeto/{id}
                    var resposta = client.GetStringAsync($"{_apiUrlmembroequipe}/{id}").Result;
                    return JsonConvert.DeserializeObject<MembroEquipeModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar membroda equipe por ID: {ex.Message}", ex);
            }
        }

        public MembroEquipeModels BuscarPorNome(string nome)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // GET /api/v1/projeto/nome/{nome}
                    var resposta = client.GetStringAsync($"{_apiUrlmembroequipe}/nome/{nome}").Result;
                    return JsonConvert.DeserializeObject<MembroEquipeModels>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar membro da equipe por nome: {ex.Message}", ex);
            }
        }

        public void Adicionar(MembroEquipeModels membroEquipe)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // POST /api/v1/projeto
                    var jsonContent = JsonConvert.SerializeObject(membroEquipe);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PostAsync(_apiUrlmembroequipe, contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar membro a equipe: {ex.Message}", ex);
            }
        }

        public void Atualizar(MembroEquipeModels membroEquipe, int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    var jsonContent = JsonConvert.SerializeObject(membroEquipe);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PutAsync($"{_apiUrlmembroequipe}/{id}", contentString).Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao atualizar membro da equipe: {ex.Message}", ex);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // DELETE /api/v1/projeto/{id}
                    var response = client.DeleteAsync($"{_apiUrlmembroequipe}/{id}").Result;
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar projeto: {ex.Message}", ex);
            }
        }
        public List<MembroEquipeModels> ListarPorEquipeId(int equipeId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // GET /api/v1/membroequipe/equipe/{equipeId}
                    var resposta = client.GetStringAsync($"{_apiUrlmembroequipe}/equipe/{equipeId}").Result;
                    return JsonConvert.DeserializeObject<List<MembroEquipeModels>>(resposta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar membros da equipe com ID {equipeId}: {ex.Message}", ex);
            }
        }
    }
}
