using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstApplication
{
    public static class Util
    {
        public static void printValue<T>(T value)
        {
            System.Console.WriteLine(value);
        }
    }
}
