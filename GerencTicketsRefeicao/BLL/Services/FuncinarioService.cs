using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerencTicketsRefeicao.BLL.Interfaces;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.Models;


namespace GerenciadorValeRefeicoes.BLL
{
    public class FuncionarioService : IFuncionarioService // Implementa a interface IFuncionarioServico
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public List<Funcionario> GetAllFunc()
        {
            return _funcionarioRepositorio.GetAll();
        }
        public Funcionario GetFuncById(int id)
        {
            return _funcionarioRepositorio.GetById(id);
        }

        // Adiciona um novo funcionário e verifica se o CPF já existe e se é válido
        public void AddFunc(Funcionario funcionario)
        {
            if (String.IsNullOrEmpty(funcionario.Nome))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            if (String.IsNullOrEmpty(funcionario.CPF))
            {
                throw new ArgumentException("O CPF é obrigatório.");
            }

            if (!CPFValidate(funcionario.CPF))
            {
                throw new ArgumentException("O CPF deve conter 11 dígitos e ser composto apenas por números.");
            }

            funcionario.DataAlteracao = DateTime.Now;
            _funcionarioRepositorio.Add(funcionario);

        }
        // Atualiza um funcionário existente e verifica se o CPF já existe e se é válido
        public void UpdateFunc(Funcionario funcionario)
        {
            if (String.IsNullOrEmpty(funcionario.Nome))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            if (String.IsNullOrEmpty(funcionario.CPF))
            {
                throw new ArgumentException("O CPF é obrigatório.");
            }

            if (!CPFValidate(funcionario.CPF))
            {
                throw new ArgumentException("O CPF deve conter 11 dígitos e ser composto apenas por números.");
            }

            if (CPFExists(funcionario.CPF))
            {
                throw new ArgumentException("O CPF já existe.");
            }

            funcionario.DataAlteracao = DateTime.Now;
            _funcionarioRepositorio.Update(funcionario);
        }


        // Verifica se o CPF é válido
        // O CPF deve ter 11 dígitos e ser composto apenas por números
        // Se o CPF não for válido, lança uma exceção
        private bool CPFValidate(String cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {
                return false;
            }

            return cpf.All(char.IsDigit);
        }
        // Confere se o CPF já existe
        private bool CPFExists(String cpf)
        {
            return _funcionarioRepositorio.GetAll().Any(f => f.CPF == cpf);
        }

    }
}
