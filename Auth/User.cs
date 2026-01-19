using System.Formats.Asn1;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Authentication
{
    public class User
    {
        public string _name;
        public string lastName;
        public string email;
        public string password;
        protected internal string member;
        private static string tag;
        public AccessLevel accessLevel = AccessLevel.Guest;

        // define a property for _name
        public string Name
        {
            // if we don't define either, the property becomes read-only or write-only
            get { return _name; }
            set { if (value.Length > 0) { _name = value; } }
        }

        // create an auto set and get property -> will be defined implicitely
        public double Height
        {
            // a field called _height will be defined automatically
            get;
            set;
        } = 1.60; // default value that will be used to initialize this field

        // define a non-parameterized constructor as best practice always
        public User()
        {

        }

        // define a constructor
        public User(string name, string lastName)
        {
            this.Name = name; // using property to initialize
            this.lastName = lastName;
        }

        public void printHeight()
        {
            System.Console.WriteLine("this person's height is: " + Height);
        }

        public virtual void getInfo()
        {
            System.Console.WriteLine("all field values are: " + Height + " " + Name);
        }

        // define a static constructor
        static User()
        {
            tag = "User Class";
            System.Console.WriteLine("tag value is: " + tag);
        }

        ~User() {
            System.Console.WriteLine("executed when object is being garbage collected");
        }

        public static void createUsers()
        {
            // create users using constructor
            User user1 = new User("Salma", "Khodaei");
            System.Console.WriteLine(user1._name + " " + user1.lastName);

            //crreate user using object initialization
            User user2 = new User("Soheil", "Khodaei")
            {
                email = "soheil@outlook.com"
            };

            System.Console.WriteLine(user2._name + " " + user2.lastName + " " + user2.email);

            LinuxUser<string> linuxUser = new LinuxUser<string>("member");
            System.Console.WriteLine("Member is: " + linuxUser.Member);

            AnyUser<LinuxUser<string>> anyUser = new AnyUser<LinuxUser<string>>(linuxUser);
            System.Console.WriteLine(anyUser.User);

            // example of is operator
           User linuxUser2 = new LinuxUser<string>("member");

            if (linuxUser2 is LinuxUser<string> lUser2)
            {
                System.Console.WriteLine(lUser2.Member);
            }

            // demostrate sing Dispose interface
            workWithOs();
            /*
             * output
             * shutting down OS
             */
        }

        private static void workWithOs()
        {
            using LinuxUser<string> user = new LinuxUser<string>("member"); // new syntax
            // Dispose automatically called at the end
        }

        public enum AccessLevel
        {
            Admin,
            Guest,
            User
        }
    }


    public class LinuxUser<T> : User, System.IDisposable
    {
        private T _member;
        private Os os;

        public T Member
        {
            get { return _member; }
            set { _member = value; }
        }

        public LinuxUser(T member)
        {
            Member = member;
            // example of inner class usage
            os = new Os();
            os.Name = "Linux";
        }

        private class Os
        { // inner class
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
        }

        void IDisposable.Dispose()
        {
            System.Console.WriteLine("shutting down OS");
        }
        
    }

    public class AnyUser<T> where T : User
    {
        private T _user;

        public T User
        {
            get { return _user; }
            set { _user = value; }
        }

        public AnyUser(T user)
        {
            User = user;
        }
    }
}