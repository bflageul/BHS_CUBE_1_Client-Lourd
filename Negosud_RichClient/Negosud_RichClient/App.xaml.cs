using System.Windows;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow window = new();
            //if (e.Args.Length == 1)
            //	MessageBox.Show("Now opening file: \n\n" + e.Args[0]);
            window.Show();
        }
    }
}
