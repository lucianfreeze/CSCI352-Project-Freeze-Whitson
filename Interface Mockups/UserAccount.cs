using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UserAccount
{
    private string Email;
    private string Password;
    private string FirstName;
    private string LastName;
    private List<BankAccount> BankAccounts;

    public UserAccount(string Email, string Password, string FirstName, string LastName)
	{
        this.Email = Email;
        this.Password = Password;
        this.FirstName = FirstName;
        this.LastName = LastName;
	}

    public void SignIn()
    {

    }
}
