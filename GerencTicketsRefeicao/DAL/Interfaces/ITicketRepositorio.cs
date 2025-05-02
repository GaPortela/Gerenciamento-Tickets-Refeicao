using System.Collections.Generic;
using GerencTicketsRefeicao.Models;

/* 
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a definição da interface ITicketRepositorio, que define os métodos para manipulação de tickets.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.DAL.Interfaces
{
    public interface ITicketRepositorio
    {
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        List<Ticket> GetAll();
        Ticket GetById(int id);
        List<Ticket> GetByFuncionarioId(int funcionarioId);
    }
}