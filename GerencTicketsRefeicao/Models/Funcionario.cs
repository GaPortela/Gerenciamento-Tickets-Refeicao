using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a definição da classe Funcionario, que representa um funcionário.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */


namespace GerencTicketsRefeicao.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Situacao { get; set; } // "A" para Ativo, "I" para Inativo
        public DateTime DataAlteracao { get; set; }
    }
}
