using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GestaoProjetoAPI.Models;
namespace GestaoProjetoAPI.Repositories
{
    public class MembroEquipeRepository
    {
        public IList<MembroEquipeModels> ListarTodosMembros()
        {
            var membros = new List<MembroEquipeModels>();
            string sql = "SELECT * FROM dbo.MembrosEquipe";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var membro = new MembroEquipeModels
                            {
                                MembroId = reader.GetInt32(reader.GetOrdinal("MembroId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId")),
                            };
                            membros.Add(membro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar os membros da equipe: " + ex.Message);
                    throw new Exception("Erro ao listar os membros da equipe", ex);
                }
            }

            return membros;
        }

        public void Adicionar(MembroEquipeModels membro)
        {
            string sql = @"INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES (@nome, @email, @equipeId)";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", membro.Nome);
                    command.Parameters.AddWithValue("@email", membro.Email);
                    command.Parameters.AddWithValue("@equipeId", membro.EquipeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public MembroEquipeModels BuscarPorId(int id)
        {
            MembroEquipeModels membro = null;
            string sql = "SELECT * FROM MembrosEquipe WHERE MembroId = @membroId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@membroId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            membro = new MembroEquipeModels
                            {
                                MembroId = reader.GetInt32(reader.GetOrdinal("MembroId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId"))
                            };
                        }
                    }
                }
            }
            return membro;
        }

        public void Atualizar(MembroEquipeModels membro)
        {
            string sql = @"UPDATE MembrosEquipe SET Nome = @nome, Email = @email, EquipeId = @equipeId WHERE MembroId = @membroId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@membroId", membro.MembroId);
                    command.Parameters.AddWithValue("@nome", membro.Nome);
                    command.Parameters.AddWithValue("@email", membro.Email);
                    command.Parameters.AddWithValue("@equipeId", membro.EquipeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM MembrosEquipe WHERE MembroId = @membroId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@membroId", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirMembros(int equipeId)
        {
            string sql = "DELETE FROM MembrosEquipe WHERE EquipeId = @equipeId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@equipeId", equipeId);
                    command.ExecuteNonQuery(); // aqui ta dando conflito para excluir  pq existem tarefas no BD que estão atreladas a membros equipe

                }
            }
        }


        public IList<MembroEquipeModels> ListarPorEquipeId(int equipeId)
        {
            var membros = new List<MembroEquipeModels>();
            string sql = "SELECT MembroId, Nome, Email, EquipeId FROM dbo.MembrosEquipe WHERE EquipeId = @EquipeId";

            using (var connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@EquipeId", equipeId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var membro = new MembroEquipeModels
                                {
                                    MembroId = reader.GetInt32(reader.GetOrdinal("MembroId")),
                                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId"))
                                };
                                membros.Add(membro);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar membros da equipe: " + ex.Message);
                    throw new Exception("Erro ao listar membros da equipe", ex);
                }
            }

            return membros;
        }
    }
}