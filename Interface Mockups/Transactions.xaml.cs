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
using System.Data;

namespace Interface_Mockups
{
    /// <summary>
    /// Interaction logic for Checking.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        public Transactions(int accountID, string username)
        {
            InitializeComponent();

            // connection arguments
            string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=BankApplication.accdb;";
            string queryString;
            // SQL query
            if(accountID % 2 == 0)
                queryString = "SELECT TransactionID, TransactionDate, TransactionDescription, TransactionAmount FROM Transactions WHERE Username= '" + username + "' AND AccountID mod 2 = 0;";
            else
                queryString = "SELECT TransactionID, TransactionDate, TransactionDescription, TransactionAmount FROM Transactions WHERE Username= '" + username + "' AND AccountID mod 2 <> 0;";

            // initialize connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))


            // query
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
                    DataTable table = new DataTable();
                    adapter.FillSchema(table, SchemaType.Source);
                    adapter.Fill(table);
                    dataGrid.ItemsSource = table.DefaultView;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

    }
}
