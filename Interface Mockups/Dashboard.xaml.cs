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
using System.Data.OleDb;

namespace Interface_Mockups
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard(string username)
        {
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";

            // SQL query
            string queryString = "SELECT Account.AccountBalance FROM Account INNER JOIN Users ON Account.AccountID = Users.CheckingID WHERE Users.Username = " + username + ";";

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
                        checking.Content += reader[0].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            InitializeComponent();
            Greeting.Content = "Hello, " + username + "!";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logIn = new MainWindow();
            logIn.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Transactions checking = new Transactions();
            checking.Show();
        }

        private void savings_Click(object sender, RoutedEventArgs e)
        {
            Transactions savings = new Transactions();
            savings.Show();
        }
    }
}
