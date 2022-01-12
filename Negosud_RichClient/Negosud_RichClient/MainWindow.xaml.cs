using Microsoft.EntityFrameworkCore;
using Negosud_RichClient.Data;
using Negosud_RichClient.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NegosudDbContext _context = new NegosudDbContext();

        private CollectionViewSource categoryViewSource;

        // MainWindow ctor providing user info from Model.UserInfo (when connected)
        public MainWindow()
        {
            InitializeComponent();
            lblFirstname.Content = UserInfo.Firstname;
            lblLastname.Content = UserInfo.Lastname;

            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            //_context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Users.Load();

            // bind to the source
            categoryViewSource.Source =
                _context.Users.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }

        private void BtnMenu(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new();
            window.Show();
            this.Close();
        }
    }
}
