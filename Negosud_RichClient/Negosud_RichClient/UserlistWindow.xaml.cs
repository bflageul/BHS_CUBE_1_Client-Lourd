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
    /// Interaction logic for UserlistWindow.xaml
    /// </summary>
    public partial class UserlistWindow : Window
    {
        private readonly NegosudDbContext context;
        User NewUser = new();
        User selectedUser = new();

        public UserlistWindow(NegosudDbContext context)
        {
            InitializeComponent();
            this.context = context;
            GetUsers();
            NewUserGrid.DataContext = NewUser;
        }

        private void GetUsers()
        {
            UserlistDG.ItemsSource = context.Users.ToList();
        }

        private void AddUser(object s, RoutedEventArgs e)
        {
            context.Users.Add(NewUser);
            context.SaveChanges();
            GetUsers();
            NewUser = new User();
            NewUserGrid.DataContext = NewUser;
        }

        private void UpdateUser(object s, RoutedEventArgs e)
        {
            context.Update(selectedUser);
            context.SaveChanges();
            GetUsers();
        }

        private void SelectUserToEdit(object s, RoutedEventArgs e)
        {
            selectedUser = (s as FrameworkElement).DataContext as User;
            UpdateUserGrid.DataContext = selectedUser;
        }

        private void DeleteUser(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Product;
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            GetUsers();
        }

        private void BtnMenu(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new();
            window.Show();
            this.Close();
        }
    }
}
