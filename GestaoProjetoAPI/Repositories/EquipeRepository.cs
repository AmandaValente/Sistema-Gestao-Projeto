using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using GestaoProjetoAPI.Models;

namespace GestaoProjetoAPI.Repositories
{
    public class EquipeRepository
    {
        
        public IList<EquipeModels> ListarTodas()
        {
            var equipes = new List<EquipeModels>();
            string sql = "SELECT * FROM dbo.Equipes";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var equipe = new EquipeModels
                                {
                                    EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId")),
                                    Nome = reader.GetString(reader.GetOrdinal("Nome"))
                                };
                                equipes.Add(equipe);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar equipes: " + sql);
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao listar equipes", ex);
                }
            }

            return equipes;
        }
        public void Adicionar(EquipeModels equipe)
        {
            string sql = @"INSERT INTO dbo.Equipes (Nome) VALUES (@nome)";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", equipe.Nome);
                    command.ExecuteNonQuery();
                }
            }
        }

        public EquipeModels BuscarPorId(int id)
        {
            EquipeModels equipe = null;
            string sql = "SELECT * FROM dbo.equipes WHERE EquipeId = @equipeId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@equipeId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            equipe = new EquipeModels
                            {
                                EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome"))
                            };
                        }
                    }
                }
            }
            return equipe;
        }

        public EquipeModels BuscarPorNome(string nome)
        {
            EquipeModels equipe = null;
            string sql = "SELECT * FROM dbo.equipes WHERE Nome LIKE @nome";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@nome", "%" + nome + "%"));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            equipe = new EquipeModels
                            {
                                EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao buscar equipe por Nome: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@nome = {nome}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao buscar equipe por ID", ex);
                }
            }

            return equipe;
        }

        public void Atualizar(EquipeModels equipe)
        {
            string sql = @"UPDATE dbo.Equipes SET Nome = @nome WHERE EquipeId = @equipeId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@equipeId", equipe.EquipeId);
                    command.Parameters.AddWithValue("@nome", equipe.Nome);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM dbo.Equipes WHERE EquipeId = @equipeId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@equipeId", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}