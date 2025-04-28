using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerencTicketsRefeicao.Models;

namespace GerencTicketsRefeicao.BLL.Interfaces
{
    public interface IFuncionarioService
    {
        List<Funcionario> ObterTodos();
        Funcionario ObterPorId(int id);
        void Adicionar(Funcionario funcionario);
        void UpdateFunc(Funcionario funcionario);
    }
}
