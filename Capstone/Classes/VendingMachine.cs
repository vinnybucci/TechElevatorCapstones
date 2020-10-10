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
        public decimal Balance { get; set; } 
        
        public string MethodName { get;set; }

        public List<Product> Products { get; set; } = new List<Product>();



        public decimal AmountOfChange { get; set; } = 0;


        public VendingMachine()
        {
            Balance = 0;
            try
            {
                string filePath = @"C:\Users\Student\workspace\Capstones\csharp-capstone-module-1-team-3\vendingmachine.csv";
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
            } catch (Exception e)
            {

            }


        }
        //returns your final balance? 
        public decimal FinalBalance()
        {
            return Balance;
        }

        public void Display()
        {
            


            try
            {
                
                    Console.Clear();
                    if (Products.Count == 16)
                    {

                        foreach (Product product in Products)
                        {
                            if (product.Stock == 0)
                            {
                                Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: SOLD OUT");
                            }
                            else
                                Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: {product.Stock}");

                        }
                    }
                    else if (Products.Count == 0)
                    {
                        


                        foreach (Product product in Products)
                        {
                            Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: {product.Stock}");
                        }
                    }
                

            }
            catch (Exception e)
            {

            }
        }

        //gives you a list of items to select from

        //gives your item?
        // public string DispenseItem()
        //{
        //return Item;
    }
    }

