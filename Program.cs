using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Account
    {
        private string firstName, lastName, address, email;
        private int phoneNumber, userId;
        private double accountBalance;

        public  Account (string tempFirstName, string tempLastName, string tempAddress, int tempPhoneNumber, string tempEmail ) 
        { 
            firstName = tempFirstName;
            lastName = tempLastName;
            address = tempAddress;
            phoneNumber = tempPhoneNumber;
            email = tempEmail;
        }
        public void accountStatment()
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
        }
        public void loginAccount()
        {
            Console.WriteLine("1. Create a New Account");
            Console.WriteLine("2. Search for an account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. A/C Statement");
            Console.WriteLine("6. Delete an account");
            Console.WriteLine("7. Exit");
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
            string tempNumber = Console.ReadLine();
            int inputNumber = Convert.ToInt32(tempNumber);
            Console.WriteLine("Email: ");
            string inputEmail = Console.ReadLine();
            Account accountTest = new Account(inputFname, inputLname, inputAddress, inputNumber, inputEmail);
        }
        public void searchAccount()
        {

        }
        public void depositAccount()
        {

        }
        public void withdrawAcount()
        {

        }
        public void displayAccountStatement()
        {

        }
        public void deleteAccount()
        {

        }
        public void exitAccount()
        {

        }



    }
}
