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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            var services = new ServiceCollection();

            services.AddTransient<IFuncionarioRepositorio>(sp => new FuncionarioRepositorio(connectionString));
            services.AddTransient<ITicketRepositorio>(sp => new TicketRepositorio(connectionString));
            services.AddTransient<IFuncionarioService, FuncionarioService>(); // Implementa a interface IFuncionarioService
            services.AddTransient<ITicketService, TicketService>(); // Implementa a interface ITicketService

            var serviceProvider = services.BuildServiceProvider();

            var funcionarioService = serviceProvider.GetRequiredService<IFuncionarioService>();
            var ticketService = serviceProvider.GetRequiredService<ITicketService>();

            Application.Run(new FormPrincipal(funcionarioService, ticketService));
        }
    }
}
