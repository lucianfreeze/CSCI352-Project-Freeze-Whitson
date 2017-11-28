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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.IO;

namespace Interface_Mockups
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=.\Database1.accdb;";

            // SQL query
            string queryString = "SELECT Password FROM Users WHERE Username='" + UsernameBox.Text + "'";

            // initialize connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            
            // query
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if(PasswordBox.Text == reader[0].ToString())
                        {
                            Dashboard dashboard = new Dashboard();
                            Close();
                            dashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password incorrect!");
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // https://stackoverflow.com/questions/10273940/using-access-databases-in-c
            // https://stackoverflow.com/questions/30315714/how-to-check-username-and-password-in-access-database
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Close();
        }
    }
}
