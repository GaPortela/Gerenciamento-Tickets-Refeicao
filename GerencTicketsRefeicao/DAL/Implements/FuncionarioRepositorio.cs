using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.Models;
using System.Linq;

/*
 * Nome do arquivo: FuncionarioRepositorio.cs
 * Descrição: Implementação do repositório para gerenciar operações de CRUD para a tabela de funcionários.
 * Autor: Guilherme Alves Portela
 */

namespace GerencTicketsRefeicao.DAL.Implements
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly string _connectionString;

        public FuncionarioRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// Método para adicionar um novo funcionário
        public void Add(Funcionario funcionario)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO funcionarios (Nome, CPF, Situacao, DataAlteracao) VALUES (@Nome, @CPF, @Situacao, @DataAlteracao)";
                connection.Execute(query, funcionario);
            }
        }

        /// Método para atualizar um funcionário existente
        public void Update(Funcionario funcionario)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string sql = @"UPDATE funcionarios SET Nome = @Nome, CPF = @CPF, Situacao = @Situacao, DataAlteracao = @DataAlteracao WHERE Id = @Id";
                    connection.Execute(sql, funcionario);
                    Console.WriteLine($"Funcionário atualizado com sucesso: {funcionario.Nome} (ID: {funcionario.Id})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar funcionário: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        /// Método para obter um funcionário pelo ID
        public Funcionario GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Funcionario>("SELECT * FROM funcionarios WHERE Id = @Id", new { Id = id });
            }
        }

        /// Método para obter uma lista de funcionários filtrados por nome ou CPF
        public Funcionario GetByNameOrCPF(string campo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Funcionario>("SELECT * FROM funcionarios WHERE Nome LIKE @Campo OR CPF LIKE @Campo", new { Campo = $"%{campo}%"});
            }
        }


        /// Método para obter todos os funcionários
        public List<Funcionario> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>("SELECT * FROM funcionarios").ToList();
            }
        }
    }
}