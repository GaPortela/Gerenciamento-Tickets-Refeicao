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
 * Este arquivo contém a implementação da classe FuncionarioService, que gerencia as operações relacionadas aos funcionários.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.BLL.Services
{
    public class FuncionarioService : IFuncionarioService // Implementa a interface IFuncionarioServico
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        // Método para obter todos os funcionários
        public List<Funcionario> ObterTodos()
        {
            return _funcionarioRepositorio.GetAll();
        }
        public Funcionario ObterPorId(int id)
        {
            return _funcionarioRepositorio.GetById(id);
        }

        // Método para obter uma lista de funcionários pelo nome ou cpf
        public Funcionario ObterPorNomeOuCPF(string nome)
        {
            return _funcionarioRepositorio.GetByNameOrCPF(nome);
        }

        // Adiciona um novo funcionário e verifica se o CPF já existe e se é válido
        public void Adicionar(Funcionario funcionario)
        {
            // Verifica se o campo Nome está vazio
            if (String.IsNullOrEmpty(funcionario.Nome))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            // Verifica se o campo CPF está vazio
            if (String.IsNullOrEmpty(funcionario.CPF))
            {
                throw new ArgumentException("O CPF é obrigatório.");
            }

            // Verifica se o CPF é valido
            if (!CPFValidate(funcionario.CPF))
            {
                throw new ArgumentException("O CPF deve conter 11 dígitos e ser composto apenas por números.");
            }

            // Verifica se o CPF já existe
            var funcionarioExistente = _funcionarioRepositorio.GetAll().FirstOrDefault(f => f.CPF == funcionario.CPF);
            if (funcionarioExistente != null)
            {
                throw new ArgumentException("O CPF já está cadastrado.");
            }

            //Verifica se a Situacao é ativo
            if (funcionario.Situacao != 'A' )
            {
                throw new ArgumentException("O funcionario não pode ser cadastrado como 'I' (Inativo).");
            }

            funcionario.DataAlteracao = DateTime.Now;
            _funcionarioRepositorio.Add(funcionario);

        }
        // Atualiza um funcionário existente e verifica se o CPF já existe e se é válido
        public void Atualizar(Funcionario funcionario)
        {
            // Verifica se o campo Nome está vazio
            if (String.IsNullOrEmpty(funcionario.Nome))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            // Verifica se o campo CPF está vazio
            if (String.IsNullOrEmpty(funcionario.CPF))
            {
                throw new ArgumentException("O CPF é obrigatório.");
            }

            // Verifica se o CPF é valido
            if (!CPFValidate(funcionario.CPF))
            {
                throw new ArgumentException("O CPF deve conter 11 dígitos e ser composto apenas por números.");
            }

            //Verifica se a Situacao é válida
            if (funcionario.Situacao != 'A' && funcionario.Situacao != 'I')
            {
                throw new ArgumentException("A situação deve ser 'A' (Ativo) ou 'I' (Inativo).");
            }


            //Define a data de alteração como a data atual
            funcionario.DataAlteracao = DateTime.Now;
            _funcionarioRepositorio.Update(funcionario);
        }

        // Verifica se o CPF é válido
        private bool CPFValidate(string cpf)
        {
            // Verifica se o CPF contém apenas dígitos e tem 11 caracteres
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }
    }
}
