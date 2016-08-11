using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	public class Account
	{
		public Account(string name, double balance, bool isLocked)
		{
			this.AccountName = name;
			this.Balance = balance;
			this.IsLocked = isLocked;
		}

		private List<double> Transactions = new List<double>();
		private string AccountName;
		private double Balance;
		private bool IsLocked;

		public string GetAccountName()
		{
			return AccountName;
		}

		public double GetAccountBalance()
		{
			return Balance;
		}

		public List<double> GetAllTransactions()
		{
			return Transactions;
		}

		public void SetLockedStatus(bool isLocked)
		{
			IsLocked = isLocked;
		}

		public bool GetLockedStatus()
		{
			return IsLocked;
		}

		public void Deposit(double amount)
		{
			Balance = Balance + amount;
			if(amount != 0) Transactions.Add(amount);
		}

		public bool Withdraw(double amount)
		{
			amount = amount - (amount+amount);

			if(!IsLocked && Balance >= 0)
			{
				Balance = Balance + amount;
				if (amount != 0) Transactions.Add(amount);
				if (Balance < 0) IsLocked = true;
				return true;
			}
			IsLocked = true;
			return false;
		}

		public override string ToString()
		{
			return "Account name: " + AccountName + ", Balance: " + Balance;
		}
	}
}
