using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.Models;
using MySql.Data.MySqlClient;

namespace GerencTicketsRefeicao.DAL.Services
{
    public class TicketRepositorio : ITicketRepositorio
    {
        private readonly string _connectionString;

        public TicketRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Add(Ticket ticket)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "INSERT INTO ticketsRef (funcionarioId, quantidade, situacao, dataAltTr) VALUES (@FuncionarioId, @Quantidade, @Situacao, @DataModificacao)";
                    connection.Execute(query, ticket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar ticket: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public List<Ticket> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Ticket>("SELECT * FROM ticketsRef").AsList();
            }
        }

        public Ticket GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Ticket>("SELECT * FROM ticketsRef WHERE Id = @Id", new { Id = id });
            }
        }

        public void Update(Ticket ticket)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string sql = @"UPDATE ticketsRef SET funcionarioId = @FuncionarioId, quantidade = @Quantidade, situacao = @Situacao, dataAltTr = @DataModificacao WHERE Id = @Id";
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