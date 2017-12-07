// Authors: Lucian Freeze / Brett Whitson
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


public class UserAccount
{
    private string email { get; set; }
    private string password { get; set; }
    private string firstname { get; set; }
    private string lastname { get; set; } 

    public UserAccount(string firstname, string lastname, string email, string password)
    {
        this.email = email;
        this.password = password;
        this.firstname = firstname;
        this.lastname = lastname;
    }

    public void SaveAccount()
    {
        // connection arguments
        string connectionString =
        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=BankApplication.accdb;";

        // initialize connection
        OleDbConnection connection = new OleDbConnection(connectionString);

        // SQL query strings
        string queryString = "SELECT count(*) FROM Users WHERE Username='" + email + "'";
        string queryAcctAmtString = "SELECT count(*) FROM Account";

        // query and query for amount of rows
        using (OleDbCommand command = new OleDbCommand(queryString, connection))
        using (OleDbCommand amtCommand = new OleDbCommand(queryAcctAmtString, connection))
        {
            connection.Open();
            int result = (int)command.ExecuteScalar();
            int AcctNum = (int)amtCommand.ExecuteScalar();
            if (result == 0)
            {
                try
                {
                    string insertString = "INSERT INTO Users ([First], [Last], [Username], [Password], [CheckingID], [SavingsID]) VALUES ('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + Convert.ToInt32(AcctNum+1) + "','" + Convert.ToInt32(AcctNum+2) + "');";
                    string checkingInsert = "INSERT INTO Account ([AccountID], [AccountTypeID], [AccountBalance], [Username]) VALUES ('" + Convert.ToInt32(AcctNum + 1) + "','1','0.00','" + email + "');";
                    string savingsInsert =  "INSERT INTO Account ([AccountID], [AccountTypeID], [AccountBalance], [Username]) VALUES ('" + Convert.ToInt32(AcctNum + 2) + "','2','0.00','" + email + "');";
                    MessageBox.Show(insertString);
                    OleDbCommand cmd = new OleDbCommand(insertString, connection);
                    cmd.ExecuteNonQuery();
                    OleDbCommand ChkCmd = new OleDbCommand(checkingInsert, connection);
                    ChkCmd.ExecuteNonQuery();
                    OleDbCommand SavCmd = new OleDbCommand(savingsInsert, connection);
                    SavCmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"useraccount");
                }
            }
            else
            {
                MessageBox.Show("Account with Email '" + email + "' already exists!");
            }
            connection.Close();
        }

        // http://stepcoder.com/Articles/10014/how-to-insert-record-into-access-database-using-c-sharp-net

    }
    
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }
    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }
    public string FirstName
    {
        get
        {
            return firstname;
        }
        set
        {
            firstname = value;
        }
    }
    public string LastName
    {
        get
        {
            return lastname;
        }
        set
        {
            lastname = value;
        }
    }
}