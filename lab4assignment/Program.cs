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
                    throw new ArgumentException("Balance cannot be negative.");
                }
                _balance = value;
            }
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount cannot be negative.");
            }
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount cannot be negative.");
            }
            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account Balance: ${Balance:F2}";
        }

        public static void Main()
        {
            BankAccount account = new BankAccount(1000);
            Console.WriteLine(account);  // Output: Account Balance: $1000.00

            account.Deposit(500);
            Console.WriteLine(account);  // Output: Account Balance: $1500.00

            account.Withdraw(200);
            Console.WriteLine(account);  // Output: Account Balance: $1300.00

            account.Balance = 2000;
            Console.WriteLine(account);  // Output: Account Balance: $2000.00

            try
            {
                account.Balance = -100;  // Throws ArgumentException: Balance cannot be negative.
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Readline();
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
                    throw new ArgumentException("Balance cannot be negative.");
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
                    throw new ArgumentException("Balance cannot be negative.");
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
}
