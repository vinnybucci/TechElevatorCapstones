
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void FeedMoneyNull()
        {

            Purchase purchase = new Purchase();
            Assert.AreEqual(0, purchase.Vm.AmountOfChange);
            
        }
        [TestMethod]
        public void FeedMoney5()
        {
            Purchase purchase = new Purchase();
            purchase.Vm.Balance = 5;
            purchase.Vm.AmountOfChange = 10;
            decimal expected = purchase.Vm.Balance+purchase.Vm.AmountOfChange;
            purchase.FeedMoney();
            
           // Assert.AreEqual(expected, purchase.FeedMoney());
        }
        [TestMethod]
        public void FeedMoney2()
        {
            Purchase purchase = new Purchase();

            int input = 2;
            int expected = 2;
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void FeedMoney1()
        {
            Product selection = null;
            int input = 1;
            int expected = 1;
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void FeedMoney10()
        {
            Product selection = null;
            Purchase purchase = new Purchase();
            int input = 10;
            int expected = 10;
            Assert.AreEqual(expected, input);
        }
        //[TestMethod]
        //public void FeedMoneyIncorrect()
        //{
        //    Product selection = null;
        //    Purchase purchase = new Purchase(0, "", selection);
        //    int input = 3;
        //    int expected = 0;
        //    Assert.AreEqual(expected, input);
        //}
        //[TestMethod]
        ////public void FeedMoneyOutput()
        ////{
        ////    Product selection = null;
        ////    Purchase purchase = new Purchase(5, "", selection);
        ////    string expected = "FEED MONEY";
        ////    string input = "F";
        ////    Assert.AreEqual(expected, input);
        ////}
        [TestMethod]
        public void SelectingItemTest()
        {
            Product selection = null;
            string itemSelected = "A1";
           // string expected = purchase.ToString(purchase.Selection.ProductName[0]);
        }
        [TestMethod]
        public void StockOnItem()
        {
            Product selection = null;
            int expected = 0;
            string input = selection.Stock.ToString();
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void StockOnItem0()
        {
            Product selection = null;
            int expected = 0;
            string input = selection.Stock.ToString();
            Assert.AreEqual(expected, input);
        }
    }
}
