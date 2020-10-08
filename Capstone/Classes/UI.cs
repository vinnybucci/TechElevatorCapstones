using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {

        public void Menu()
        {
            bool shouldContinue = false;
            do
            {
                Console.WriteLine("Welcome to Vendo-Matic 3000!");
                Console.WriteLine();
                Console.WriteLine("1. Display Products");
                Console.WriteLine("2. Purchase");
                Console.WriteLine("3. Exit");
                string selection = Console.ReadLine();
                try
                {
                    Purchase purchase = new Purchase(0);
                    if (selection == "1")
                    {
                        Display();
                        shouldContinue = true;
                    }
                    else if (selection == "2")
                    {
                        purchase.PurchaseMenu();
                        shouldContinue = true;
                    }
                    else if (selection == "3")
                    {
                        shouldContinue = false;
                    }
                    else if (selection == "4")
                    {
                        //SalesReport();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter a valid number please");
                }
            } while (shouldContinue);
        }
        public void Display()
        {
            string filePath = @"C:\Users\Student\workspace\Capstones\csharp-capstone-module-1-team-3\vendingmachine.csv";
            List<Product> Products = new List<Product>();

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
        //console.writelines: of display vending machine items, purchase, exit, 
        //feed money, selct product, finish transaction, sales report. 





    }
}
