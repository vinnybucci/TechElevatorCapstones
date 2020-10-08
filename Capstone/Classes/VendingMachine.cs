using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        //properties: balance, stock, 
        //methods: dispense item, list of items.  
        public int Balance { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        

        public VendingMachine(int balance)
        {
            Balance = balance;
        }
        //returns your final balance? 
        public int FinalBalance()
        {
            return Balance;
        }

        //gives you a list of items to select from
      
        //gives your item?
       // public string DispenseItem()
        //{
            //return Item;
        }
    }

