using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Logger
    {
        //add system.io, create log.txt datetime, method, action(balance/feed money/selection(product name, product location)), amount entered +- balance
        private const string FILENAME = "log.txt";
        public static bool WriteRecord(Purchase purchase)
        {
            bool success = false;
            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, FILENAME);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.Now} {purchase.LogData()}  ");
                    sw.Flush();
                    sw.Close();
                }
                success = true;
            }catch (Exception e)
            {
                success = false;
            }
            return success;
        }



    }
}
