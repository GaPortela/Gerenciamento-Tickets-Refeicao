using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerencTicketsRefeicao.Models;

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
