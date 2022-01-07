using Microsoft.Data.SqlClient;
using Negosud_RichClient.Models;
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
        public LoginWindow()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        static readonly String connectionString = ConfigurationManager.ConnectionStrings["NegosudDb"].ConnectionString;
        //static String connectionString = @"Data Source=192.168.0.192;Initial Catalog=DBCustomer;User ID=sa;Password=1234;";

        private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            String message = "Invalid Credentials";
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                //cmd = new SqlCommand("Select * from tblCustomerInfo where CustomerEmail=@CustomerEmail", con);
                cmd = new SqlCommand("Select * from Users where Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //if (reader["HashPassword"].ToString().Equals(txtPassword.Password.ToString(), StringComparison.InvariantCulture))
                    if (reader["Username"].ToString().Equals(txtUsername.Text.ToString(), StringComparison.InvariantCulture))
                    {
                        message = "1";
                        UserInfo.CustomerEmail = txtUsername.Text.ToString();
                        UserInfo.CustomerName = reader["CustomerName"].ToString();
                    }
                }

                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
            if (message == "1")
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show(message, "Info");
        }

        private void BtnActionMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Thumb_OnDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Left += e.HorizontalChange;
            Top += e.VerticalChange;
        }

        private void BtnActionClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //this.Close();
        }
    }
}
