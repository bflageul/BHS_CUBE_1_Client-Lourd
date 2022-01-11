using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Negosud_RichClient.Data;
using System.Configuration;
using System.Windows;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<NegosudDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["NegosudDbConStr"].ConnectionString);
            });

            services.AddSingleton<ProductWindow>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //MainWindow window = new();
            //window.Show();

            ProductWindow window = serviceProvider.GetService<ProductWindow>();
            window.Show();
        }
    }
}
