using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerencTicketsRefeicao.BLL.Interfaces;

namespace GerencTicketsRefeicao.UI
{
    public partial class FormExibirTickets : Form
    {

        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        // Construtor que recebe as dependências
        public FormExibirTickets(IFuncionarioService funcionarioService, ITicketService ticketServic)
        {
            InitializeComponent();
        }
    }
}
