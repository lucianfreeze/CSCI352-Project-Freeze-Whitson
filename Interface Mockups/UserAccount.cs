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

    private List<BankAccount> BankAccounts;

    public UserAccount(string firstname, string lastname, string email, string password)
    {
        this.email = email;
        this.password = password;
        this.firstname = firstname;
        this.lastname = lastname;
    }

    public void SignIn()
    {
        string path = "Accounts/UserAccounts.txt";
        string[] fileInfo;
        string info = File.ReadAllText(path);
        char newline = '\n';
        fileInfo = info.Split(newline);
    }

    public void SaveAccount()
    {
        // connection arguments
        string connectionString =
        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=.\Database1.accdb;";

        // initialize connection
        OleDbConnection connection = new OleDbConnection(connectionString);

        // SQL query
        string queryString = "SELECT count(*) FROM Users WHERE Username='" + email + "'";
        string queryAmtString = "SELECT count(*) FROM Users";

        // query
        using (OleDbCommand command = new OleDbCommand(queryString, connection))
        using (OleDbCommand amtCommand = new OleDbCommand(queryAmtString, connection))
        {
            connection.Open();
            int result = (int)command.ExecuteScalar();
            int amtRows = (int)amtCommand.ExecuteScalar();
            if (result == 0)
            {
                try
                {
                    string insertString = "INSERT INTO Users ([ID], [First], [Last], [Username], [Password]) VALUES ('" + (amtRows+ 1) + "','" + firstname + "','" + lastname + "','" + email + "','" + password + "');";
                    MessageBox.Show(insertString);
                    OleDbCommand cmd = new OleDbCommand(insertString, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
    public bool password_matches(string entered)
    {
        if (entered == password)
            return true;
        return false;
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