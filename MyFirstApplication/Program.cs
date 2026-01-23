using Auth = Authentication; // using directive for not having to use Auth. prefix every time
using MyFirstApplication; // using a namespace 
using static System.Console;
using PartialClasses;
using Authentication;
using System.Linq.Expressions;
using System.ComponentModel.Design;

class Sample
{
    static void Main()
    {
        // part of System namespace
        WriteLine("Hello"); // no namespace and class name needed anymore
        System.Console.ReadKey();

        // decalare a varibale 
        int a = 100;
        System.Console.WriteLine(a);

        // primitive types: single value

        // sbyte: 8-bit signed integer, default value: 0
        System.Console.WriteLine(sbyte.MinValue);
        // byte: 8-bit unsigned int
        System.Console.WriteLine(byte.MinValue);
        // short: 16-bit signed int
        System.Console.WriteLine(short.MinValue);
        // ushort: 16-bit unsigned int
        System.Console.WriteLine(ushort.MinValue);
        // int: 32-bit signed
        System.Console.WriteLine(int.MinValue);
        // uint: 32-bit unsigned
        System.Console.WriteLine(uint.MinValue);
        // long: 64-bit singed int
        System.Console.WriteLine(long.MinValue);
        // ulong: 64-bit unsigned int
        System.Console.WriteLine(ulong.MinValue);
        // float: 32-bit
        System.Console.WriteLine(float.MinValue);
        // double: 64-bit float
        System.Console.WriteLine(double.MinValue);
        // decimal: 128-bit signed floating-point number
        System.Console.WriteLine(decimal.MinValue);
        // char: 16-bit single unicode char, 2 bytes
        System.Console.WriteLine(char.MinValue);
        // bool: 1 bit, default value: false
        System.Console.WriteLine(bool.TrueString);

        // conditionals
        int b = 20;
        if(b > 20)
        {
            System.Console.WriteLine("a is greater than 20");
        }

        // switch statement
        switch(b)
        {
            case 0:
                System.Console.WriteLine("b is 0");
                break;
            case 20:
                System.Console.WriteLine("b is 20");
                break;
            default:
                System.Console.WriteLine("b is ..");
                break;
        }

        // scope of i inside for loop only
        for (int i = 10; i >= 8; i--)
        {
            System.Console.WriteLine("i is " + i);
        }

        // goto label
        // to jump to a statement directly
    //    goto myLabel;

    //myLabel:


        // non-priitive types: multiple values

        // string: each char: 2 bytes, default value: null
        System.Console.WriteLine("");

        // objects
        // customer1 stored in stack
        // object customer1 refers to stored on the heap
        Customer customer1 = new Customer();
        Customer customer2 = new Customer();
        System.Console.WriteLine(Customer.GroupName);
        customer1.SetAge(age: 21); // named arguments

        // local constant value
        const int NUMBER = 12;

        // object creation
        Auth.User user1 = new Auth.User();
        // initialize fields
        user1._name = "Salma";
        user1.lastName = "Khodaei";
        user1.email = "khodaeisalma@gmail.com";
        user1.password = "***";
        System.Console.WriteLine(user1._name);

        // parameter modifiers
        Customer.parameterKeywords(user1, out int outParameter, ref user1, in a, "Salma", "Soheil");
        System.Console.WriteLine("out parameter is: " +  outParameter);
        System.Console.WriteLine(user1._name);
        System.Console.WriteLine(user1.email);

        // ref return
        customer1.getAgeRef() = 20;
        System.Console.WriteLine(customer1.GetAge());

        // type conversions
        Types.typeConversions();

        customer1[0] = "444343344";
        Console.WriteLine(customer1[0]);

        // read a field that has been modified with base
        System.Console.WriteLine(customer1.email);

        // example of method hiding
        customer1.printHeight();
        // example of method overriding
        customer1.getInfo();

        // polymorphism
        Auth.JuniorCustomer juniorCustomer = new Auth.JuniorCustomerImpl();
        juniorCustomer.printAge();
        /*
         * output
         * Age is0
         */

        // polymorphism
        Auth.SeniorCustomer seniorCustomer = new Auth.SeniorCustomerImpl();
        seniorCustomer.printInfo();
        /*
         * output
         * printing senior customer info:
         */

        // partial class example
        Product product = new Product();
        product.getProductInfo();
        /*
         * output
         * product info:
         * Product type is: Female
        */

        // create a struct
        Student student = new Student("salma", 22); // new keyword is dummy here
        //student.name = null; // not possible to store null values
        student.age = 21;
        System.Console.WriteLine("student age is " + student.age);
        /*
         * output
         * student age is 21
         */

        // alternate way to create a struct
        Student student2;// no need for new keyword
        student2.age = 22;
        System.Console.WriteLine("student age is " + student2.age);
        /*
         * output
         * student age is 22
         */

        // sybyte is an alias for SByte struct
        System.Console.WriteLine(sbyte.MinValue);
        System.Console.WriteLine(SByte.MinValue);

        // work with generic types
        // create users using constructor
        Auth.User.createUsers();
        /*
         * output
         * Salma Khodaei
            Soheil Khodaei soheil@outlook.com
            Member is: member
            Authentication.LinuxUser`1[System.String]
            member
         */

        // add nullable struct example
        int? c = null; // not nullabe by default
        customer1 = null; // nullable by default
        c = 4;
        if(c.HasValue)
        {
            System.Console.WriteLine("nullable struct value is " + c.Value);
        }
        // use default value
        c = null;
        System.Console.WriteLine("c with default value is: " + (c ?? 0));
        c?.ToString(); // access member only if not null
        System.Console.WriteLine(customer1);
        /*
         * output
         * nullable struct value is 4
         * c with default value is: 0
         */

        // implicitely inferred type
        var customer3 = new Customer();
        System.Console.WriteLine("customer3 type is " + customer3);
        /*
         * output
         * customer3 type is Customer
         */

        // dynamic type variable example
        dynamic x;
        x = "string-value";
        x = 4;
        x = 4.5;
        System.Console.WriteLine("x final value is " + x);
        /*
         * output
         * x final value is 4.5
         */

        // may be added to 
        // create an anonymous function
        var delegateMethod = delegate (int a, int b)
        {
            System.Console.WriteLine(a + b);
        };

        // create a lambda function
        var lambdaFunction = (int a, int b) => // type is Action
        {
            System.Console.WriteLine(a + b);
        };

        // inline lambda expression
        var lambdaFunction2 = (int a, int b) => a + b; // type is Func

        Predicate<int> lambdaFunction3 = (int a) => true; // predicate function type, one parameter and boolean return value

        // create an expression
        Expression <Func<int, int>> expression = a => a * a;
        Func<int, int> expressionDelegate = expression.Compile(); // compile expression and make ready for execution
        // invoke expression
        int result = expressionDelegate.Invoke(4);
        System.Console.WriteLine("result value is " + result);
        /*
         * output
         * result value is 16
         */

        int age = 15;
        // add switch expression example
        string ageGroup = age switch
        {
            < 6 => "Child",
            < 19 => "Teenager",
            < 50 => "Adult",
            _ => "Senior"
        };
        System.Console.WriteLine("Age group of this person is: " + ageGroup);
        /*
         * output
         * Age group of this person is: Teenager
         */

        // illustrate array usage
        Collections.workWithArrays();

        // anonymous type example
        var person = new { PersonName = "Salma", PersonAge = 24 };
        System.Console.WriteLine("This person's name is " + person.PersonName + ", and her age is: " + person.PersonAge);
        // anonymous type array
        var people = new[]
        {
            new { Name = "Salma", Age = 24 }, // all fields' names and types must match and be the same for all memebrs
            new { Name = "Melika", Age = 32 }
        };
        foreach(var localPerson in people)
        {
            System.Console.WriteLine("This person's name is " + localPerson.Name + ", and her age is: " + localPerson.Age);
        }
        /*
         * output
         * This person's name is Salma, and her age is: 24
         * This person's name is Salma, and her age is: 24
            This person's name is Melika, and her age is: 32
         */



    }
}

// OOP
// access modifiers: public and internal -> internal means it can be used in the same project only
// modifier -> static, abstract, sealed, partial
// public modifier -> useful for a class library only: because other projects may get access to it only
// objects store data only -> not methods
internal sealed class Customer: Auth.User // default access modifier: internal
{
    // components
    // fields
    // methods
    // constructors
    // properties
    // events
    // destructors
    public static int instanceNumbers; // access-modifier modifier primitive/non-primitive type -> static: common to all objects
    public string name; // default access modifier: private
    private int age;
    public const string GroupName = "customers"; // constants are replaced with actual value at compile time, static members by default
    public readonly string dateOfPurchase; // cannot be modified
    // create an array for demonstrating indexers
    public string[] _orders = new string[] {"443434", "43434", "65656565"};

    public string this[int index]
    {
        // convert to expression-bodied method
        set => this._orders[index] = value;

        // convert to expression-bodied method
        get => this._orders[index];
    }

    public Customer(): base()
    {
        // acces base members
        base.email = "Salma@gmail.com";
    }

    // age setter
    public void SetAge(int age = 20) // define a default parameter value also, parameter becomes optional
    {
        this.age = age; 
    }

    // age getter
    public int GetAge()
    {
        return this.age;
    }

    // convert to expression-bodied method
    public ref int getAgeRef() => ref age; // returns a reference to age variable

    // do method hiding
    public new void printHeight()
    {
        System.Console.WriteLine("This person's height is: " + Height);
    }

    // do method overriding
    public sealed override void getInfo() // child classes of Customer can't override this anymore
    {
        base.getInfo();
        System.Console.WriteLine("additional field values are: " + GetAge());
    }

    static public void parameterKeywords(Auth.User defaultParameter, out int outParameter, ref Auth.User refParameter, in int inParameter, params string[] parameters)
    {
        outParameter = 4;
        refParameter._name = "Soheil";
        defaultParameter.email = "salma@gmail.com";
        System.Console.WriteLine("address of default user is " + defaultParameter);
        System.Console.WriteLine("address of ref user paramer is " + refParameter);
        //inParameter = 5; // can't do


        printArrayMembers();
        printArrayMembersStatic(parameters);

        // define a local function
        void printArrayMembers()
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                System.Console.WriteLine(parameters[i]);
            }
        }

        // define a static local function
        static void printArrayMembersStatic(params string[] members)
        {
            for (int i = 0; i < members.Length; i++)
            {
                System.Console.WriteLine(members[i]);
            }
        }

    }
}

// not possible due to being sealed
//class RegionalCustomer: Customer
//{

//}

// create an abstract class
namespace Authentication // part of Auth namespace in User class
{
    public abstract class JuniorCustomer : User
    {
        protected int age;

        public abstract void printAge();
    }

    public class JuniorCustomerImpl : JuniorCustomer
    {
        public override void printAge()
        {
            System.Console.WriteLine("Age is" + age);
        }

        // override equals virtual method
        public override bool Equals(object? obj)
        {
            // cast to object and compare as needed
            JuniorCustomer juniorCustomer = obj as JuniorCustomer;
            return true; // just an example
        }
    }

    // interface example
    public interface SeniorCustomer
    {
        int Age { get; set; }

        void printInfo(); // implementations must implement this, by default public and abstract
    }

    public class SeniorCustomerImpl : SeniorCustomer
    {
        int _age;

        public void printInfo()
        {
            System.Console.WriteLine("printing senior customer info: ");
        }


        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

    }
}

namespace Authentication
{
    public struct Student
    {
        // has a parametter-less constructor by default
        public string name;
        public int age;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age; // all fields must be initialized in the constructor
        }
    }

    // readonly struct
    public readonly struct Teacher
    {
        public readonly string name;
        public readonly int age;

        public Teacher(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}