using Microsoft.Extensions.DependencyInjection;
using Negosud_RichClient.Data;
using Negosud_RichClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            lblFirstname.Content = UserInfo.Firstname;
        }

        private void BtnUserlist(object sender, RoutedEventArgs e)
        {
            NegosudDbContext context = new NegosudDbContext();
            UserlistWindow window = new UserlistWindow(context);
            window.Show();
            this.Close();
        }

        private void BtnProduct(object sender, RoutedEventArgs e)
        {
            NegosudDbContext context = new NegosudDbContext();
            ProductWindow window = new ProductWindow(context);
            window.Show();
            this.Close();
        }

        private void BtnMain(object sender, RoutedEventArgs e)
        {
            MainWindow window = new();
            window.Show();
            this.Close();
        }
    }
}
