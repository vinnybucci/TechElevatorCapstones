using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public static class Logger
    {
        //add system.io, create log.txt datetime, method, action(balance/feed money/selection(product name, product location)), amount entered +- balance
        private const string FILENAME = "log.txt";
        public static void WriteRecord(VendingMachine vm)
        {
            
            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, FILENAME);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    if(vm.MethodName == "FEED MONEY:" || vm.MethodName == "GIVE CHANGE:")
                    {
                        sw.WriteLine($"{DateTime.Now} {vm.MethodName} {vm.AmountOfChange:C2} {vm.Balance:C2}");
                    }
                    else
                    {
                        sw.WriteLine($"{DateTime.Now} {vm.MethodName} {vm.Balance:C2} {vm.AmountOfChange:C2}");
                    }
                    
                }
                
            }catch (Exception e)
            {
                
            }
            
        }



    }
}
