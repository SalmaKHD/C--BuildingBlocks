using Auth;
using MyFirstApplication; // using a namespace 

class Sample
{
    static void Main()
    {
        // part of System namespace
        System.Console.WriteLine("Hello");
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
        User user1 = new User();
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

        // create users using constructor
        User.createUsers();

        customer1[0] = "444343344";
        Console.WriteLine(customer1[0]);

        // read a field that has been modified with base
        System.Console.WriteLine(customer1.email);

        System.Console.ReadKey();

    }
}

// OOP
// access modifiers: public and internal -> internal means it can be used in the same project only
// modifier -> static, abstract, sealed, partial
// public modifier -> useful for a class library only: because other projects may get access to it only
// objects store data only -> not methods
internal sealed class Customer: User // default access modifier: internal
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
        set
        {
            this._orders[index] = value;    
        }
        get
        {
            return this._orders[index]; 
        }
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

    public ref int getAgeRef()
    {
        return ref age; // returns a reference to age variable
    }

    static public void parameterKeywords(User defaultParameter, out int outParameter, ref User refParameter, in int inParameter, params string[] parameters)
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
