using Microsoft.Data.SqlClient;
using Negosud_RichClient.Data;
using Negosud_RichClient.Models;
using Negosud_RichClient.PasswordHash;
using System;
using System.Configuration;
using System.Windows;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IPwdHasher _pwdHasher;
        // LoginWindow ctor
        public LoginWindow(IPwdHasher pwdHasher)
        {
            InitializeComponent();
            _pwdHasher = pwdHasher;
        }

        private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            string message = "Mot de passe incorrect";
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            bool logResult = _pwdHasher.Check(username, password);

            if (logResult is true)
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Info", (MessageBoxButton)1);
            }

        }

        //// Declaring mandatory variables in order to connect to Db
        //private SqlConnection con;
        //private SqlCommand cmd;
        //private SqlDataReader reader;
        //static readonly String connectionString = ConfigurationManager.ConnectionStrings["NegosudDbConStr"].ConnectionString;
        ////static String connectionString = @"Data Source=192.168.0.192;Initial Catalog=DBCustomer;User ID=sa;Password=1234;";


        //// Login button method (for now, it only check if username exist, then print firstname and lastname in a new window)
        //private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        //{
        //    String message = "Utilisateur inconnu";
        //    try
        //    {
        //        con = new SqlConnection(connectionString);
        //        con.Open();
        //        //cmd = new SqlCommand("Select * from tblCustomerInfo where CustomerEmail=@CustomerEmail", con);
        //        cmd = new SqlCommand("Select * from Users where Username=@Username", con);
        //        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            //if (reader["HashPassword"].ToString().Equals(txtPassword.Password.ToString(), StringComparison.InvariantCulture))
        //            if (reader["Username"].ToString().Equals(txtUsername.Text.ToString()))
        //            {
        //                message = "1";
        //                //UserInfo.CustomerEmail = txtUsername.Text.ToString();
        //                UserInfo.Firstname = reader["Firstname"].ToString();
        //                UserInfo.Lastname = reader["Lastname"].ToString();
        //            }
        //        }

        //        reader.Close();
        //        reader.Dispose();
        //        cmd.Dispose();
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message.ToString();
        //    }


        //    if (message == "1")
        //    {
        //        MainWindow mainWindow = new();
        //        mainWindow.Show();
        //        this.Close();
        //    }
        //    else
        //        MessageBox.Show(message, "Info");
        //}



        // Minimize window method
        private void BtnActionMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Resize window method
        private void Thumb_OnDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Left += e.HorizontalChange;
            Top += e.VerticalChange;
        }

        // Close window method
        private void BtnActionClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
