using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
