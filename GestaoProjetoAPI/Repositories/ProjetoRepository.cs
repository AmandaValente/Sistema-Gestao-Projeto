using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestaoProjetoAPI.Models;


namespace GestaoProjetoAPI.Repositories
{
    public class ProjetoRepository
    {
        public IList<ProjetoModels> ListarTodos()
        {
            var projetos = new List<ProjetoModels>();
            string sql = "SELECT * FROM dbo.Projetos";

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
                            var projeto = new ProjetoModels
                            {
                                ProjetoId = reader.GetInt32(reader.GetOrdinal("ProjetoId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                DataInicio = reader.GetDateTime(reader.GetOrdinal("DataInicio")),
                                DataFim = reader.IsDBNull(reader.GetOrdinal("DataFim")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataFim")),
                                StatusProjeto = reader.GetString(reader.GetOrdinal("StatusProjeto")),
                                EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId"))
                            };
                            projetos.Add(projeto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar projetos: " + sql);
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao listar projetos", ex);
                }
            }

            return projetos;
        }
        public void Adicionar(ProjetoModels projeto)
        {
            string sql = @"INSERT INTO dbo.Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)
                           VALUES (@nome, @descricao, @dataInicio, @dataFim, @statusProjeto, @equipeId)";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.Add(new SqlParameter("@nome", projeto.Nome));
                        command.Parameters.Add(new SqlParameter("@descricao", projeto.Descricao));
                        command.Parameters.Add(new SqlParameter("@dataInicio", projeto.DataInicio));
                        command.Parameters.Add(new SqlParameter("@dataFim", (object)projeto.DataFim ?? DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@statusProjeto", projeto.StatusProjeto));
                        command.Parameters.Add(new SqlParameter("@equipeId", projeto.EquipeId));

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar projeto: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@nome = {projeto.Nome}");
                    Console.WriteLine($"@descricao = {projeto.Descricao}");
                    Console.WriteLine($"@dataInicio = {projeto.DataInicio}");
                    Console.WriteLine($"@dataFim = {projeto.DataFim}");
                    Console.WriteLine($"@statusProjeto = {projeto.StatusProjeto}");
                    Console.WriteLine($"@equipeId = {projeto.EquipeId}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao salvar projeto", ex);
                }
            }
        }

        public ProjetoModels BuscarPorId(int id)
        {
            ProjetoModels projeto = null;
            string sql = "SELECT * FROM dbo.Projetos WHERE ProjetoId = @projetoId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@projetoId", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            projeto = new ProjetoModels
                            {
                                ProjetoId = reader.GetInt32(reader.GetOrdinal("ProjetoId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                DataInicio = reader.GetDateTime(reader.GetOrdinal("DataInicio")),
                                DataFim = reader.IsDBNull(reader.GetOrdinal("DataFim")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataFim")),
                                StatusProjeto = reader.GetString(reader.GetOrdinal("StatusProjeto")),
                                EquipeId = reader.GetInt32(reader.GetOrdinal("EquipeId"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao buscar projeto por ID: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@projetoId = {id}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao buscar projeto por ID", ex);
                }
            }

            return projeto;
        }

        public void Atualizar(ProjetoModels projeto)
        {
            string sql = @"UPDATE dbo.Projetos 
                           SET Nome = @nome, 
                               Descricao = @descricao, 
                               DataInicio = @dataInicio, 
                               DataFim = @dataFim, 
                               StatusProjeto = @statusProjeto, 
                               EquipeId = @equipeId 
                           WHERE ProjetoId = @projetoId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add(new SqlParameter("@projetoId", projeto.ProjetoId));
                    command.Parameters.Add(new SqlParameter("@nome", projeto.Nome));
                    command.Parameters.Add(new SqlParameter("@descricao", projeto.Descricao));
                    command.Parameters.Add(new SqlParameter("@dataInicio", projeto.DataInicio));
                    command.Parameters.Add(new SqlParameter("@dataFim", (object)projeto.DataFim ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@statusProjeto", projeto.StatusProjeto));
                    command.Parameters.Add(new SqlParameter("@equipeId", projeto.EquipeId));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao atualizar projeto: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@projetoId = {projeto.ProjetoId}");
                    Console.WriteLine($"@nome = {projeto.Nome}");
                    Console.WriteLine($"@descricao = {projeto.Descricao}");
                    Console.WriteLine($"@dataInicio = {projeto.DataInicio}");
                    Console.WriteLine($"@dataFim = {projeto.DataFim}");
                    Console.WriteLine($"@statusProjeto = {projeto.StatusProjeto}");
                    Console.WriteLine($"@equipeId = {projeto.EquipeId}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao atualizar projeto", ex);
                }
            }
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM dbo.Projetos WHERE ProjetoId = @projetoId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@projetoId", id));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao excluir projeto: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@projetoId = {id}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao excluir projeto", ex);
                }
            }
        }

       
    }
}

