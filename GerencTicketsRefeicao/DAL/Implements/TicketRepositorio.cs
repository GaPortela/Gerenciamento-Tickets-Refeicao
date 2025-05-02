using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.Models;
using MySql.Data.MySqlClient;

/*
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a implementação da classe TicketRepositorio, que é responsável por manipular os dados dos tickets no banco de dados.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.DAL.Implements
{
    public class TicketRepositorio : ITicketRepositorio
    {
        private readonly string _connectionString;

        public TicketRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// Método para adicionar um novo ticket
        public void Add(Ticket ticket)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "INSERT INTO ticketsRef (funcionarioId, quantidade, situacao, dataAlteracao) VALUES (@FuncionarioId, @Quantidade, @Situacao, @DataAlteracao)";
                    connection.Execute(query, ticket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar ticket: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        /// Método para obter todos os tickets
        public List<Ticket> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Ticket>("SELECT * FROM ticketsRef").AsList();
            }
        }

        /// Método para obter um ticket pelo ID
        public Ticket GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Ticket>("SELECT * FROM ticketsRef WHERE Id = @Id", new { Id = id });
            }
        }

        /// Método para obter um ticket pelo ID do funcionário (Chave estrangeira)

        public List<Ticket> GetByFuncionarioId(int funcionarioId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Ticket>("SELECT * FROM ticketsRef WHERE funcionarioId = @FuncionarioId", new { FuncionarioId = funcionarioId }).AsList();
            }
        }

        /// Método para obter tickets filtrados por funcionário
        public void Update(Ticket ticket)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string sql = @"UPDATE ticketsRef SET funcionarioId = @FuncionarioId, quantidade = @Quantidade, situacao = @Situacao, dataAlteracao = @DataAlteracao WHERE Id = @Id";
                    connection.Execute(sql, ticket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar ticket: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }
    }
}