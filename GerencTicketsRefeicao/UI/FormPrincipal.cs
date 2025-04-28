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
    public partial class FormPrincipal : Form
    {

        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        // Construtor que recebe as dependências
        public FormPrincipal(IFuncionarioService funcionarioService, ITicketService ticketService)
        {
            _funcionarioService = funcionarioService;
            _ticketService = ticketService;

            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Carregar o painel com o formulário padrão, se necessário
            CarregarFormulario(new FormExibirTickets(_funcionarioService, _ticketService));
        }

        private void btnGerencFuncionarios_Click(object sender, EventArgs e)
        {
            CarregarFormulario(new FormExibirFunc(_funcionarioService, _ticketService));
        }

        private void btnGerencTickets_Click(object sender, EventArgs e)
        {
            CarregarFormulario(new FormExibirTickets(_funcionarioService, _ticketService));
        }

        private void CarregarFormulario(Form formulario)
        {
            // Limpa o painel antes de carregar um novo formulário
            panelFormularios.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formulario);
            formulario.Show();
        }
    }
}
