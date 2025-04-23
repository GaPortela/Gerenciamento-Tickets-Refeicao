using System.Collections.Generic;
using GerencTicketsRefeicao.Models;

namespace GerencTicketsRefeicao.DAL.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        void Add(Funcionario funcionario);
        void Update(Funcionario funcionario);
        Funcionario GetById(int id);
        List<Funcionario> GetAll();
    }
}