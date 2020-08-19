using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Accounts
    {
        private string firstName, lastName, address, email;
        private int phoneNumber, userId;
        private double accountBalance;

        public void newAccount(string tempFirstName, string tempLastName, string tempAddress, string tempEmail, int tempPhoneNumber, double tempAccountBalance, int tempuserId)
        {
            firstName = tempFirstName;
            lastName = tempLastName;
            address = tempAddress;
            email = tempEmail;
            phoneNumber = tempPhoneNumber;
            accountBalance = tempAccountBalance ;
            userId = tempuserId;
        }
        public void accountStatment()
        {

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
