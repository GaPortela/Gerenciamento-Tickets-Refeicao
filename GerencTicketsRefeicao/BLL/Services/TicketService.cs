using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerencTicketsRefeicao.BLL.Interfaces;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.Models;

/*
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a implementação da classe TicketService, que gerencia as operações relacionadas aos tickets de refeição.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */


namespace GerencTicketsRefeicao.BLL.Services
{

    public class TicketService : ITicketService
    {
        private readonly ITicketRepositorio _ticketRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public TicketService(ITicketRepositorio ticketRepositorio, IFuncionarioRepositorio funcionarioRepositorio)
        {
            _ticketRepositorio = ticketRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        // Método para obter todos os tickets
        public List<Ticket> ObterTodos()
        {
            return _ticketRepositorio.GetAll();
        }

        // Método para obter um ticket pelo ID
        public Ticket ObterPorId(int id)
        {
            return _ticketRepositorio.GetById(id);
        }

        // Método para adicionar um novo ticket
        public void Adicionar(Ticket ticket)
        {
            if (ticket.FuncionarioId <= 0)
            {
                throw new ArgumentException("O Funcionário é obrigatório.");
            }

            if (ticket.Quantidade <= 0)
            {
                throw new ArgumentException("A quantidade de tickets é obrigatória.");
            }

            var funcionario = _funcionarioRepositorio.GetById(ticket.FuncionarioId);

            if (funcionario == null)
            {
                throw new ArgumentException("Funcionário não encontrado.");
            }

            if (funcionario.Situacao != 'A')
            {
                throw new ArgumentException("Não é possível adicionar tickets para um funcionário inativo.");
            }

            ticket.DataAlteracao = DateTime.Now; // Atualiza a data de modificação 

            _ticketRepositorio.Add(ticket); // Adiciona o vale-refeição ao repositório

        }

        // Método para atualizar um ticket existente
        public void Atualizar(Ticket ticket)
        {
            if (ticket.FuncionarioId <= 0)
            {
                throw new ArgumentException("O Funcionário é obrigatório.");
            }

            if (ticket.Quantidade <= 0)
            {
                throw new ArgumentException("A quantidade de tickets é obrigatória.");
            }

            var funcionario = _funcionarioRepositorio.GetById(ticket.FuncionarioId);

            if (funcionario == null)
            {
                throw new ArgumentException("Funcionário não encontrado.");
            }

            if (funcionario.Situacao != 'A')
            {
                throw new ArgumentException("Não é possível atualizar tickets para um funcionário inativo.");
            }

            ticket.DataAlteracao = DateTime.Now; // Atualiza a data de modificação
            _ticketRepositorio.Update(ticket); // Atualiza o vale-refeição no repositório


        }
    }
}
