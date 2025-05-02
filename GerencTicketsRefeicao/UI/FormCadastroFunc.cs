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

/*
/* Nome do arquivo: FormCadastroFunc.cs
* Descrição: Formulário para cadastro e edição de funcionários.
* Autor: Guilherme Alves Portela
*/

namespace GerencTicketsRefeicao.UI
{
    
    public partial class FormCadastroFunc : Form
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ITicketService _ticketService;
        private readonly int _idFuncionario;
        // Construtor que recebe as dependências
        public FormCadastroFunc(IFuncionarioService funcionarioService, ITicketService ticketService, int idFuncionario)
        {
            _funcionarioService = funcionarioService;
            _ticketService = ticketService;
            _idFuncionario = idFuncionario;
            // Inicializa os componentes do formulário
            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormCadastroFunc_Load(object sender, EventArgs e)
        {

            // Preenche o ComboBox de situação com os valores possíveis
            cbSituacao.Items.Add("A");
            cbSituacao.Items.Add("I");
            cbSituacao.SelectedIndex = 0; // Define o valor padrão como "A" (Ativo)

            // Verifica se o ID do funcionário é maior que 0 (indica que é um registro existente)
            if (_idFuncionario > 0)
            {
                // Carrega os dados do funcionário no formulário
                carregarDadosFuncionario(_idFuncionario);
            }
        }

        // Evento de clique no botão "Salvar"
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // chama o método para adicionar ou salvar o funcionário
            addOuSalvarFuncionario(_idFuncionario);
        }

        // Evento de clique no botão "Cancelar"
        private void btnFechar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário sem salvar
            this.Close();
        }


        // carrega os dados do funcionário no formulário
        private void carregarDadosFuncionario(int idFuncionario)
        {
            // Obtém os dados do funcionário através do serviço
            var funcionario = _funcionarioService.ObterPorId(idFuncionario);

            // Preenche os campos do formulário com os dados do funcionário
            txtId.Text = funcionario.Id.ToString();
            txtNome.Text = funcionario.Nome;
            mtbCPF.Text = funcionario.CPF;
            cbSituacao.Text = funcionario.Situacao.ToString();
        }

        //adiciona ou salva o funcionário
        private void addOuSalvarFuncionario(int idFuncionario)
        {
            try
            {
                var funcionario = idFuncionario != 0
                    ? _funcionarioService.ObterPorId(idFuncionario)
                    : new Funcionario();

                // Atualiza ou define os dados do funcionário
                funcionario.Nome = txtNome.Text;
                funcionario.CPF = mtbCPF.Text;
                funcionario.Situacao = Convert.ToChar(cbSituacao.Text);
                funcionario.DataAlteracao = DateTime.Now;

                if (idFuncionario != 0)
                {
                    // Atualiza o funcionário existente
                    _funcionarioService.Atualizar(funcionario);
                    MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Adiciona um novo funcionário
                    _funcionarioService.Adicionar(funcionario);
                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Fecha o formulário após salvar ou em caso de erro
                this.Close();
            }
        }

    }
}
