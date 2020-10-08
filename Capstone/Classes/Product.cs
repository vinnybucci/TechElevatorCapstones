using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        //properties: slot location, product name, price, type
        //methods:

        public string SlotLocation { get; set; }
        public string ProductName { get; set; }
        public string Price { get; private set; }
        public string Type { get; set; }
        public int Stock { get; set; } = 5;

        public Product(string slotLocation, string productName, string price, string type)
        {
            SlotLocation = slotLocation;
            ProductName = productName;
            Price = price;
            Type = type;
        }
        public Product()
        {

        }


    }
}
