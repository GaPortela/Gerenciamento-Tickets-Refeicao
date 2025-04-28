using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
