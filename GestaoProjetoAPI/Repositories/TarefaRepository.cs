using GestaoProjetoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestaoProjetoAPI.Repositories
{
    public class TarefaRepository
    {
        public IList<TarefaModels> ListarTodos()
        {
            var tarefas = new List<TarefaModels>();
            string sql = "SELECT * FROM Tarefas";

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
                            var tarefa = new TarefaModels
                            {
                                TarefaId = reader.GetInt32(reader.GetOrdinal("TarefaId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                DataCriacao = reader.GetDateTime(reader.GetOrdinal("DataInicio")),
                                DataConclusao = reader.IsDBNull(reader.GetOrdinal("DataFim")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataFim")),
                                StatusTarefa = reader.GetString(reader.GetOrdinal("StatusTarefa")),
                                ProjetoId = reader.GetInt32(reader.GetOrdinal("ProjetoId"))
                            };
                            tarefas.Add(tarefa);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar tarefas: " + sql);
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao listar tarefas", ex);
                }
            }

            return tarefas;
        }
        public void Adicionar(TarefaModels tarefa)
        {
            string sql = @"INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)
                           VALUES (@nome, @descricao, @dataCriacao, @dataConclusao, @prioridade, @statusTarefa, @projetoId, @responsavelId)";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add(new SqlParameter("@nome", tarefa.Nome));
                    command.Parameters.Add(new SqlParameter("@descricao", tarefa.Descricao));
                    command.Parameters.Add(new SqlParameter("@dataCriacao", tarefa.DataCriacao));
                    command.Parameters.Add(new SqlParameter("@dataConclusao", (object)tarefa.DataConclusao ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
                    command.Parameters.Add(new SqlParameter("@statusTarefa", tarefa.StatusTarefa));
                    command.Parameters.Add(new SqlParameter("@projetoId", tarefa.ProjetoId));
                    command.Parameters.Add(new SqlParameter("@responsavelId", (object)tarefa.ResponsavelId ?? DBNull.Value));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar tarefa: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@nome = {tarefa.Nome}");
                    Console.WriteLine($"@descricao = {tarefa.Descricao}");
                    Console.WriteLine($"@dataCriacao = {tarefa.DataCriacao}");
                    Console.WriteLine($"@dataConclusao = {tarefa.DataConclusao}");
                    Console.WriteLine($"@prioridade = {tarefa.Prioridade}");
                    Console.WriteLine($"@statusTarefa = {tarefa.StatusTarefa}");
                    Console.WriteLine($"@projetoId = {tarefa.ProjetoId}");
                    Console.WriteLine($"@responsavelId = {tarefa.ResponsavelId}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao salvar tarefa", ex);
                }
            }
        }

        public TarefaModels BuscarPorId(int id)
        {
            TarefaModels tarefa = null;
            string sql = "SELECT * FROM Tarefas WHERE TarefaId = @tarefaId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@tarefaId", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tarefa = new TarefaModels
                            {
                                TarefaId = reader.GetInt32(reader.GetOrdinal("TarefaId")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Descricao = reader.IsDBNull(reader.GetOrdinal("Descricao")) ? null : reader.GetString(reader.GetOrdinal("Descricao")),
                                DataCriacao = reader.GetDateTime(reader.GetOrdinal("DataCriacao")),
                                DataConclusao = reader.IsDBNull(reader.GetOrdinal("DataConclusao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataConclusao")),
                                Prioridade = reader.GetString(reader.GetOrdinal("Prioridade")),
                                StatusTarefa = reader.GetString(reader.GetOrdinal("StatusTarefa")),
                                ProjetoId = reader.GetInt32(reader.GetOrdinal("ProjetoId")),
                                ResponsavelId = reader.IsDBNull(reader.GetOrdinal("ResponsavelId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ResponsavelId"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao buscar tarefa por ID: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@tarefaId = {id}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao buscar tarefa por ID", ex);
                }
            }

            return tarefa;
        }

        public void Atualizar(TarefaModels tarefa)
        {
            string sql = @"UPDATE Tarefas
                           SET Nome = @nome,
                               Descricao = @descricao,
                               DataCriacao = @dataCriacao,
                               DataConclusao = @dataConclusao,
                               Prioridade = @prioridade,
                               StatusTarefa = @statusTarefa,
                               ProjetoId = @projetoId,
                               ResponsavelId = @responsavelId
                           WHERE TarefaId = @tarefaId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add(new SqlParameter("@tarefaId", tarefa.TarefaId));
                    command.Parameters.Add(new SqlParameter("@nome", tarefa.Nome));
                    command.Parameters.Add(new SqlParameter("@descricao", tarefa.Descricao));
                    command.Parameters.Add(new SqlParameter("@dataCriacao", tarefa.DataCriacao));
                    command.Parameters.Add(new SqlParameter("@dataConclusao", (object)tarefa.DataConclusao ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
                    command.Parameters.Add(new SqlParameter("@statusTarefa", tarefa.StatusTarefa));
                    command.Parameters.Add(new SqlParameter("@projetoId", tarefa.ProjetoId));
                    command.Parameters.Add(new SqlParameter("@responsavelId", (object)tarefa.ResponsavelId ?? DBNull.Value));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao atualizar tarefa: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@tarefaId = {tarefa.TarefaId}");
                    Console.WriteLine($"@nome = {tarefa.Nome}");
                    Console.WriteLine($"@descricao = {tarefa.Descricao}");
                    Console.WriteLine($"@dataCriacao = {tarefa.DataCriacao}");
                    Console.WriteLine($"@dataConclusao = {tarefa.DataConclusao}");
                    Console.WriteLine($"@prioridade = {tarefa.Prioridade}");
                    Console.WriteLine($"@statusTarefa = {tarefa.StatusTarefa}");
                    Console.WriteLine($"@projetoId = {tarefa.ProjetoId}");
                    Console.WriteLine($"@responsavelId = {tarefa.ResponsavelId}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao atualizar tarefa", ex);
                }
            }
        }
        public void Excluir(int id)
        {
            string sql = "DELETE FROM Tarefas WHERE TarefaId = @tarefaId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@tarefaId", id));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao excluir tarefa: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@tarefaId = {id}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao excluir tarefa", ex);
                }
            }
        }
        public void ExcluirPorProjetoID(int id)
        {
            string sql = "DELETE FROM Tarefas WHERE ProjetoId = @ProjetoId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@ProjetoId", id));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao excluir tarefa: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@tarefaId = {id}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao excluir tarefa", ex);
                }
            }
        }
        public void ExcluirPorResponsavelID(int id)
        {
            string sql = "DELETE FROM Tarefas WHERE ResponsaveId = @ResponsavelId";

            using (SqlConnection connection = ConfigConexao.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@ResponsavelId", id));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao excluir tarefa: " + sql);
                    Console.WriteLine("Parâmetros:");
                    Console.WriteLine($"@tarefaId = {id}");
                    Console.WriteLine("Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw new Exception("Erro ao excluir tarefa", ex);
                }
            }
        }
    }
}

