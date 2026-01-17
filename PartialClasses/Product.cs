using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClasses
{
    public partial class Product
    {
        public string name;

        public Product()
        {
            name = "";
            // can access any members defined in another partial class
            price = 2.43;
        }

        // if no implementation is found, definition is removed from the class by compiler
        partial void getInfo()
        {
            System.Console.WriteLine("product info: ");
        }
    }

    static class ProductConfig
    {
        // all memebrs must be static
        const string TAG = "Product Log";
        static string list = "white";
    }
}
