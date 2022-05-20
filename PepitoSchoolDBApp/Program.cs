using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PepitoSchoolDBApp.Domain.Interfaces;
using PepitoSchoolDBApp.Domain.PepitoSchoolDBEntities;
using PepitoSchoolDBApp.Infraestructure.Repositories;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PepitoSchoolDBApp.Applications.Services;
using PepitoSchoolDBApp.Applications.Interfaces;
using Microsoft.Extensions.Configuration;

namespace PepitoSchoolDBApp
{
    static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables().Build();


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var services = new ServiceCollection();

            services.AddDbContext<PepitoSchoolContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IPepitoSchoolDbContext, PepitoSchoolContext>();
            services.AddScoped<IEstudianteRepository, EFEstudianteRepository>();
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<Form1>();

            using (var serviceScope = services.BuildServiceProvider())
            {
                var main = serviceScope.GetRequiredService<Form1>();
                Application.Run(main);
            }
          
        }
    }
}
