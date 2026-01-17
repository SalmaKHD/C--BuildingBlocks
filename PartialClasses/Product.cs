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
        // private by default
        partial void getInfo()
        {
            System.Console.WriteLine("product info: \nProduct type is: " + ProductTypes.Female);
        }

        public void getProductInfo()
        {
            this.getInfo();
        }
    }

    static class ProductConfig
    {
        // all memebrs must be static
        const string TAG = "Product Log";
        static string list = "white";
    }

    public enum ProductTypes: short // may be any numerical value
    {
        Male= 100, // changing the default value
        Female = 101
    }
}
