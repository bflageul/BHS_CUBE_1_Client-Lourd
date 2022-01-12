using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Negosud_RichClient.Data;
using Negosud_RichClient.PasswordHash;
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
            services.AddScoped<NegosudDbContext>();
            services.AddScoped<PwdHasher>();
            services.AddOptions();
            services.AddSingleton<LoginWindow>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow window = new LoginWindow(serviceProvider.GetService<PwdHasher>());
            window.Show();

            //ProductWindow window = serviceProvider.GetService<ProductWindow>();
            //window.Show();
        }
    }
}
