using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	class Program
	{
		
		static void Main(string[] args)
		{
			BankHandler bankHandler = new BankHandler();
			List<Account> accountList;
			Account tmpAccount;
			string accountName;
			int parsedWithdrawalInt, parsedDepositInt;


			int parsedInt = 1;

			while (parsedInt != 0)
			{
				Console.WriteLine("\n*********************************************************");
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7, or 0) of your choice:\n"
				+ "\n1. Add an account."
				+ "\n2. Display a list of all accounts."
				+ "\n3. Display detailed information of a specific account."
				+ "\n4. Make account deposit."
				+ "\n5. Make account withdrawal."
				+ "\n6. Make transfer between accounts."
				+ "\n7. Lock/unlock an account."
				+ "\n0. Exit the application");

				while (!int.TryParse(Console.ReadLine(), out parsedInt))
				{
					Console.WriteLine("Try again:");
				}

				switch (parsedInt)
				{
					case 1:
						int parsedBalanceInt;
						
						Console.Clear();
						Console.WriteLine("Type the name of the account:");

						accountName = Console.ReadLine();

						Console.WriteLine("Set the initial account balance:");

						while (!int.TryParse(Console.ReadLine(), out parsedBalanceInt))
						{
							Console.WriteLine("Try again:");
						}

						tmpAccount = new Account(accountName, parsedBalanceInt, false);

						bankHandler.AddAccountToCustomer(tmpAccount);

						Console.WriteLine("Added the account '" + accountName + "' to customer!");

						break;
					case 2:
			
						Console.Clear();

						Console.WriteLine("Listing all customer accounts:\n");
						
						accountList = bankHandler.GetAllCustomerAccounts();
						
						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}

						break;
					case 3:
						Console.Clear();
		
						accountList = bankHandler.GetAllCustomerAccounts();
						
						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}

						Console.WriteLine("\nType the name of the account you want to show details from:\n");

						accountName = Console.ReadLine();
						tmpAccount = bankHandler.GetSpecificCustomerAccount(accountName);

						if(tmpAccount != null)
						{
							List<double> transactionList = tmpAccount.GetAllTransactions();

							Console.WriteLine("Detailed information of account " + tmpAccount.GetAccountName() + ":\n");
							Console.WriteLine("Balance: " + tmpAccount.GetAccountBalance());
							Console.WriteLine("Locked for withdrawals: " + tmpAccount.GetLockedStatus());

							Console.WriteLine("Transactions: ");

							foreach (double ta in transactionList)
							{
								Console.WriteLine(ta);
							}
						}
						else
							Console.WriteLine("The account does not exist!");

						break;
					case 4:

						Console.Clear();

						accountList = bankHandler.GetAllCustomerAccounts();

						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}
						
						Console.WriteLine("\nEnter the name of the account you want to make a deposit to:\n");

						accountName = Console.ReadLine();
						tmpAccount = bankHandler.GetSpecificCustomerAccount(accountName);

						if(tmpAccount != null)
						{
							Console.WriteLine("Enter the amount you want to deposit to the account:\n");
							
							while (!int.TryParse(Console.ReadLine(), out parsedDepositInt))
							{
								Console.WriteLine("Try again:");
							}

							tmpAccount.Deposit(parsedDepositInt);

							Console.WriteLine("Deposited " + parsedDepositInt + " to the account!\n");
						}
						else
							Console.WriteLine("The account does not exist!");
		
						break;
					case 5:

						Console.Clear();

						accountList = bankHandler.GetAllCustomerAccounts();

						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}
						
						Console.WriteLine("\nEnter the name of the account you want to make a withdrawal from:\n");

						accountName = Console.ReadLine();
						tmpAccount = bankHandler.GetSpecificCustomerAccount(accountName);

						if(tmpAccount != null)
						{
							Console.WriteLine("Enter the amount you want to withdraw from the account:\n");
							
							while (!int.TryParse(Console.ReadLine(), out parsedWithdrawalInt))
							{
								Console.WriteLine("Try again:");
							}

							if(tmpAccount.Withdraw(parsedWithdrawalInt))
							{
								Console.WriteLine("Withdrew " + parsedWithdrawalInt + " from the account!\n");
							}
							else
							{
								Console.WriteLine("Withdrawal from the account is not possible at the moment");
							}		
						}
						else
							Console.WriteLine("The account does not exist!");

						break;
					case 6:

						Console.Clear();

						int parsedTransferInt = 0;
						accountList = bankHandler.GetAllCustomerAccounts();

						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}
						
						Console.WriteLine("\nEnter the name of the account you want to transfer from:\n");
						string accountNameWdr = Console.ReadLine();
						Account tmpAccountOne = bankHandler.GetSpecificCustomerAccount(accountNameWdr);

						Console.WriteLine("\nEnter the name of the account you want to transfer to:\n");
						string accountNameDep = Console.ReadLine();
						Account tmpAccountTwo = bankHandler.GetSpecificCustomerAccount(accountNameDep);

						if(tmpAccountOne != null && tmpAccountTwo != null && !tmpAccountOne.GetLockedStatus())
						{
							Console.WriteLine("\nEnter the amount to transfer between the accounts:\n");

							while (!int.TryParse(Console.ReadLine(), out parsedTransferInt))
							{
								Console.WriteLine("Try again:");
							}

							tmpAccountOne.Withdraw(parsedTransferInt);
							tmpAccountTwo.Deposit(parsedTransferInt);

							Console.WriteLine("\nTransfered " + parsedTransferInt + " from " + accountNameWdr + " to " + accountNameDep + "!");
						}
						
						else
							Console.WriteLine("One or both of the accounts does not exist, or the withdrawal account is locked.");
						break;
					case 7:
						Console.Clear();
				
						accountList = bankHandler.GetAllCustomerAccounts();

						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}
						
						Console.WriteLine("\nEnter the name of the account you want to lock/unlock:\n");

						accountName = Console.ReadLine();
						tmpAccount = bankHandler.GetSpecificCustomerAccount(accountName);

						if(tmpAccount != null)
						{
							if(tmpAccount.GetLockedStatus())
							{
								tmpAccount.SetLockedStatus(false);
								Console.WriteLine("The account is now unlocked!");
							} 
							else 
							{
								tmpAccount.SetLockedStatus(true);
								Console.WriteLine("The account is now locked!");
							}			
						}
						else
							Console.WriteLine("The account does not exist!");
						
						break;
					case 0:
						return;

					default:
						Console.WriteLine("\nPlease enter some valid input (1, 2, 3, 4, 5, 6, 7 or 0)\n");

						break;
				}
			}

			Console.ReadKey();
		}
	}
}
