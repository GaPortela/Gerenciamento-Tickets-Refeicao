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
using GerencTicketsRefeicao.Models;

/*
 * Nome do arquivo: FormExibirTickets.cs
 * Descrição: Formulário para exibir e gerenciar tickets de refeição.
 * Autor: Guilherme Alves Portela
 * Data: 01/05/2025
 */

namespace GerencTicketsRefeicao.UI
{
    public partial class FormExibirTickets : Form
    {

        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        // Construtor que recebe as dependências
        public FormExibirTickets(IFuncionarioService funcionarioService, ITicketService ticketService)
        {
            _funcionarioService = funcionarioService;
            _ticketService = ticketService;
            
            InitializeComponent();
        }

        private void FormExibirTickets_Load(object sender, EventArgs e)
        {
            carregarFuncionariosNoFiltro();
            carregarTickets();
        }

        // Evento de clique no botão "Filtrar"
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Verifica se o ComboBox de filtro está vazio
            if (cbFiltro.Text == "")
            {
                // Se estiver vazio, carrega todos os tickets
                carregarTickets();

                // Exibe uma mensagem informando que todos os tickets estão sendo exibidos
                MessageBox.Show("Todos os tickets estão sendo exibidos.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    // Obtém o ID do funcionário selecionado no ComboBox
                    int funcionarioId = Convert.ToInt32(cbFiltro.SelectedValue);
                    // Obtém os tickets filtrados pelo ID do funcionário
                    var tickets = _ticketService.ObterPorFuncionarioId(funcionarioId);
                    // Limpa o DataGridView
                    dgvTickets.Rows.Clear();
                    // Adiciona os tickets filtrados ao DataGridView
                    foreach (var t in tickets)
                    {
                        var funcionario = _funcionarioService.ObterPorId(t.FuncionarioId);
                        var nomeFuncionario = funcionario != null ? funcionario.Nome : "Funcionário não encontrado";

                        dgvTickets.Rows.Add(
                            t.Id,
                            funcionario.Id,
                            nomeFuncionario,
                            t.Quantidade,
                            t.Situacao == "A" ? "Ativo" : "Inativo",
                            t.DataAlteracao,
                            "Editar"
                        );
                    }
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao filtrar os tickets: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento de clique no botão "Novo registro"
        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário de cadastro de ticket
            abrirFormularioCadastroTicket(0, 0); // Passa 0 para indicar que é um novo registro
        }

        // Carrega os nomes dos funcionários no ComboBox de filtro
        private void carregarFuncionariosNoFiltro()
        {
            try
            {
                // Obtém todos os funcionários do serviço
                var funcionarios = _funcionarioService.ObterTodos();

                // Configura o ComboBox
                cbFiltro.DataSource = funcionarios;
                cbFiltro.DisplayMember = "Nome"; // Exibe o nome no ComboBox
                cbFiltro.ValueMember = "Id"; // Retorna o ID ao selecionar
                cbFiltro.SelectedIndex = -1; // Nenhum item selecionado inicialmente
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção
                MessageBox.Show($"Erro ao carregar os funcionários no filtro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Funcao para carregar os tickets no DataGridView
        private void carregarTickets()
        {
            try
            {
                // Obtém todos os tickets do serviço
                var tickets = _ticketService.ObterTodos();

                // Limpa o DataGridView
                dgvTickets.Rows.Clear();

                // Adiciona os tickets ao DataGridView
                foreach (var t in tickets)
                {
                    // Obtém o nome do funcionário pelo ID
                    var funcionario = _funcionarioService.ObterPorId(t.FuncionarioId);
                    var nomeFuncionario = funcionario != null ? funcionario.Nome : "Funcionário não encontrado";

                    dgvTickets.Rows.Add(
                        t.Id,
                        funcionario.Id,
                        nomeFuncionario, // Exibe o nome do funcionário
                        t.Quantidade,
                        t.Situacao == "A" ? "Ativo" : "Inativo",
                        t.DataAlteracao,
                        "Editar"
                    );
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção
                MessageBox.Show($"Erro ao carregar os dados dos tickets: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de clique no botão "Editar" dentro do DataGridView
        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) // Verifica se a coluna clicada é a do botão "Editar"
            {
                int numeroLinha = e.RowIndex; // Obtém o número da linha clicada

                // Verifica se a linha é válida
                if (numeroLinha >= 0)
                {
                    // Obtém o valor do campo "Id" da linha clicada
                    int idTicket = Convert.ToInt32(dgvTickets.Rows[numeroLinha].Cells[0].Value);
                    int idFuncionario = Convert.ToInt32(dgvTickets.Rows[numeroLinha].Cells[1].Value);

                    abrirFormularioCadastroTicket(idTicket, idFuncionario);
                }
            }
        }

        // Abrir o formulário de cadastro de ticket
        private void abrirFormularioCadastroTicket(int idTicket, int idFuncionario)
        {
            FormCadastroTickets formCadastroTickets = new FormCadastroTickets(_funcionarioService, _ticketService, idTicket, idFuncionario);
            formCadastroTickets.ShowDialog();
            carregarTickets();
        }
    }
}
