using System.Collections.Generic;
using GerencTicketsRefeicao.Models;

namespace GerencTicketsRefeicao.DAL.Interfaces
{
    public interface ITicketRepositorio
    {
        void Add(Ticket ticket);
        List<Ticket> GetAll();
        Ticket GetById(int id);
        void Update(Ticket ticket);
    }
}