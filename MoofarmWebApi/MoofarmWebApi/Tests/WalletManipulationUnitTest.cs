 using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExample.BusinessLayer;

namespace WebApiExample.Tests
{
    [TestClass]
    public class WalletManipulationUnitTest
    {
        [TestMethod]
        public void calculateBalanceTest()
        {
            
            int? entryAmount = 500;
            WalletManipulation walletManipulation = new WalletManipulation();
            WalletsAccount userAccount = new WalletsAccount();
            userAccount.BonusBucket = 50;
            userAccount.DepositBucket = 100;
            userAccount.WinningsBucket =500;
            var updatedWallet = walletManipulation.calculateBalance(userAccount, ref entryAmount);
            Console.WriteLine(entryAmount);
            Assert.AreEqual(entryAmount,0);
            Assert.AreEqual(updatedWallet.BonusBucket, 0);
            Assert.AreEqual(updatedWallet.DepositBucket, 0);
            Assert.AreEqual(updatedWallet.WinningsBucket, 150);
        }
        [TestMethod]
        public void calculateBalanceGreaterThanTest()
        {
            int? entryAmount = 5000;
            WalletManipulation walletManipulation = new WalletManipulation();
            WalletsAccount userAccount = new WalletsAccount();
            userAccount.BonusBucket = 50;
            userAccount.DepositBucket = 100;
            userAccount.WinningsBucket = 500;
            var updatedWallet = walletManipulation.calculateBalance(userAccount, ref entryAmount);
            Console.WriteLine(entryAmount);
            Assert.AreEqual(entryAmount, 4350);
            Assert.AreEqual(updatedWallet.BonusBucket, 0);
            Assert.AreEqual(updatedWallet.DepositBucket, 0);
            Assert.AreEqual(updatedWallet.WinningsBucket,0);
        }
        [TestMethod]
        public void calculateBalanceSameAmountTest()
        {
            int? entryAmount = 500;
            WalletManipulation walletManipulation = new WalletManipulation();
            WalletsAccount userAccount = new WalletsAccount();
            userAccount.BonusBucket = 50;
            userAccount.DepositBucket = 100;
            userAccount.WinningsBucket = 350;
            var updatedWallet = walletManipulation.calculateBalance(userAccount, ref entryAmount);
            Console.WriteLine(entryAmount);
            Assert.AreEqual(entryAmount, 0);
            Assert.AreEqual(updatedWallet.BonusBucket, 0);
            Assert.AreEqual(updatedWallet.DepositBucket, 0);
            Assert.AreEqual(updatedWallet.WinningsBucket, 0);
        }
    }
}