using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GerencTicketsRefeicao.UI;
using GerencTicketsRefeicao.DAL.Implements;
using GerencTicketsRefeicao.DAL.Interfaces;
using GerencTicketsRefeicao.BLL.Interfaces;
using GerencTicketsRefeicao.BLL.Services;

/*
 * Nome do arquivo: Program.cs
 * Descrição: Ponto de entrada principal para o aplicativo.
 * Autor: Guilherme Alves Portela
 */

namespace GerencTicketsRefeicao
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurações do aplicativo
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Obtém a string de conexão do arquivo de configuração
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Configuração do Dependency Injection
            var services = new ServiceCollection();

            // Adiciona as dependências
            services.AddTransient<IFuncionarioRepositorio>(sp => new FuncionarioRepositorio(connectionString));
            services.AddTransient<ITicketRepositorio>(sp => new TicketRepositorio(connectionString));
            services.AddTransient<IFuncionarioService, FuncionarioService>(); // Implementa a interface IFuncionarioService
            services.AddTransient<ITicketService, TicketService>(); // Implementa a interface ITicketService

            // Configura o ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve as dependências
            var funcionarioService = serviceProvider.GetRequiredService<IFuncionarioService>();
            var ticketService = serviceProvider.GetRequiredService<ITicketService>();

            // Inicializa o formulário principal
            Application.Run(new FormPrincipal(funcionarioService, ticketService));
        }
    }
}
