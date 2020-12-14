﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {

        public virtual void Menu()
        {
            Product product = new Product();
            List<Product> products = new List<Product>();
            VendingMachine vendingMachine = new VendingMachine();
            bool shouldContinue = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Vendo-Matic 3000!");
                Console.WriteLine();
                Console.WriteLine("1. Display Products");
                Console.WriteLine("2. Purchase");
                Console.WriteLine("3. Exit");
                string selection = Console.ReadLine();
                try
                {
                    Purchase purchase = new Purchase();
                    if (selection == "1")
                    {
                        vendingMachine.Display();
                        shouldContinue = true;
                    }
                    else if (selection == "2")
                    {
                        purchase.Menu();
                        shouldContinue = true;
                    }
                    else if (selection == "3")
                    {
                        shouldContinue = false;
                        return;
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
        
        //console.writelines: of display vending machine items, purchase, exit, 
        //feed money, selct product, finish transaction, sales report. 





    }
}
