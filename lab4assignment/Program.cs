using lab4assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab4assignment
{
    public class BankAccount
    {
        private double _balance;

        public BankAccount(double initialBalance = 0)
        {
            Balance = initialBalance;
        }

        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
                _balance = value;
            }
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Deposit amount cannot be negative.");
            }
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Withdrawal amount cannot be negative.");
            }
            if (Balance < amount)
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account Balance: ${Balance:F2}";
        }

    }
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }

        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
                _balance = value;
            }
        }

        public string FullCarName => $"{Make} {Model} {Year}";

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
            Balance = 0; // Default balance is set to 0.
        }

        public override string ToString()
        {
            return FullCarName;
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
                _balance = value;
            }
        }

        public string FullName => $"{FirstName} {LastName}".ToUpper();

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = 0; // Default balance is set to 0.
        }
    }
    public class Temperature
    {
        private double _celsius;

        public double Celsius
        {
            get { return _celsius; }
            set
            {
                if (value < -273.15)
                {
                    Console.WriteLine("Temperature in Celsius cannot be below absolute zero.");
                }
                _celsius = value;
            }
        }

        public double Fahrenheit => (_celsius * 9 / 5) + 32;

        public Temperature(double celsius)
        {
            Celsius = celsius;
        }
    }
    public class CustomList<T>
    {
        private T[] items;
        private int count;

        public CustomList(int capacity)
        {
            if (capacity <= 0)
            {
                Console.WriteLine(nameof(capacity), "Capacity must be greater than zero.");
            }

            items = new T[capacity];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine(nameof(index), "Index is out of range.");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine(nameof(index), "Index is out of range.");
                }
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                // Resize the internal array if needed.
                Array.Resize(ref items, items.Length * 2);
            }
            items[count] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine(nameof(index), "Index is out of range.");
            }

            // Shift elements to the left to remove the item at the specified index.
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }
    }
    public class SimpleStack<T>
    {
        private T[] stack;
        private int top; // Index of the top element

        public int Count
        {
            get { return top + 1; }
        }

        public SimpleStack(int capacity)
        {
            if (capacity <= 0)
            {
                Console.WriteLine(nameof(capacity), "Capacity must be greater than zero.");
            }

            stack = new T[capacity];
            top = -1; // Initialize the top index to -1 (empty stack)
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > top)
                {
                    Console.WriteLine(nameof(index), "Index is out of range.");
                }
                return stack[index];
            }
        }

        public void Push(T item)
        {
            if (top == stack.Length - 1)
            {
                // Resize the internal array if the stack is full.
                Array.Resize(ref stack, stack.Length * 2);
            }

            top++;
            stack[top] = item;
        }

        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty.");
            }

            T poppedItem = stack[top];
            top--;

            return poppedItem;
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    public class Bookshelf
    {
        private Dictionary<string, Book> booksByTitle = new Dictionary<string, Book>();

        public Book this[string title]
        {
            get
            {
                if (booksByTitle.ContainsKey(title))
                {
                    return booksByTitle[title];
                }
                else
                {
                    Console.WriteLine($"Book with title '{title}' not found on the bookshelf.");
                }
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine(nameof(value), "Book cannot be null.");
                }

                // If the book already exists in the dictionary, update it; otherwise, add a new book.
                booksByTitle[title] = value;
            }
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine(nameof(book), "Book cannot be null.");
            }

            // Add the book to the dictionary by its title.
            booksByTitle[book.Title] = book;
        }

        public void RemoveBook(string title)
        {
            if (booksByTitle.ContainsKey(title))
            {
                booksByTitle.Remove(title);
            }
            else
            {
                Console.WriteLine($"Book with title '{title}' not found on the bookshelf.");
            }
        }
    }

    public enum ShapeType
    {
        Circle,
        Square,
        Triangle
    }

    public class Geometry
    {
        public static double CalculateArea(ShapeType shape, double[] parameters)
        {
            switch (shape)
            {
                case ShapeType.Circle:
                    if (parameters.Length != 1)
                    {
                        Console.WriteLine("A circle requires one parameter: radius.");
                    }
                    double radius = parameters[0];
                    return Math.PI * Math.Pow(radius, 2);

                case ShapeType.Square:
                    if (parameters.Length != 1)
                    {
                        Console.WriteLine("A square requires one parameter: side length.");
                    }
                    double sideLength = parameters[0];
                    return Math.Pow(sideLength, 2);

                case ShapeType.Triangle:
                    if (parameters.Length != 2)
                    {
                        Console.WriteLine("A triangle requires two parameters: base and height.");
                    }
                    double triangleBase = parameters[0];
                    double height = parameters[1];
                    return 0.5 * triangleBase * height;

                default:
                    Console.WriteLine("Invalid shape type.");
            }
        }
    }

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

}





class Program
{
    public void q1call()
    {
        BankAccount account = new BankAccount(1000);
        Console.WriteLine(account);  // Output: Account Balance: $1000.00

        account.Deposit(500);
        Console.WriteLine(account);  // Output: Account Balance: $1500.00

        account.Withdraw(200);
        Console.WriteLine(account);  // Output: Account Balance: $1300.00

        account.Balance = 2000;
        Console.WriteLine(account);  // Output: Account Balance: $2000.00
    }
    public void q2call()
    {
        Car car1 = new Car("Toyota", "Camry", 2022);
        car1.Balance = 5000; // Setting a positive balance
        Console.WriteLine(car1.FullCarName); // Output: Toyota Camry 2022


    }
    public void q3call()
    {
        Person person1 = new Person("John", "Doe");
        person1.Balance = 1000; // Setting a positive balance
        Console.WriteLine(person1.FullName); // Output: JOHN DOE


    }
    public void q4call()
    {
        Temperature temp1 = new Temperature(25.0);
        Console.WriteLine($"Celsius: {temp1.Celsius}°C");       // Output: Celsius: 25°C
        Console.WriteLine($"Fahrenheit: {temp1.Fahrenheit}°F"); // Output: Fahrenheit: 77°F


    }
    public void q5call()
    {
        CustomList<int> myList = new CustomList<int>(3);

        myList.Add(10);
        myList.Add(20);
        myList.Add(30);

        Console.WriteLine(myList[0]); // Output: 10
        Console.WriteLine(myList[1]); // Output: 20
        Console.WriteLine(myList[2]); // Output: 30

        myList[1] = 25;
        Console.WriteLine(myList[1]); // Output: 25

        myList.RemoveAt(0);
        Console.WriteLine(myList[0]); // Output: 25
        Console.WriteLine(myList.Count); // Output: 2
    }
    public void q6call()
    {
        SimpleStack<int> stack = new SimpleStack<int>(3);

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine(stack[2]); // Output: 10
        Console.WriteLine(stack[1]); // Output: 20
        Console.WriteLine(stack[0]); // Output: 30

        int poppedItem = stack.Pop();
        Console.WriteLine(poppedItem); // Output: 30

        Console.WriteLine(stack.Count); // Output: 2

    }
    public void q7call()
    {
        var shelf = new Bookshelf();

        var book1 = new Book { Title = "Book 1", Author = "Author 1", Year = 2020 };
        var book2 = new Book { Title = "Book 2", Author = "Author 2", Year = 2021 };

        shelf.AddBook(book1);
        shelf.AddBook(book2);

        Console.WriteLine(shelf["Book 1"].Author); // Output: Author 1
        Console.WriteLine(shelf["Book 2"].Year);   // Output: 2021


    }
    public void q8call()
    {
        FileAccessPermission userPermissions = FileAccessPermission.Read | FileAccessPermission.Write;
        if ((userPermissions & FileAccessPermission.Read) == FileAccessPermission.Read)
        {
            Console.WriteLine("User has Read permission.");
        }
        if ((userPermissions & FileAccessPermission.Write) == FileAccessPermission.Write)
        {
            Console.WriteLine("User has Write permission.");
        }

        if ((userPermissions & FileAccessPermission.Execute) == FileAccessPermission.Execute)
        {
            Console.WriteLine("User has Execute permission.");
        }
        
    }
    public void q9call()
    {
        double[] circleParams = { 5.0 };
        double[] squareParams = { 4.0 };
        double[] triangleParams = { 3.0, 6.0 };
        double circleArea = Geometry.CalculateArea(ShapeType.Circle, circleParams);
        double squareArea = Geometry.CalculateArea(ShapeType.Square, squareParams);
        double triangleArea = Geometry.CalculateArea(ShapeType.Triangle, triangleParams);
        Console.WriteLine($"Circle Area: {circleArea}");
        Console.WriteLine($"Square Area: {squareArea}");
        Console.WriteLine($"Triangle Area: {triangleArea}");

    }
    public void q10call()
    {
        Season currentSeason = Season.Summer;
        switch (currentSeason)
        {
            case Season.Spring:
                Console.WriteLine("It's spring! Flowers are blooming.");
                break;
            case Season.Summer:
                Console.WriteLine("It's summer! Enjoy the warm weather.");
                break;
            case Season.Autumn:
                Console.WriteLine("It's autumn! Leaves are falling.");
                break;
            case Season.Winter:
                Console.WriteLine("It's winter! Time to bundle up.");
                break;
            default:
                Console.WriteLine("Invalid season.");
                break;
        }
    }
    public static void Main()
    {
        Program obj= new Program();
        obj.q1call();
        obj.q2call();
        obj.q3call();
        obj.q4call();
        obj.q5call();
        obj.q6call();
        obj.q7call();
        obj.q8call();
        obj.q9call();
        obj.q10call();
        
    }
}
