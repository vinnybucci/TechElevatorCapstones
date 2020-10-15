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
        public VendingMachine Vm { get; set; } = new VendingMachine();
        public override void Menu()
        {

            // do
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1. Feed Money");

            Console.WriteLine("2. Select Product");
            Console.WriteLine("3. Finish Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current money provided {Vm.Balance:C2}");
            string selection = Console.ReadLine();
            try
            {
                if (selection == "1")
                {
                    FeedMoney("");
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
        public string FeedMoney(string currentMoneyProvided)
        {
            Vm.MethodName = "FEED MONEY:";
            bool continueFeedMoney = false;
            try
            {
                do
                {
                    Console.WriteLine("Insert money (Accepts $1, $2, $5, or $10) or press F to return");
                   string input = Console.ReadLine();
                    currentMoneyProvided = (input);

                    if (currentMoneyProvided.ToLower() == "f")
                    {
                        continueFeedMoney = true;
                    }
                    else if (currentMoneyProvided == "1" || currentMoneyProvided == "2" || currentMoneyProvided == "5" || currentMoneyProvided == "10")
                    {
                        Vm.Balance += decimal.Parse(currentMoneyProvided);
                        Vm.AmountOfChange = decimal.Parse(currentMoneyProvided);
                        continueFeedMoney = false;
                        Logger.WriteRecord(Vm);
                       
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                while (!continueFeedMoney);

            }
            catch (Exception e) 
            {
                Console.WriteLine("Please enter $1, $2, $5, or $10.");
                continueFeedMoney = true;
            }
            Menu();
            return currentMoneyProvided;
        }
        public bool SelectItem()
        {

            Vm.Display();
            Console.WriteLine("Please enter your item in the format of A1|B1|C1|D1");
            string selection = Console.ReadLine();

            bool itemSelected = false;
            try
            {
                do
                {
                    switch (selection.ToUpper())
                    {
                        case "A1":
                            if (Vm.Products[0].Stock > 0)
                            {

                                Vm.Balance -= decimal.Parse(Vm.Products[0].Price);
                                Console.WriteLine($"{Vm.Products[0].ProductName} {Vm.Products[0].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Vm.Products[0].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[0].ProductName} {Vm.Products[0].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[0].Price);
                            }
                            else if (Vm.Products[0].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "A2":
                            if (Vm.Products[1].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[1].Price);
                                Console.WriteLine($"{Vm.Products[1].ProductName} {Vm.Products[1].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Vm.Products[1].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[1].ProductName} {Vm.Products[1].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[1].Price);
                            }
                            else if (Vm.Products[1].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "A3":
                            if (Vm.Products[2].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[2].Price);
                                Console.WriteLine($"{Vm.Products[2].ProductName} {Vm.Products[2].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Vm.Products[2].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[2].ProductName} {Vm.Products[2].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[2].Price);
                            }
                            else if (Vm.Products[2].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "A4":
                            if (Vm.Products[3].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[3].Price);
                                Console.WriteLine($"{Vm.Products[3].ProductName} {Vm.Products[3].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Crunch Crunch, Yum!");
                                itemSelected = true;
                                Vm.Products[3].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[3].ProductName} {Vm.Products[3].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[3].Price);
                            }
                            else if (Vm.Products[3].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B1":
                            if (Vm.Products[4].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[4].Price);
                                Console.WriteLine($"{Vm.Products[4].ProductName} {Vm.Products[4].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Vm.Products[4].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[4].ProductName} {Vm.Products[4].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[4].Price);
                            }
                            else if (Vm.Products[4].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B2":
                            if (Vm.Products[5].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[5].Price);
                                Console.WriteLine($"{Vm.Products[5].ProductName} {Vm.Products[5].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Vm.Products[5].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[5].ProductName} {Vm.Products[5].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[5].Price);
                            }
                            else if (Vm.Products[5].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B3":
                            if (Vm.Products[6].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[6].Price);
                                Console.WriteLine($"{Vm.Products[6].ProductName} {Vm.Products[6].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Vm.Products[6].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[6].ProductName} {Vm.Products[6].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[6].Price);
                            }
                            else if (Vm.Products[6].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "B4":
                            if (Vm.Products[7].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[7].Price);
                                Console.WriteLine($"{Vm.Products[7].ProductName} {Vm.Products[7].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Munch Munch, Yum!");
                                itemSelected = true;
                                Vm.Products[7].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[7].ProductName} {Vm.Products[7].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[7].Price);
                            }
                            else if (Vm.Products[7].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C1":
                            if (Vm.Products[8].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[8].Price);
                                Console.WriteLine($"{Vm.Products[8].ProductName} {Vm.Products[8].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Vm.Products[8].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[8].ProductName} {Vm.Products[8].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[8].Price);
                            }
                            else if (Vm.Products[8].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C2":
                            if (Vm.Products[9].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[9].Price);
                                Console.WriteLine($"{Vm.Products[9].ProductName} {Vm.Products[9].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Vm.Products[9].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[9].ProductName} {Vm.Products[9].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[9].Price);
                            }
                            else if (Vm.Products[9].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C3":
                            if (Vm.Products[10].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[10].Price);
                                Console.WriteLine($"{Vm.Products[10].ProductName} {Vm.Products[10].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Vm.Products[10].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[10].ProductName} {Vm.Products[10].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[10].Price);
                            }
                            else if (Vm.Products[10].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "C4":
                            if (Vm.Products[11].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[11].Price);
                                Console.WriteLine($"{Vm.Products[11].ProductName} {Vm.Products[11].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Glug Glug, Yum!");
                                itemSelected = true;
                                Vm.Products[11].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[11].ProductName} {Vm.Products[11].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[11].Price);
                            }
                            else if (Vm.Products[11].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D1":
                            if (Vm.Products[12].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[12].Price);
                                Console.WriteLine($"{Vm.Products[12].ProductName} {Vm.Products[12].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Vm.Products[12].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[12].ProductName} {Vm.Products[12].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[12].Price);
                            }
                            else if (Vm.Products[12].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D2":
                            if (Vm.Products[13].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[13].Price);
                                Console.WriteLine($"{Vm.Products[13].ProductName} {Vm.Products[13].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Vm.Products[13].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[13].ProductName} {Vm.Products[13].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[13].Price);
                            }
                            else if (Vm.Products[13].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D3":
                            if (Vm.Products[14].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[14].Price);
                                Console.WriteLine($"{Vm.Products[14].ProductName} {Vm.Products[14].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Vm.Products[14].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[14].ProductName} {Vm.Products[14].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[14].Price);
                            }
                            else if (Vm.Products[14].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        case "D4":
                            if (Vm.Products[15].Stock > 0)
                            {
                                Vm.Balance -= decimal.Parse(Vm.Products[15].Price);
                                Console.WriteLine($"{Vm.Products[15].ProductName} {Vm.Products[15].Price:C2} {Vm.Balance:C2}");
                                Console.WriteLine("Chew Chew, Yum!");
                                itemSelected = true;
                                Vm.Products[15].Stock -= 1;
                                Vm.MethodName = ($"{Vm.Products[15].ProductName} {Vm.Products[15].SlotLocation}");
                                Vm.AmountOfChange = decimal.Parse(Vm.Products[15].Price);
                            }
                            else if (Vm.Products[15].Stock == 0)
                            {
                                throw new OutOfStockException("Item is Sold Out", 0);
                            }
                            break;
                        default:
                            throw new Exception("Enter a valid input");

                    }
                } while (!itemSelected);
                Logger.WriteRecord(Vm);
                Console.ReadKey();
                Menu();
            }
            catch (OutOfStockException oe)
            {
                Console.WriteLine(oe.Message);
                itemSelected = false;
                Console.ReadLine();
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine("The code you entered is invalid.");
                itemSelected = false;
                Console.ReadLine();
                Menu();
            }
            return itemSelected;

        }
        public bool FinishTransaction()
        {
            bool finishingTransaction = false;
            Vm.AmountOfChange = Vm.Balance;
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

                while (Vm.Balance > 0)
                {
                    if (Vm.Balance * 100 % 25 == 0)
                    {
                        Vm.Balance -= quarter;
                        change[quarter]++;
                    }
                    else if (Vm.Balance * 100 % 10 == 0)
                    {
                        Vm.Balance -= dime;
                        change[dime]++;
                    }
                    else if (Vm.Balance * 100 % 5 == 0)
                    {
                        Vm.Balance -= nickel;
                        change[nickel]++;
                    }
                }
                Console.WriteLine($"Your change is {change[quarter]} Quarters, {change[dime]} Dimes, and {change[nickel]} Nickels.");
                Vm.MethodName = "GIVE CHANGE:";
                Logger.WriteRecord(Vm);
                finishingTransaction = true;
                base.Menu();
            }
            catch (Exception e)
            {
                finishingTransaction = false;
            }
            return finishingTransaction;
        }
        public string LogData()
        {
            return ($"{Vm.MethodName} {Vm.Balance}  ");
        }
    }
}
//{ Balance - decimal.Parse(Selection.Price)}