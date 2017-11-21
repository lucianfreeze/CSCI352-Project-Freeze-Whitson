using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;


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
        SignIn();
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
        string path = "Accounts/UserAccounts.txt";

        List<string> info = new List<string>()
        {
            firstname,
            lastname,
            email,
            password
        };
        File.AppendAllLines(path, info);
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