using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstApplication
{
    class Types
    {
        static public void typeConversions()
        {
            int a = 4;
            float b = 4.13f;
            b = a; // implicit conversion

            b = (float)a; // explicit conersion
            a = (int)b;
            System.Console.WriteLine(a);
            System.Console.WriteLine(b);

            // parsing
            string value = "100";
            int.Parse(value);
            System.Console.WriteLine(value + 10);

            // TryParse: returns false if conversion fails, safer
            string value2 = "100jhjhjh";
            string value3 = "100";
            int.TryParse(value2, out int result2);
            int.TryParse(value3, out int result3);
            System.Console.WriteLine("result2 + 10 value is: " + (result2 + 10));
            System.Console.WriteLine("result3 + 10 value is: " + (result3 + 10));

            // conversion methods
            int value4 = System.Convert.ToInt32(value3);
            System.Console.WriteLine(result3 + 10);
            System.Console.WriteLine("value4 value is now: " + value4);

        }
    }
}
