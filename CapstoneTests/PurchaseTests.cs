
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
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
            Assert.AreEqual(0, purchase.Balance);
            
        }
        [TestMethod]
        public void FeedMoney5()
        {
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
            int input = 5;
            int expected = 5;
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void FeedMoney2()
        {
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
            int input = 2;
            int expected = 2;
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void FeedMoney1()
        {
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
            int input = 1;
            int expected = 1;
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void FeedMoney10()
        {
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
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
            Purchase purchase = new Purchase(0, "", selection);
            string itemSelected = "A1";
           // string expected = purchase.ToString(purchase.Selection.ProductName[0]);
        }
        [TestMethod]
        public void StockOnItem()
        {
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
            int expected = 0;
            string input = selection.Stock.ToString();
            Assert.AreEqual(expected, input);
        }
        [TestMethod]
        public void StockOnItem0()
        {
            Product selection = null;
            Purchase purchase = new Purchase(0, "", selection);
            int expected = 0;
            string input = selection.Stock.ToString();
            Assert.AreEqual(expected, input);
        }
    }
}
//public void DisplayMenu()
//    public void FinishTranscation()
//    public void SelectItem()
//    public void FeedMoney()
//    public void PurchaseMenu()