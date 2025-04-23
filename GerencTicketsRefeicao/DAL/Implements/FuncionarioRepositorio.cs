using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.Models;
using System.Linq;

namespace GerencTicketsRefeicao.DAL.Implements
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly string _connectionString;

        public FuncionarioRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Funcionario funcionario)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO funcionarios (Nome, CPF, Situacao, DataAltFuncs) VALUES (@Nome, @CPF, @Situacao, @DataAlteracao)";
                connection.Execute(query, funcionario);
            }
        }

        public void Update(Funcionario funcionario)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string sql = @"UPDATE funcionarios SET Nome = @Nome, CPF = @CPF, Situacao = @Situacao, DataAltFuncs = @DataAlteracao WHERE Id = @Id";
                    connection.Execute(sql, funcionario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar funcionário: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public Funcionario GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Funcionario>("SELECT * FROM funcionarios WHERE Id = @Id", new { Id = id });
            }
        }

        public List<Funcionario> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>("SELECT * FROM funcionarios").ToList();
            }
        }
    }
}