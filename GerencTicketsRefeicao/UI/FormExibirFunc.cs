using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerencTicketsRefeicao.BLL.Interfaces;

/*
 * Nome do arquivo: FormExibirFunc.cs
 * Descrição: Formulário para exibir e gerenciar funcionários.
 * Autor: Guilherme Alves Portela
 */


namespace GerencTicketsRefeicao.UI
{
    public partial class FormExibirFunc : Form
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        // Construtor que recebe as dependências
        public FormExibirFunc(IFuncionarioService funcionarioService, ITicketService ticketService)
        {
            _funcionarioService = funcionarioService;
            _ticketService = ticketService;

            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormExibirFunc_Load(object sender, EventArgs e)
        {
            carregarFuncionarios();
            carregarFuncionariosFiltro();
        }

        // Evento de clique no botão "Novo Registro"
        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário de cadastro de funcionário
            abrirFormularioCadastroFunc(0); // Passa 0 para indicar que é um novo registro
        }


        // Evento de clique no botão "Editar" dentro do DataGridView
        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) // Verifica se a coluna clicada é a do botão "Editar"
            {
                int numeroLinha = e.RowIndex; // Obtém o número da linha clicada

                // Verifica se a linha é válida
                if (numeroLinha >= 0)
                {
                    // Obtém o valor do campo "Id" da linha clicada
                    int idFuncionario = Convert.ToInt32(dgvFuncionarios.Rows[numeroLinha].Cells[0].Value);

                    abrirFormularioCadastroFunc(idFuncionario);
                }
            }
        }

        // Evento de clique no botão "Filtrar"
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Verifica se o ComboBox de filtro está vazio
            if (cbFiltro.Text == "")
            {
                // Se estiver vazio, carrega todos os funcionários
                carregarFuncionarios();
            }
            else
            {

                // Obtém o texto selecionado no ComboBox
                string conteudoFiltro = cbFiltro.Text.ToString();

                // Carrega os dados do funcionário selecionado
                var funcionario = _funcionarioService.ObterPorNomeOuCPF(conteudoFiltro);

                // Limpa as linhas existentes no DataGridView
                dgvFuncionarios.Rows.Clear();

                // Verifica se o funcionário foi encontrado
                if (funcionario != null)
                {
                    try
                    { // Adiciona os dados do funcionário selecionado
                        dgvFuncionarios.Rows.Add(funcionario.Id,
                        funcionario.Nome,
                        funcionario.CPF,
                        funcionario.Situacao == 'A' ? "Ativo" : "Inativo",
                        funcionario.DataAlteracao,
                        "Editar");
                    }
                    catch (Exception ex)
                    {// Exibe uma mensagem de erro caso ocorra uma exceção
                        MessageBox.Show($"Erro ao carregar os dados do funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Se o funcionário não for encontrado, exibe uma mensagem
                    MessageBox.Show("Funcionário não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Carrega os funcionarios no comboBox de filtro
        private void carregarFuncionariosFiltro()
        {
            try
            {
                // Obtém a lista de funcionários através do serviço
                var funcionarios = _funcionarioService.ObterTodos();
                // Limpa os itens existentes no ComboBox
                cbFiltro.Items.Clear();
                // Adiciona os funcionários ao ComboBox
                foreach (var f in funcionarios)
                {
                    cbFiltro.Items.Add(f.Nome);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Funcao para carregar os funcionários no DataGridView
        private void carregarFuncionarios()
        {
            try
            {
                // Obtém a lista de funcionários através do serviço
                var funcionarios = _funcionarioService.ObterTodos();

                // Limpa as linhas existentes no DataGridView
                dgvFuncionarios.Rows.Clear();

                // Adiciona os dados diretamente às colunas existentes
                foreach (var f in funcionarios)
                {
                    dgvFuncionarios.Rows.Add(
                        f.Id,
                        f.Nome,
                        f.CPF,
                        f.Situacao == 'A' ? "Ativo" : "Inativo",
                        f.DataAlteracao,
                        "Editar"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirFormularioCadastroFunc(int idFuncionario)
        {
            FormCadastroFunc formCadastroFunc = new FormCadastroFunc(_funcionarioService, _ticketService, idFuncionario);
            formCadastroFunc.ShowDialog();
            carregarFuncionarios();
        }
    }
}
