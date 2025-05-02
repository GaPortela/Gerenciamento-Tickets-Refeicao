using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerencTicketsRefeicao.Models;

/* 
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a definição da interface IFuncionarioService, que define os métodos para gerenciar funcionários.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.BLL.Interfaces
{
    public interface IFuncionarioService
    {
        List<Funcionario> ObterTodos();
        Funcionario ObterPorId(int id);
        void Adicionar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        Funcionario ObterPorNomeOuCPF(string nome);
    }
}
