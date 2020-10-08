using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Capstone.Classes
{
    public class Purchase : UI

    {
        public double Balance { get; set; }
        List<Product> Products { get; set; } = new List<Product>();

        public Purchase(int balance)
        {
            Balance = balance;
        }



        public void PurchaseMenu()
        {

            // do

            Console.WriteLine();
            Console.WriteLine("1. Feed Money");

            Console.WriteLine("2. Select Product");
            Console.WriteLine("3. Finish Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current money provided {Balance:C2}");
            string selection = Console.ReadLine();
            try
            {
                if (selection == "1")
                {
                    FeedMoney();
                    ///  shouldContinue = true;
                }
                else if (selection == "2")
                {
                    SelectItem();
                    //shouldContinue = true;
                }
                else if (selection == "3")
                {

                    //FinalBalance()
                    //shouldContinue = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a valid number please");
            }
            //} while (shouldContinue);

        }
        public void FeedMoney()
        {
            bool continueFeedMoney = false;
            do
            {
                Console.WriteLine("Insert money (Accepts $1, $2, $5, or $10) or press F to return");
                string input = Console.ReadLine();
                if (input.ToLower() == "f")
                {
                    continueFeedMoney = false;
                }
                else
                {
                    double currentMoneyProvided = double.Parse(input);
                    Balance += currentMoneyProvided;
                    continueFeedMoney = true;
                }
            }
            while (continueFeedMoney);
            PurchaseMenu();
        }
        public void SelectItem()
        {

            Display();
            Console.WriteLine("Please enter your item in the format of A1|B1|C1|D1");
            string selection = Console.ReadLine();

            bool itemSelected = false;
            try
            {
                while (!itemSelected)
                {
                    switch (selection)
                    {
                        case "A1":
                            if (Products[0].Stock > 0)
                            {
                                Balance -= double.Parse(Products[0].Price);
                                Console.WriteLine($"{Products[0].ProductName} {Products[0].Price} {Balance}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                            }                          
                            break;
                        case "A2":
                            if (Products[1].Stock > 0)
                            {
                                Balance -= double.Parse(Products[1].Price);
                                Console.WriteLine($"{Products[1].ProductName} {Products[1].Price} {Balance}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                            }
                            break;
                        case "A3":
                            if (Products[2].Stock > 0)
                            {
                                Balance -= double.Parse(Products[2].Price);
                                Console.WriteLine($"{Products[2].ProductName} {Products[2].Price} {Balance}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                            }
                            break;
                        case "A4":
                            if (Products[3].Stock > 0)
                            {
                                Balance -= double.Parse(Products[3].Price);
                                Console.WriteLine($"{Products[3].ProductName} {Products[3].Price} {Balance}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                            }
                            break;
                        case "B1":
                            if (Products[4].Stock > 0)
                            {
                                Balance -= double.Parse(Products[4].Price);
                                Console.WriteLine($"{Products[4].ProductName} {Products[4].Price} {Balance}");
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            break;
                        case "B2":
                            if (Products[5].Stock > 0)
                            {
                                Balance -= double.Parse(Products[5].Price);
                                Console.WriteLine($"{Products[5].ProductName} {Products[5].Price} {Balance}");
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            break;
                        case "B3":
                            if (Products[6].Stock > 0)
                            {
                                Balance -= double.Parse(Products[6].Price);
                                Console.WriteLine($"{Products[6].ProductName} {Products[6].Price} {Balance}");
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            break;
                        case "B4":
                            if (Products[7].Stock > 0)
                            {
                                Balance -= double.Parse(Products[7].Price);
                                Console.WriteLine($"{Products[7].ProductName} {Products[7].Price} {Balance}");
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            break;
                        case "C1":
                            if (Products[8].Stock > 0)
                            {
                                Balance -= double.Parse(Products[8].Price);
                                Console.WriteLine($"{Products[8].ProductName} {Products[8].Price} {Balance}");
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            break;
                        case "C2":
                            if (Products[9].Stock > 0)
                            {
                                Balance -= double.Parse(Products[9].Price);
                                Console.WriteLine($"{Products[9].ProductName} {Products[9].Price} {Balance}");
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            break;
                        case "C3":
                            if (Products[10].Stock > 0)
                            {
                                Balance -= double.Parse(Products[10].Price);
                                Console.WriteLine($"{Products[10].ProductName} {Products[10].Price} {Balance}");
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            break;
                        case "C4":
                            if (Products[11].Stock > 0)
                            {
                                Balance -= double.Parse(Products[11].Price);
                                Console.WriteLine($"{Products[11].ProductName} {Products[11].Price} {Balance}");
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            break;
                        case "D1":
                            if (Products[12].Stock > 0)
                            {
                                Balance -= double.Parse(Products[12].Price);
                                Console.WriteLine($"{Products[12].ProductName} {Products[12].Price} {Balance}");
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                            break;
                        case "D2":
                            if (Products[13].Stock > 0)
                            {
                                Balance -= double.Parse(Products[13].Price);
                                Console.WriteLine($"{Products[13].ProductName} {Products[13].Price} {Balance}");
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                            break;
                        case "D3":
                            if (Products[14].Stock > 0)
                            {
                                Balance -= double.Parse(Products[14].Price);
                                Console.WriteLine($"{Products[14].ProductName} {Products[14].Price} {Balance}");
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                            break;
                        case "D4":
                            if (Products[15].Stock > 0)
                            {
                                Balance -= double.Parse(Products[15].Price);
                                Console.WriteLine($"{Products[15].ProductName} {Products[15].Price} {Balance}");
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                            break;
                            
                    }
                }
                PurchaseMenu();
            }
            catch (Exception e)
            {

            }


        }


    }
}
