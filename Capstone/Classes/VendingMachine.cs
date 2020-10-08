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
        public void Display()
        {
        string filePath = @"C:\Users\Student\workspace\Capstones\csharp-capstone-module-1-team-3\vendingmachine.csv";
            
            try
            {
                using (StreamReader sr = new StreamReader(filePath)) 
                {
                    while (!sr.EndOfStream)
                    {                      
                        string line = sr.ReadLine();
                        string[] productDetails = line.Split('|');
                        Product product = new Product(productDetails[0], productDetails[1], productDetails[2], productDetails[3]);
                        Products.Add(product);
                    }
                }
                Console.Clear();
                foreach (Product product in Products)
                {
                    Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: {product.Stock}");
                }
            }
            catch (Exception e)
            {

            } 
        }
        //gives your item?
       // public string DispenseItem()
        //{
            //return Item;
        }
    }
//}
