using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	public class Customer
	{
		public Customer(string name)
		{
			this.Name = name;
		}

		private List<Account> Accounts = new List<Account>();
		public string Name { get; set; }
		

		public bool AddAccount(Account account)
		{
			foreach (Account acc in Accounts)
			{
				if(acc.GetAccountName().Equals(account.GetAccountName())) return false;
			}

			Accounts.Add(account);
			
			return true;
		}

		public Account GetSpecificAccount(string name)
		{
			return Accounts.SingleOrDefault(account => account.GetAccountName() == name);
		}

		public List<Account> GetAllAccounts()
		{
			return Accounts;
		}
	}
}
