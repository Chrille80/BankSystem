using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem;
using System.Collections.Generic;

namespace BankSystemTests
{
	[TestClass]
	public class CustomerTests
	{
		[TestMethod]
		public void TestInstantiateCustomer_EmptyNameString_EmptyNameString()
		{
			#region Arrange
			Customer customer = new Customer("");
			#endregion

			#region Act
			string resultName = customer.Name;
			string expectedName = "";
			#endregion

			#region Assert
			Assert.AreEqual(expectedName, resultName);
			#endregion
		}
		[TestMethod]
		public void TestInstantiateCustomer_SvenSvensson_SvenSvensson()
		{
			#region Arrange
			Customer customer = new Customer("Sven Svensson");
			#endregion

			#region Act
			string resultName = customer.Name;
			string expectedName = "Sven Svensson";
			#endregion

			#region Assert
			Assert.AreEqual(expectedName, resultName);
			#endregion
		}

		[TestMethod]
		public void TestAddAccount_AddOneAccount_OneAccountInListAndTrue()
		{
			#region Arrange
			Customer customer = new Customer("Sven Svensson");
			Account account = new Account("Savings", 250, false);
			List<Account> accountList = new List<Account>();
			#endregion

			#region Act
			accountList = customer.GetAllAccounts();
			bool result = customer.AddAccount(account);
			bool expected = true;
			int resultTwo = accountList.Count;
			int expectedTwo = 1;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			Assert.AreEqual(expectedTwo, resultTwo);
			#endregion
		}
		[TestMethod]
		public void TestAddAccount_AddTwoAccountsWithUniqueNames_TwoAccountsInListAndTrue()
		{
			#region Arrange
			Customer customer = new Customer("Sven Svensson");
			Account account = new Account("Savings", 6500, false);
			Account accountTwo = new Account("Poker winnings", 3100, false);
			#endregion

			#region Act
			bool result = customer.AddAccount(account);
			bool expected = true;
			bool resultTwo = customer.AddAccount(accountTwo);
			bool expectedTwo = true;
			int resultThree = customer.GetAllAccounts().Count;
			int expectedThree = 2;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			Assert.AreEqual(expectedTwo, resultTwo);
			Assert.AreEqual(expectedThree, resultThree);
			#endregion
		}
		[TestMethod]
		public void TestAddAccount_AddTwoAccountsWithSameNames_OneAccountInListAndFalse()
		{
			#region Arrange
			Customer customer = new Customer("Sven Svensson");
			Account account = new Account("Poker winnings", 6500, false);
			Account accountTwo = new Account("Poker winnings", 3100, false);
			#endregion

			#region Act
			bool result = customer.AddAccount(account);
			bool expected = true;
			bool resultTwo = customer.AddAccount(accountTwo);
			bool expectedTwo = false;
			int resultThree = customer.GetAllAccounts().Count;
			int expectedThree = 1;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			Assert.AreEqual(expectedTwo, resultTwo);
			Assert.AreEqual(expectedThree, resultThree);
			#endregion
		}

		[TestMethod]
		public void TestGetSpecificAccount_GetAccountWhenNoAccount_Null()
		{
			#region Arrange
			Customer customer = new Customer("Per Persson");
			#endregion

			#region Act
			Account result = customer.GetSpecificAccount("Savings account");
			Account expected = null;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestGetSpecificAccount_GetSpecificAccountWhenNameMatches_SpecificAccountWithMatchingName()
		{
			#region Arrange
			Customer customer = new Customer("Per Persson");
			Account account = new Account("Poker winnings", 6500, false);
			customer.AddAccount(account);
			#endregion

			#region Act
			Account matchingAccount = customer.GetSpecificAccount("Poker winnings");
			string result = matchingAccount.GetAccountName();
			string expected = "Poker winnings";
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

		[TestMethod]
		public void TestGetAllAccounts_GetAccountsWhenNoAccounts_EmptyList()
		{
			#region Arrange
			Customer customer = new Customer("Sven Svensson");
			#endregion

			#region Act
			int result = customer.GetAllAccounts().Count;
			int expected = 0;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestGetAllAccounts_GetAccountsWhenTwoAccounts_ListWithTwoAccounts()
		{
			#region Arrange
			Customer customer = new Customer("Sven Svensson");
			Account accountOne = new Account("Poker winnings", 6500, false);
			Account accountTwo = new Account("Stryktipset winnings", 14500, false);
			customer.AddAccount(accountOne);
			customer.AddAccount(accountTwo);
			#endregion

			#region Act
			int result = customer.GetAllAccounts().Count;
			int expected = 2;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}
	}
}
