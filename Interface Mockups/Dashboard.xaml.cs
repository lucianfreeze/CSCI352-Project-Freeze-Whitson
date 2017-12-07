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
        private int checkingID;
        private int savingsID;

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

            // SQL query
            string queryString = "SELECT CheckingID FROM Users WHERE Username = '" + username + "';";

            // query
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        checkingID = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // SQL query
            string queryString1 = "SELECT SavingsID FROM Users WHERE Username = '" + username + "';";

            // query
            using (OleDbCommand command = new OleDbCommand(queryString1, connection))
            {
                try
                {
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        savingsID = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void checking_Click(object sender, RoutedEventArgs e)
        {

            Transactions checking = new Transactions(checkingID, username);
            checking.Show();
        }

        private void savings_Click(object sender, RoutedEventArgs e)
        {
            Transactions savings = new Transactions(savingsID, username);
            savings.Show();
        }

        private void chkTransSave_Click(object sender, RoutedEventArgs e)
        {
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";

            // initialize connection
            OleDbConnection connection = new OleDbConnection(connectionString);


            // SQL query strings
            string queryString = "INSERT INTO Transactions (TransactionAmount, TransactionDate, AccountID, Username, TransactionDescription) VALUES ('" + chkTransAmt.Text + "','" + checkingDate.ToString() + "','" + checkingID + "','" + username + "','" + chkTransDesc.Text + "');";
            string balanceUpdate = "UPDATE Account " +
                                   "SET AccountBalance = AccountBalance + " + Convert.ToDouble(chkTransAmt.Text)
                                + " WHERE AccountID = " + checkingID + ";";
            //                      UPDATE Account SET AccountBalance = AccountBalance + checkingBalance WHERE Account ID = checkingID;
            // query and query for amount of rows
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            using (OleDbCommand cmd = new OleDbCommand(balanceUpdate, connection))
            {
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaction Added Successfully!");
                    Dashboard update = new Dashboard(username);
                    update.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }
        }

        private void savTransSave_Click(object sender, RoutedEventArgs e)
        {
            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";

            // initialize connection
            OleDbConnection connection = new OleDbConnection(connectionString);

            // SQL query strings
            string queryString = "INSERT INTO Transactions (TransactionAmount, TransactionDate, AccountID, Username, TransactionDescription) VALUES ('" + savTransAmt.Text + "','" + savingsDate.ToString() + "','" + savingsID + "','" + username + "','" + savTransDesc.Text + "');";
            string balanceUpdate = "UPDATE Account " +
                                   "SET AccountBalance = AccountBalance + " + Convert.ToDouble(savTransAmt.Text)
                                + " WHERE AccountID = " + savingsID + ";";
            //                      UPDATE Account SET AccountBalance = AccountBalance + checkingBalance WHERE Account ID = checkingID;
            // query and query for amount of rows
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            using (OleDbCommand cmd = new OleDbCommand(balanceUpdate, connection))
            {
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaction Added Successfully!");
                    Dashboard update = new Dashboard(username);
                    update.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }

        }

        private void chkTransAmt_GotFocus(object sender, RoutedEventArgs e)
        {
            chkTransAmt.Clear();
        }

        private void chkTransDesc_GotFocus(object sender, RoutedEventArgs e)
        {
            chkTransDesc.Clear();
        }

        private void savTransAmt_GotFocus(object sender, RoutedEventArgs e)
        {
            savTransAmt.Clear();
        }

        private void savTransDesc_GotFocus(object sender, RoutedEventArgs e)
        {
            savTransDesc.Clear();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            imagebackground.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            imagebackground.Background = new SolidColorBrush(Colors.Purple);
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            imagebackground.Background = new SolidColorBrush(Colors.DarkGreen);
        }
    }
}
