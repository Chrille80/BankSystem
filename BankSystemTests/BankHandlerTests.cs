using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem;
using System.Collections.Generic;

namespace BankSystemTests
{
	[TestClass]
	public class BankHandlerTests
	{
		[TestMethod]
		public void TestAddAccountToCustomer_AddOneAccount_ListWithTwoAccounts()
		{
			#region Arrange
			//The BankHandler constructor adds a customer with one account, named "Vacation savings"
			BankHandler bankHandler = new BankHandler();
			Account account = new Account("Gasoline account", 2500, false);
			#endregion

			#region Act
			bankHandler.AddAccountToCustomer(account);
			int result = bankHandler.GetAllCustomerAccounts().Count; 
			int expected = 2;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

		[TestMethod]
		public void TestGetAllCustomerAccounts_GetAllAccountsWhenThreeAccounts_ListWithThreeAccounts()
		{
			#region Arrange
			//The BankHandler constructor adds a customer with one account, named "Vacation savings"
			BankHandler bankHandler = new BankHandler();
			Account account = new Account("Gasoline account", 2500.75, false);
			Account accountTwo = new Account("Travel account", 8500.12, false);
			#endregion

			#region Act
			bankHandler.AddAccountToCustomer(account);
			bankHandler.AddAccountToCustomer(accountTwo);
			int result = bankHandler.GetAllCustomerAccounts().Count;
			int expected = 3;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

		[TestMethod]
		public void TestGetSpecificCustomerAccount_GetSpecificAccountWhenNameMatches_SpecificAccountWithMatchingName()
		{
			#region Arrange
			BankHandler bankHandler = new BankHandler();
			#endregion

			#region Act
			Account account = bankHandler.GetSpecificCustomerAccount("Vacation savings");
			string result = account.GetAccountName();
			string expected = "Vacation savings";
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

	}
}
