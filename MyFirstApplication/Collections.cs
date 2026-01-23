using Authentication;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyFirstApplication
{
    /// <summary>
    /// a class for demosntratig the usage of Collection classes
    /// </summary>
    public class Collections: ICloneable
    {
        public static void workWithArrays()
        {
            // create an array 
            // stored on the heap, reference in stack
            // part of System.Array class
            int[] numbers = new int[] { 1, 2, 3 };
            // access member
            printNumber(numbers[0]);
            // change value
            numbers[1] = 10;
            printNumber(numbers[1]);

            /*
             * output
             * The value of this number is: 1
               The value of this number is: 10
             */

            // iterating arrays
            for (int i = 0; i < numbers.Length; i++)
            {
                printNumber(numbers[i]);
            }

            foreach (int number in numbers) // uses iterators
            {
                printNumber(number);
            }
            /*
             * output
             * The value of this number is: 1
                The value of this number is: 10
                The value of this number is: 3
                The value of this number is: 1
                The value of this number is: 10
                The value of this number is: 3
             */

            // demostrate usages of important methods of the System.Arrays class
            int indexOfNumber = Array.IndexOf(numbers, 3, 1); // start searching at index 1
            System.Console.WriteLine("index of value 3 is: " + indexOfNumber);

            //clear all elemetns
            Array.Sort(numbers); // performs quicksort algorithm
            // perform binary search, used with sorte arrays only
            indexOfNumber = Array.BinarySearch(numbers, 3);
            System.Console.WriteLine("index of value 3 is: " + indexOfNumber);
            /*
             * output
             * index of value 3 is: 2
                index of value 3 is: 1
             */

            // use resize method
            Array.Resize(ref numbers, 2); // resize to 2 elements
            printNumbers(numbers);
            /*
             * output
             * The value of this number is: 1
                The value of this number is: 3
             */

            // reverse elements
            Array.Reverse(numbers);
            printNumbers(numbers);
            /*
             * output
             * The value of this number is: 3
                The value of this number is: 1
             */

            // create multi-dimensional array
            int[,,] dimensionalArray = new int[1, 1, 1] // each comma represents one dimension
            {
                {{1}}
            };

            // jagged array
            // we may store any numbers of values in each array -> no restriction on the number of elments of aaray members
            int[][] jaggedArray = new int[1][];
            jaggedArray[0] = new int[1] { 1 };
            for (int i = 0; i < 1; i++)
            {
                foreach (int number in jaggedArray[i])
                {
                    printNumber(number);
                }
            }
            /*
             * output
             * The value of this number is: 1
             */

            //clone and copyo methods
            User[] users = new User[2]
            {
                new User(),
                new User()
            };
            User[] topUsers = new User[2]; // todo: check, must beof size 1 in fact
            //users.CopyTo(topUsers, 1); // shallow copy
            //foreach (User user in topUsers)
            //{
            //    System.Console.WriteLine("user is ${user}");
            //}

            User[] usersCopy = (User[])users.Clone(); // shallow copy
            foreach (User user in topUsers)
            {
                System.Console.WriteLine("user is ${user}");
            }
            /* output
             * user is ${user}
                user is ${user}
             */
            // deep copy
            // must implement IClone interface in User class

            // colelctions
            // generic and non-generic collections -> acccepts values of the same type or different types

            //1 . List<Type> -> generic
            List<int> numbersList = new List<int>(2){1, 2};
            foreach(int number in numbersList)
            {
                printNumber(number);
            }

            // add new numbers
            numbersList.Add(3);
            numbersList.AddRange(new List<int>(2) { 4, 5 });
            numbersList.Insert(numbersList.Count, 6);
            numbersList.InsertRange(0, new List<int> { -3, -2, -1});
            foreach (int number in numbersList)
            {
                printNumber(number);
            }
            /*
             * outpput
             * The value of this number is: -3
                The value of this number is: -2
                The value of this number is: -1
                The value of this number is: 1
                The value of this number is: 2
                The value of this number is: 3
                The value of this number is: 4
                The value of this number is: 5
                The value of this number is: 6
             */

            numbersList.Remove(-3);
            numbersList.RemoveAt(0);
            numbersList.RemoveRange(0, 1);
            foreach (int number in numbersList)
            {
                printNumber(number);
            }
            numbersList.RemoveAll(a => a== 0); // or 
            foreach (int number in numbersList)
            {
                printNumber(number);
            }
            /*
             * output
             * The value of this number is: 1
                The value of this number is: 2
                The value of this number is: 3
                The value of this number is: 4
                The value of this number is: 5
                The value of this number is: 6
             */
            numbersList.Clear();

            numbersList.AddRange(new List<int> { 1, 2, 3 });
            int indexOf3 = numbersList.IndexOf(3);
            printNumber(indexOf3);

            System.Console.WriteLine("this list contains number 2: " + numbersList.Contains(2));
            /*
             * output
             * The value of this number is: 2
                this list contains number 2: True
             */

            numbersList.Sort();
            numbersList.Reverse();
            numbersList.ForEach(number => printNumber(number));
            /*
             * output
             * The value of this number is: 3
                The value of this number is: 2
                The value of this number is: 1
             */

            int[] numbersListArray = numbersList.ToArray();
            printNumbers(numbersListArray);

            System.Console.WriteLine("numbers are above zero" + numbersList.Exists(n => n > 0));
            int indexOf2 = numbersList.FindIndex(n => n==2);
            indexOf2 = numbersList.FindLastIndex(n => n == 2);
            printNumber(indexOf2);

            int n = numbersList.Find(n => n > 0);
            n = numbersList.Find(n => n > 0);
            List<int> numbersAboveZer = numbersList.FindAll(n => n > 0);
            numbersList.ForEach(number => printNumber(number));
            /*
             * output
             * The value of this number is: 3
                The value of this number is: 2
                The value of this number is: 1
                numbers are above zeroTrue
                The value of this number is: 1        
                The value of this number is: 3
                The value of this number is: 2
                The value of this number is: 1
            */

            // map method
            List<int> doubleNumers = numbersList.ConvertAll(a => a * 2);
            doubleNumers.ForEach(number => printNumber(number));
            /*
             * output
             * The value of this number is: 6
                The value of this number is: 4
                The value of this number is: 2
             */

            // 2. dictionary -> generic
            Dictionary<int, string> numbersMap = new Dictionary<int, string>
            {
                {1, "One" },
                {2, "Two" }
            };

            foreach(var numberMap in numbersMap)
            {
                System.Console.WriteLine(numberMap.Key + " corresponds to " + numberMap.Value);
            }

            foreach(int number in numbersMap.Keys)
            {
                printNumber(number);
            }

            foreach(string numberAsWord in numbersMap.Values)
            {
                System.Console.WriteLine(numberAsWord);
            }

            // check if a memeber exists
            numbersMap.ContainsKey(1);
            numbersMap.Add( 3, "Three");
            /*
             * output
             * 1 corresponds to One
                2 corresponds to Two
                The value of this number is: 1
                The value of this number is: 2
                One
                Two
             */

            // 3. SortedList -> generic, sorted map based on key
            SortedList<int, string> sortedNumbersMap = new SortedList<int, string>
            {
                {1, "One" },
                {4, "Four" },
                {3, "Three" },
                {2, "Two" }
            };

            // adding a bit slower, but searching faster
            sortedNumbersMap.Add (-1, "Minus One");
            foreach (string numberAsWord in sortedNumbersMap.Values)
            {
                System.Console.WriteLine(numberAsWord);
            }
            /*
             * output
             * Minus One
                One
                Two
                Three
                Four
             */

            // 4. hash map -> non-generic, much like SortedList, but hash codes are used to store values
            Hashtable hashTableNumbers = new Hashtable()
            {
                {1, "One" },
                {2, "Two" },
                {"Three", 3 } // possible sice it's non-generic
            };
            foreach(DictionaryEntry item in hashTableNumbers)
            {
                System.Console.WriteLine("item is" + item.Key + " " + item.Value);
            }
            /* output
             * item is2 Two
                item is1 One
                item isThree 3
             */

            // 5. hashset -> non-generic, much like hash map, but no keys and hash code caluculated based on value which must be unique
            HashSet<string> numbersHashSet = new HashSet<string>
            {
               "One",
               "Two"
            };
            numbersHashSet.Add("Three");
            foreach(string number in numbersHashSet)
            {
                System.Console.WriteLine(number);
            }
            /*
             * output
             * One
                Two
                Three
             */

            // 6. ArrayList -> non-generic, for lists on any type members
            ArrayList numbersArrayList = new ArrayList()
            {
                1,
                2,
                "One",
                "Two"
            };
            foreach(var number in numbersArrayList)
            {
                // general method for iterating collections of Object type
                if(number is string)
                {
                    System.Console.WriteLine("number is of tye string");
                } else
                {
                    System.Console.WriteLine("number is of tye int");
                }
            }
            /*output
             * number is of tye int
                number is of tye int
                number is of tye string
                number is of tye string
             * 
             */

            // 7. stack -> generic
            Stack<int> numbersStack = new Stack<int>();
            numbersStack.Push(1);
            numbersStack.Push(2);
            foreach(int number in numbersStack)
            {
                printNumber(number);
            }
            numbersStack.Pop();
            foreach(int number in numbersStack)
            {
                printNumber(number);
            }
            // retrieve top-most value only, don't pop
            printNumber(numbersStack.Peek());
            /*
             * output
             * The value of this number is: 1
             * The value of this number is: 1
             */

            //  8. queue -> generic
            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(1);
            numbersQueue.Enqueue(2);
            foreach (int number in numbersQueue)
            {
                printNumber(number);
            }
            numbersQueue.Dequeue();
            foreach (int number in numbersQueue)
            {
                printNumber(number);
            }
            /*
             * output
             * The value of this number is: 2
             */

        }

        // if we had to do deep copy, this is how we would go about it
        public object Clone()
        {
            return new Collections();
        }

        private static void printNumbers(int[] numbers)
        {
            foreach(int number in numbers)
            {
                printNumber(number);
            }
        }

        private static void printNumber(int number)
        {
            System.Console.WriteLine("The value of this number is: " + number);
        }
    }
}
