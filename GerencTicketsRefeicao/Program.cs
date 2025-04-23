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

            var services = new ServiceCollection();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            services.AddTransient<IFuncionarioRepositorio>(sp => new FuncionarioRepositorio(connectionString));
            services.AddTransient<ITicketRepositorio>(sp => new TicketRepositorio(connectionString));
            services.AddTransient<IFuncionarioService, FuncionarioService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
