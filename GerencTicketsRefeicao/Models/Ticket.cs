using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * GerencTicketsRefeicao - Sistema de Gerenciamento de Tickets de Refeição
 * 
 * Este arquivo contém a definição da classe Ticket, que representa um ticket de refeição.
 * 
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public int Quantidade { get; set; }
        public string Situacao { get; set; } // "A" para Ativo, "I" para Inativo
        public DateTime DataAlteracao { get; set; }
    }
}
