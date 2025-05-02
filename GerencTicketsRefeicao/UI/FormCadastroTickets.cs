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
using GerencTicketsRefeicao.BLL.Services;
using GerencTicketsRefeicao.Models;

namespace GerencTicketsRefeicao.UI
{

    public partial class FormCadastroTickets : Form
    {
        // Declaração das dependências
        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        private readonly int _idTicket;
        private readonly int _idFuncionario;

        // Construtor que recebe as dependências
        public FormCadastroTickets(IFuncionarioService funcionarioService, ITicketService ticketService, int idTicket, int idFuncionario)
        {
            _funcionarioService = funcionarioService;
            _ticketService = ticketService;
            _idTicket = idTicket;
            _idFuncionario = idFuncionario;

            // Inicializa os componentes do formulário
            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormCadastroTickets_Load(object sender, EventArgs e)
        {

            // Preenche o ComboBox de situação com os valores possíveis
            cbSituacao.Items.Add("A");
            cbSituacao.Items.Add("I");
            cbSituacao.SelectedIndex = 0; // Define o valor padrão como "A" (Ativo)

            // Carrega os funcionários na ComboBox
            carregarFuncionariosNaComboBox();

            // Verifica se o ID do ticket é maior que 0 (indica que é um registro existente)
            if (_idTicket > 0)
            {
                // Carrega os dados do ticket no formulário
                carregarDadosTicket(_idTicket, _idFuncionario);
            }
        }


        // Evento de clique no botão "Salvar"
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // chama o método para adicionar ou salvar o ticket
            addOuSalvarTicket(_idTicket);
        }

        // Evento de clique no botão "Cancelar"
        private void btnFechar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário sem salvar
            this.Close();
        }


        // carrega os funcionários na comboBox nome
        private void carregarFuncionariosNaComboBox()
        {
            // Obtém todos os funcionários
            var funcionarios = _funcionarioService.ObterTodos();
            // Preenche o ComboBox com os funcionários
            cbNome.DataSource = funcionarios;
            cbNome.DisplayMember = "Nome";
            cbNome.ValueMember = "Id";
            cbNome.SelectedIndex = -1; // Define o índice selecionado como -1 para não selecionar nenhum item
        }

        // carrega os dados do ticket no formulário
        private void carregarDadosTicket(int idTicket, int idFuncionario)
        {
            // Obtém o nome do funcionário pelo ID
            var funcionario = _funcionarioService.ObterPorId(idTicket);
            var nomeFuncionario = funcionario != null ? funcionario.Nome : "Funcionário não encontrado";

            // Obtém o ticket pelo ID
            Ticket ticket = _ticketService.ObterPorId(idTicket);

            // Preenche os campos do formulário com os dados do ticket
            txtId.Text = ticket.Id.ToString();

            cbNome.SelectedValue = idFuncionario;
            numQuantidade.Text = ticket.Quantidade.ToString();
            cbSituacao.SelectedItem = ticket.Situacao;
            dtpDataAlt.Value = ticket.DataAlteracao;
        }


        //adiciona ou salva o ticket
        private void addOuSalvarTicket(int idTicket)
        {
            try
            {
                // Cria um novo objeto Ticket
                var ticket = idTicket != 0
                    ? _ticketService.ObterPorId(idTicket)
                    : new Ticket();

                // Preenche os dados do ticket com os valores dos campos do formulário
                ticket.FuncionarioId = Convert.ToInt32(cbNome.SelectedValue);
                ticket.Quantidade = Convert.ToInt32(numQuantidade.Value);
                ticket.Situacao = cbSituacao.Text;
                ticket.DataAlteracao = dtpDataAlt.Value;
                // Verifica se o ID do ticket é maior que 0 (indica que é um registro existente)
                if (idTicket > 0)
                {
                    // Atualiza o ticket existente
                    _ticketService.Atualizar(ticket);
                    MessageBox.Show("Ticket atualizado com sucesso!");
                }
                else
                {
                    // Adiciona um novo ticket
                    _ticketService.Adicionar(ticket);
                    MessageBox.Show("Ticket adicionado com sucesso!");
                }
                // Fecha o formulário após salvar
                this.Close();
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção
                MessageBox.Show("Erro ao salvar o ticket: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                // Fecha o formulário após salvar
                this.Close();
        }
    }
}
