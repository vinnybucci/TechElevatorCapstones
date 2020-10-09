using Capstone.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Capstone.Classes
{
    public class Purchase : UI

    {
        public decimal Balance { get; set; }
        public string MethodName { get; set; } = "";
        List<Product> Products { get; set; } = new List<Product>();
        public Product Selection { get; set; } = new Product();

        public Purchase(decimal balance, string methodName, Product selection)
        {
            Balance = balance;
            MethodName = methodName;
            Selection = selection;
        }

        Logger logger = new Logger();
        public void Display()
        {
            string filePath = @"C:\Users\Student\workspace\Capstones\csharp-capstone-module-1-team-3\vendingmachine.csv";
            

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.Clear();
                    if (Products.Count == 16)
                    {

                        foreach (Product product in Products)
                        {
                            if (product.Stock == 0)
                            {
                                Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: SOLD OUT");
                            } else
                            Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: {product.Stock}");

                        }
                    }
                    else if (Products.Count == 0)
                    {
                        while (!sr.EndOfStream)
                        {

                            string line = sr.ReadLine();
                            string[] productDetails = line.Split('|');
                            Product product = new Product(productDetails[0], productDetails[1], productDetails[2], productDetails[3]);
                            Products.Add(product);
                        }

                        
                        foreach (Product product in Products)
                        {
                            Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price} quantity remaining: {product.Stock}");
                        }
                    }
                }
                    
            }
            catch (Exception e)
            {

            }
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

                    FinishTransaction();
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
            Purchase purchase = new Purchase(0, MethodName, Selection);

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
                    decimal currentMoneyProvided = decimal.Parse(input);
                    Balance += currentMoneyProvided;
                    continueFeedMoney = true;
                }
            }
            while (continueFeedMoney);
            MethodName = "FEED MONEY";
            Logger.WriteRecord(purchase);
            PurchaseMenu();
            
        }
        public void SelectItem()
        {
            Purchase purchase = new Purchase(0, MethodName, Selection);
            Display();
            Console.WriteLine("Please enter your item in the format of A1|B1|C1|D1");
            string selection = Console.ReadLine();

            bool itemSelected = false;
            try
            {
                do
                {
                    switch (selection)
                    {
                        case "A1":
                            if (Products[0].Stock > 0)
                            {
                                Selection = Products[0];

                                Balance -= decimal.Parse(Products[0].Price);
                                Console.WriteLine($"{Products[0].ProductName} {Products[0].Price:C2} {Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Products[0].Stock -= 1;
                                MethodName = ($"{Products[0].ProductName} {Products[0].SlotLocation}");
                            }else if(Products[0].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "A2":
                            if (Products[1].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[1].Price);
                                Console.WriteLine($"{Products[1].ProductName} {Products[1].Price:C2} {Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Products[1].Stock -= 1;
                                MethodName = ($"{Products[1].ProductName} {Products[1].SlotLocation}");

                            }
                            else if (Products[1].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "A3":
                            if (Products[2].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[2].Price);
                                Console.WriteLine($"{Products[2].ProductName} {Products[2].Price:C2} {Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Products[2].Stock -= 1;
                                MethodName = ($"{Products[2].ProductName} {Products[2].SlotLocation}");

                            }
                            else if (Products[2].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "A4":
                            if (Products[3].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[3].Price);
                                Console.WriteLine($"{Products[3].ProductName} {Products[3].Price:C2} {Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Products[3].Stock -= 1;
                                MethodName = ($"{Products[3].ProductName} {Products[3].SlotLocation}");

                            }
                            else if (Products[3].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B1":
                            if (Products[4].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[4].Price);
                                Console.WriteLine($"{Products[4].ProductName} {Products[4].Price:C2} {Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Products[4].Stock -= 1;
                                MethodName = ($"{Products[4].ProductName} {Products[4].SlotLocation}");

                            }
                            else if (Products[4].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B2":
                            if (Products[5].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[5].Price);
                                Console.WriteLine($"{Products[5].ProductName} {Products[5].Price:C2} {Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Products[5].Stock -= 1;
                                MethodName = ($"{Products[5].ProductName} {Products[5].SlotLocation}");

                            }
                            else if (Products[5].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B3":
                            if (Products[6].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[6].Price);
                                Console.WriteLine($"{Products[6].ProductName} {Products[6].Price:C2} {Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Products[6].Stock -= 1;
                                MethodName = ($"{Products[6].ProductName} {Products[6].SlotLocation}");

                            }
                            else if (Products[6].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B4":
                            if (Products[7].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[7].Price);
                                Console.WriteLine($"{Products[7].ProductName} {Products[7].Price:C2} {Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Products[7].Stock -= 1;
                                MethodName = ($"{Products[7].ProductName} {Products[7].SlotLocation}");

                            }
                            else if (Products[7].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C1":
                            if (Products[8].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[8].Price);
                                Console.WriteLine($"{Products[8].ProductName} {Products[8].Price:C2} {Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Products[8].Stock -= 1;
                                MethodName = ($"{Products[8].ProductName} {Products[8].SlotLocation}");

                            }
                            else if (Products[8].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C2":
                            if (Products[9].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[9].Price);
                                Console.WriteLine($"{Products[9].ProductName} {Products[9].Price:C2} {Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Products[9].Stock -= 1;
                                MethodName = ($"{Products[9].ProductName} {Products[9].SlotLocation}");

                            }
                            else if (Products[9].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C3":
                            if (Products[10].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[10].Price);
                                Console.WriteLine($"{Products[10].ProductName} {Products[10].Price:C2} {Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Products[10].Stock -= 1;
                                MethodName = ($"{Products[10].ProductName} {Products[10].SlotLocation}");

                            }
                            else if (Products[10].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C4":
                            if (Products[11].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[11].Price);
                                Console.WriteLine($"{Products[11].ProductName} {Products[11].Price:C2} {Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Products[11].Stock -= 1;
                                MethodName = ($"{Products[11].ProductName} {Products[11].SlotLocation}");

                            }
                            else if (Products[11].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D1":
                            if (Products[12].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[12].Price);
                                Console.WriteLine($"{Products[12].ProductName} {Products[12].Price:C2} {Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Products[12].Stock -= 1;
                                MethodName = ($"{Products[12].ProductName} {Products[12].SlotLocation}");

                            }
                            else if (Products[12].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D2":
                            if (Products[13].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[13].Price);
                                Console.WriteLine($"{Products[13].ProductName} {Products[13].Price:C2} {Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Products[13].Stock -= 1;
                                MethodName = ($"{Products[13].ProductName} {Products[13].SlotLocation}");

                            }
                            else if (Products[13].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D3":
                            if (Products[14].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[14].Price);
                                Console.WriteLine($"{Products[14].ProductName} {Products[14].Price:C2} {Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Products[14].Stock -= 1;
                                MethodName = ($"{Products[14].ProductName} {Products[14].SlotLocation}");

                            }
                            else if (Products[14].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D4":
                            if (Products[15].Stock > 0)
                            {
                                Balance -= decimal.Parse(Products[15].Price);
                                Console.WriteLine($"{Products[15].ProductName} {Products[15].Price:C2} {Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Products[15].Stock -= 1;
                                MethodName = ($"{Products[15].ProductName} {Products[15].SlotLocation}");

                            }
                            else if (Products[15].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        default:
                            throw new Exception("Enter a valid input");

                    }
                } while (!itemSelected);
                Logger.WriteRecord(purchase);

                PurchaseMenu();
        }
            catch(OutOfStockException oe)
            {
                Console.WriteLine(oe.Message);
                PurchaseMenu();
    }
            catch(Exception e)
            {
                Console.WriteLine("The code you entered is invalid.");
                PurchaseMenu();
}
            

        }
        public void FinishTransaction()
        {
            Purchase purchase = new Purchase(0, MethodName, Selection);


            decimal quarter = 0.25M;
            decimal dime = 0.10M;
            decimal nickel = 0.05M;
            Dictionary<decimal, int> change = new Dictionary<decimal, int>()
            {
                {quarter, 0 },
                {dime, 0 },
                {nickel,0 },
            };
            try
            {

                while (Balance > 0)
                {
                    if (Balance * 100 % 25 == 0)
                    {
                        Balance -= quarter;
                        change[quarter]++;
                    }
                    else if (Balance * 100 % 10 == 0)
                    {
                        Balance -= dime;
                        change[dime]++;
                    }
                    else if (Balance * 100 % 5 == 0)
                    {
                        Balance -= nickel;
                        change[nickel]++;
                    }
                } 
                Console.WriteLine($"Your change is {change[quarter]} Quarters, {change[dime]} Dimes, and {change[nickel]} Nickels.");
                MethodName = "GIVE CHANGE";
                Logger.WriteRecord(purchase);
                Menu();
            }
            catch(Exception e)
            {

            }
            
        }
        public string LogData()
        {
            return ($"{MethodName} {Balance} {Balance-decimal.Parse(Selection.Price)} ");
        }
    }
}
