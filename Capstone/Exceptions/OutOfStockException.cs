using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Exceptions
{
    public class OutOfStockException : Exception
    {
        private int Stock = 0;
        public int GetStock { get
            {
                return Stock;
            }
        }
        public OutOfStockException(string message, int stock) : base(message)
        {
            Stock = stock;

        }
    }
}
