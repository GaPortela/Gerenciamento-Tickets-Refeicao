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
        List<Funcionario> GetAllFunc();
        Funcionario GetFuncById(int id);
        void AddFunc(Funcionario funcionario);
        void UpdateFunc(Funcionario funcionario);
    }
}
