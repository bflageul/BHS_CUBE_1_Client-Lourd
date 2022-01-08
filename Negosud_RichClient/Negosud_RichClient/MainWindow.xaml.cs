using Negosud_RichClient.Models;
using System.Windows;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // MainWindow ctor providing user info from Model.UserInfo (when connected)
        public MainWindow()
        {
            InitializeComponent();
            lblFirstname.Content = UserInfo.Firstname;
            lblLastname.Content = UserInfo.Lastname;
        }

    }
}
