using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	public class BankHandler
	{
		private Customer theCustomer;
		private Account initialAccount;
		
		public BankHandler()
		{
			theCustomer = new Customer("Customer");
			initialAccount = new Account("Vacation savings", 7700.50, false);
			theCustomer.AddAccount(initialAccount);
		}

		public void AddAccountToCustomer(Account account)
		{
			theCustomer.AddAccount(account);
		}

		public List<Account> GetAllCustomerAccounts()
		{
			return theCustomer.GetAllAccounts();
		}

		public Account GetSpecificCustomerAccount(string accountName)
		{
			return theCustomer.GetSpecificAccount(accountName);
		}
	}
	
}
