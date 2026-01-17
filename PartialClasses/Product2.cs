using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClasses
{
    public partial class Product
    {
        public double price;

        partial void getInfo(); // private by default
    }
}
