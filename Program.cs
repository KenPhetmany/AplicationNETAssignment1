using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Person
    {
        public void menu()
        {
            Console.WriteLine("1. Create a New Account");
            Console.WriteLine("2. Search for an account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. A/C Statement");
            Console.WriteLine("6. Delete an account");
            Console.WriteLine("7. Exit");
            Console.ReadKey();
        }
        public void createAccount()
        {
            Console.WriteLine("First Name: ");
            string inputFname = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string inputLname = Console.ReadLine();
            Console.WriteLine("Address: ");
            string inputAddress = Console.ReadLine();
            Console.WriteLine("Phone: ");
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Email: ");
            string inputEmail = Console.ReadLine();
            Account accountCreate = new Account(inputFname, inputLname, inputAddress, inputNumber, inputEmail);
        }
        public void searchAccount()
        {
            Console.WriteLine("Account Number: ");
            string inputAccountNumber = Console.ReadLine();
        }
        public void depositAccount()
        {
            Console.WriteLine("Account Number: ");
            string inputAccountNumber = Console.ReadLine();
            Console.WriteLine("Amount: $");
            int inputAmount = Convert.ToInt32(Console.ReadLine());

        }
        public void withdrawAcount()
        {
            Console.WriteLine("Account Number: ");
            string inputAccountNumber = Console.ReadLine();
            Console.WriteLine("Amount: $");
            int inputAmount = Convert.ToInt32(Console.ReadLine());
        }
        public void displayAccountStatement()
        {
            Console.WriteLine("Account Number: ");
            string inputAccountNumber = Console.ReadLine();

        }
        public void deleteAccount()
        {
            Console.WriteLine("Account Number: ");
            string inputAccountNumber = Console.ReadLine();

        }
        public void exitAccount()
        {
            Console.WriteLine("Goodbye");
            Console.ReadKey();
        }
    }
    class Account
    {
        private string firstName, lastName, address, email;
        private int phoneNumber, userId;
        private double accountBalance;

        public Account (string tempFirstName, string tempLastName, string tempAddress, int tempPhoneNumber, string tempEmail ) 
        { 
            firstName = tempFirstName;
            lastName = tempLastName;
            address = tempAddress;
            phoneNumber = tempPhoneNumber;
            email = tempEmail;
        }
        public void accountStatement()
        {
            Console.WriteLine("Account No: ");
            Console.WriteLine("Account Balance: ");
            Console.WriteLine("First Name: ");
            Console.WriteLine("Last Name: ");
            Console.WriteLine("Address: ");
            Console.WriteLine("Phone: ");
            Console.WriteLine("Email: ");
            Console.ReadLine();
        }
        public void accountDeposit (double amount)
        {
            double temp = accountBalance;
            accountBalance = temp + amount;
        }
        public void accountWithdraw(double amount)
        {
            double temp = accountBalance;
            accountBalance = temp - amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User Name: ");
            Console.WriteLine("Password: ");
            Console.ReadKey();
            Console.WriteLine("");
            Person test = new Person();
            test.menu();
        }

    }
}
