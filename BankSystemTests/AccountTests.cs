using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem;
using System.Collections.Generic;

namespace BankSystemTests
{
	[TestClass]
	public class AccountTests
	{
		[TestMethod]
		public void TestInstantiateAccount_EmptyNameStringBalanceZeroIsLockedTrueZeroTransactions_EmptyNameStringBalanceZeroIsLockedTrueListWithZeroTransactions()
		{
			#region Arrange
			Account account = new Account("", 0, true);
			#endregion

			#region Act
			string resultName = account.GetAccountName();
			string expectedName = "";
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 0;
			bool resultIsLocked = account.GetLockedStatus();
			bool expectedIsLocked = true;
			int resultTransactions = account.GetAllTransactions().Count;
			int expectedTransactions = 0;
			#endregion

			#region Assert
			Assert.AreEqual(expectedName, resultName);
			Assert.AreEqual(expectedBalance, resultBalance);
			Assert.AreEqual(expectedIsLocked, resultIsLocked);
			Assert.AreEqual(expectedTransactions, resultTransactions);
			#endregion
		}
		[TestMethod]
		public void TestInstantiateAccount_NameSavingsBalanceFiveThousandIsLockedFalseOneTransaction_NameSavingsBalanceFiveThousandIsLockedFalseListWithOneTransaction()
		{
			#region Arrange
			Account account = new Account("Savings", 0, false);
			#endregion

			#region Act
			account.Deposit(5000);
			string resultName = account.GetAccountName();
			string expectedName = "Savings";
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 5000;
			bool resultIsLocked = account.GetLockedStatus();
			bool expectedIsLocked = false;
			int resultTransactions = account.GetAllTransactions().Count;
			int expectedTransactions = 1;
			#endregion

			#region Assert
			Assert.AreEqual(expectedName, resultName);
			Assert.AreEqual(expectedBalance, resultBalance);
			Assert.AreEqual(expectedIsLocked, resultIsLocked);
			Assert.AreEqual(expectedTransactions, resultTransactions);
			#endregion
		}
		[TestMethod]
		public void TestGetAccountName_TravelAccount_TravelAccount()
		{
			#region Arrange
			Account account = new Account("Travel Account", 11700, false);
			#endregion

			#region Act
			string resultName = account.GetAccountName();
			string expectedName = "Travel Account";
			#endregion

			#region Assert
			Assert.AreEqual(expectedName, resultName);
			#endregion
		}

		[TestMethod]
		public void TestGetAccountBalance_Zero_Zero()
		{
		#region Arrange
		Account account = new Account("Stryktipset winnings", 0, false);
		#endregion

		#region Act
		double resultBalance = account.GetAccountBalance();
		double expectedBalance = 0;
		#endregion

		#region Assert
		Assert.AreEqual(expectedBalance, resultBalance);
		#endregion
		}
		[TestMethod]
		public void TestGetAccountBalance_SevenThousandAndFortyCents_SevenThousandAndFortyCents()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 7000.40, false);
			#endregion

			#region Act
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 7000.40;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			#endregion
		}

		[TestMethod]
		public void TestGetAllTransactions_GetTransactionsWhenNoTransactions_EmptyList()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 0, false);
			List<double> transactionList = new List<double>();
			#endregion

			#region Act
			transactionList = account.GetAllTransactions();
			int result = transactionList.Count;
			int expected = 0;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestGetAllTransactions_GetTransactionsWhenThreeTransactions_ListWithThreeTransactions()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1800, false);
			List<double> transactionList = new List<double>();
			#endregion

			#region Act
			account.Deposit(500);
			account.Withdraw(600);
			account.Deposit(700);
			account.Withdraw(0);
			account.Deposit(0);
			transactionList = account.GetAllTransactions();
			int result = transactionList.Count;
			int expected = 3;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

		[TestMethod]
		public void TestSetLockedStatus_SetAccountToLocked_IsLockedTrue()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1800, false);
			#endregion

			#region Act
			account.SetLockedStatus(true);
			bool result = account.GetLockedStatus();
			bool expected = true;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestSetLockedStatus_SetAccountToUnlocked_IsLockedFalse()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1800, true);
			#endregion

			#region Act
			account.SetLockedStatus(false);
			bool result = account.GetLockedStatus();
			bool expected = false;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

		[TestMethod]
		public void TestGetLockedStatus_GetLockedStatusWhenLocked_IsLockedTrue()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1800, true);
			#endregion

			#region Act
			bool result = account.GetLockedStatus();
			bool expected = true;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestGetLockedStatus_GetLockedStatusWhenUnlocked_IsLockedFalse()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1800, false);
			#endregion

			#region Act
			bool result = account.GetLockedStatus();
			bool expected = false;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			#endregion
		}

		[TestMethod]
		public void TestDeposit_DepositZero_BalanceZero()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 0, true); 
			#endregion

			#region Act
			account.Deposit(0);
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 0;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			#endregion
		}
		[TestMethod]
		public void TestDeposit_DepositTwoHundredAndFiftyCents_BalanceTwoHundredAndFiftyCents()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 0, true);
			#endregion

			#region Act
			account.Deposit(200.50);
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 200.50;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			#endregion
		}
		[TestMethod]
		public void TestDeposit_MakeTwoDeposits_BalanceFourHundredAndSeventyCents()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 0, true);
			#endregion

			#region Act
			account.Deposit(200.50);
			account.Deposit(200.20);
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 400.70;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			#endregion
		}

		[TestMethod]
		public void TestWithdraw_WithdrawAmountWhenAccountIsLocked_False()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1000.7, true);
			#endregion

			#region Act
			bool result = account.Withdraw(194.50);
			bool expected = false;
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 1000.7;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestWithdraw_WithdrawAmountWhenAccountIsUnlocked_True()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 1000.7, false);
			#endregion

			#region Act
			bool result = account.Withdraw(194.50);
			bool expected = true;
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = 806.2;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestWithdraw_WithdrawAmountWhenNegativeAccountBalance_False()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", -900.7, false);
			#endregion

			#region Act
			bool result = account.Withdraw(194.50);
			bool expected = false;
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = -900.7;
			#endregion

			#region Assert
			Assert.AreEqual(expectedBalance, resultBalance);
			Assert.AreEqual(expected, result);
			#endregion
		}
		[TestMethod]
		public void TestWithdraw_WhitdrawFromPositiveToNegativeAmount_AccountGetsLocked()
		{
			#region Arrange
			Account account = new Account("Stryktipset winnings", 557.9, false);
			#endregion

			#region Act
			bool result = account.Withdraw(560.0);
			bool expected = true;
			double resultBalance = account.GetAccountBalance();
			double expectedBalance = -2.1;
			double errorMargin = 0.0000000000001;
			bool resultTwo = account.GetLockedStatus();
			bool expectedTwo = true;
			#endregion

			#region Assert
			Assert.AreEqual(expected, result);
			Assert.AreEqual(expectedBalance, resultBalance, errorMargin);
			Assert.AreEqual(expectedTwo, resultTwo);
			#endregion
		}
	}
}
