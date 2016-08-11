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
				+ "\n7. Lock an account."
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
						int parsedDepositInt;

						Console.Clear();

						accountList = bankHandler.GetAllCustomerAccounts();

						foreach (Account acc in accountList)
						{
							Console.WriteLine(acc);
						}
						
						Console.WriteLine("Enter the name of the account you want to make a deposit to:\n");

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
					//case 5:
					//	Console.Clear();
					//	Console.WriteLine("What type of vehicle do you want to search for?");
					//	string vehicleType = Console.ReadLine();

					//	tmpList = garage.getAllVehiclesByType(vehicleType);
					//	Console.WriteLine(tmpList.Count + " vehicles matches the criteria:\n");

					//	foreach (Vehicle v in tmpList)
					//	{
					//		Console.WriteLine(v);
					//	}

					//	break;
					//case 6:
					//	Console.Clear();
					//	Console.WriteLine("Type the registration number of the vehicle you want to list:");
					//	string registrationNumber = Console.ReadLine();

					//	Vehicle vehicle = garage.getVehicleByRegistrationNumber(registrationNumber);

					//	Console.WriteLine(vehicle);

					//	break;
					//case 7:
					//	Console.Clear();
					//	garage.sortAndGetAllVehiclesInGarage();

					//	foreach (Vehicle v in garage)
					//	{
					//		Console.WriteLine(v);
					//	}

					//	Console.WriteLine("\nType the registration number of the vehicle you want to remove:");
					//	registrationNumber = Console.ReadLine();

					//	garage.removeVehicleByRegistrationNumber(registrationNumber);

					//	break;
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
