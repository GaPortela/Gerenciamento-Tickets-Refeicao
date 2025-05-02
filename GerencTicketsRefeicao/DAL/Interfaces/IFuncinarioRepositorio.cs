using System.Collections.Generic;
using GerencTicketsRefeicao.Models;

/*
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a definição da interface IFuncionarioRepositorio, que define os métodos para manipulação de funcionários.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.DAL.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        void Add(Funcionario funcionario);
        void Update(Funcionario funcionario);
        Funcionario GetById(int id);
        List<Funcionario> GetAll();
        Funcionario GetByNameOrCPF(string nome);
    }
}