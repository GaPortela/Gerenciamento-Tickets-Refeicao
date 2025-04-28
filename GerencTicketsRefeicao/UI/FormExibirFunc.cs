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
    public partial class FormExibirFunc : Form
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        // Construtor que recebe as dependências
        public FormExibirFunc(IFuncionarioService funcionarioService, ITicketService ticketService)
        {
            InitializeComponent();
        }

        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                MessageBox.Show("Você clicou no botão de editar!");
            }
        }
    }
}
