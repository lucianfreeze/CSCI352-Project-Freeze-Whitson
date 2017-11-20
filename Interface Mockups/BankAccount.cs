using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BankAccount
{
    private float Balance;
    private string AccountName;

	public BankAccount()
	{
        Balance = 0;
        AccountName = "account";
	}
}

public class CheckingAccount : BankAccount
{

}

public class SavingsAccount : BankAccount
{

}