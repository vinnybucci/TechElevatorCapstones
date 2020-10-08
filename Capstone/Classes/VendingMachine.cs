using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //properties: balance, stock, 
        //methods: dispense item, list of items.  
        public int Balance { get; set; }
        public int Stock { get; set; }
        public string Item { get; set; }
        

        public VendingMachine(int balance, int stock)
        {
            Balance = balance;
            Stock = stock; 
        }
        //returns your final balance? 
        public int FinalBalance()
        {
            return Balance;
        }

        //gives you a list of items to select from
        public int ListOfItems()
        {
            return Stock;
        }


        //gives your item?
        public string DispenseItem()
        {
            return Item;
        }
        
        
        





    }
}
