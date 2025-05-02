using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerencTicketsRefeicao.Models;

/* 
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a definição da interface ITicketService, que define os métodos para gerenciar tickets de refeição.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.BLL.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> ObterTodos();
        Ticket ObterPorId(int id);
        void Adicionar(Ticket ticket);
        void Atualizar(Ticket ticket);
    }
}
