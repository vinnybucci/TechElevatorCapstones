using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                char selection = Console.ReadKey().KeyChar;
                try
                {
                    VendingMachine vm = new VendingMachine(0);
                    if (selection == '1')
                    {
                        vm.Display();
                        shouldContinue = true;
                    }
                    else if (selection == '2')
                    {
                        //Purchase();
                        shouldContinue = true;
                    }
                    else if (selection == '3')
                    {
                        shouldContinue = false;
                    }
                    else if (selection == '4')
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
