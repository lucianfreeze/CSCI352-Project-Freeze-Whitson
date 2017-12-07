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
        private string username;
        private int accountID;

        public Dashboard(string username)
        {
            this.username = username;
            InitializeComponent();
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";

            // SQL query
            string checkingQuery = "SELECT AccountBalance FROM Account WHERE Username = '" + username + "' AND AccountTypeID = 1;";
            string savingsQuery = "SELECT AccountBalance FROM Account WHERE Username = '" + username + "' AND AccountTypeID = 2;";

            // initialize connection
            OleDbConnection connection = new OleDbConnection(connectionString);

            // query
            using (OleDbCommand command = new OleDbCommand(checkingQuery, connection))
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
                    MessageBox.Show(ex.Message + "dashboard");
                }
            }


            // query
            using (OleDbCommand command = new OleDbCommand(savingsQuery, connection))
            {
                try
                {
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        savings.Content += reader[0].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "dashboard");
                }
            }
            connection.Close();
            Greeting.Content = "Hello, " + username + "!";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logOut = new MainWindow();
            logOut.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";

            // SQL query
            string queryString = "SELECT CheckingID FROM Users WHERE Username = '" + username + "';";

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
                        accountID = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            Transactions checking = new Transactions(accountID, username);
            checking.Show();
        }

        private void savings_Click(object sender, RoutedEventArgs e)
        {
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";

            // SQL query
            string queryString = "SELECT SavingsID FROM Users WHERE Username = '" + username + "';";

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
                        accountID = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            Transactions savings = new Transactions(accountID, username);
            savings.Show();
        }
    }
}
