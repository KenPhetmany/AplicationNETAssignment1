using System;
using System.IO;

namespace assignment1
    {
    internal class Person
        {
        private string inputAccount;

        public void menu()
            {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║  WELCOME TO SIMPLE BANKING SYSTEM  ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine("║     1. Create a new account        ║");
            Console.WriteLine("║     2. Search for an account       ║");
            Console.WriteLine("║     3. Deposit                     ║");
            Console.WriteLine("║     4. Withdraw                    ║");
            Console.WriteLine("║     5. A/C Statement               ║");
            Console.WriteLine("║     6. Delete Account              ║");
            Console.WriteLine("║     7. Exit                        ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine("║   Enter Number:                    ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.SetCursorPosition(18, 11);
            while (true)
                {
                try
                    {
                    int inputChoice = Convert.ToInt32(Console.ReadLine());
                    switch (inputChoice)
                        {
                        case 1:
                            createAccount();
                            break;

                        case 2:
                            displayAccountDetails();
                            break;

                        case 3:
                            depositAccount();
                            break;

                        case 4:
                            withdrawAcount();
                            break;

                        case 5:
                            emailAccountStatement();
                            break;

                        case 6:
                            deleteAccount();
                            break;

                        case 7:
                            exitAccount();
                            break;
                        }
                    }
                catch (Exception e)
                    {
                    Console.WriteLine("Please enter a number within 1-7!");
                    Console.ReadKey();
                    menu();
                    }
                }

            void displayAccountDetails()
                {
                if (SearchAccount())
                    {
                    string[] lines = System.IO.File.ReadAllLines("accounts\\" + inputAccount + ".txt");
                    string[] detail = lines[0].Split('|');
                    int inputUserId = Convert.ToInt32(detail[1]);
                    detail = lines[1].Split('|');
                    string inputFname = detail[1];
                    detail = lines[2].Split('|');
                    string inputLname = detail[1];
                    detail = lines[3].Split('|');
                    string inputAddress = detail[1];
                    detail = lines[4].Split('|');
                    int inputPNumber = Convert.ToInt32(detail[1]);
                    detail = lines[5].Split('|');
                    string inputEmail = detail[1];
                    detail = lines[6].Split('|');
                    double inputAccountBalance = Convert.ToInt32(detail[1]);
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    account.AccountStatement();
                    }
                else
                if (ErrorAccount())
                    {
                    displayAccountDetails();
                    }
                else menu();
                }
            void depositAccount()
                {
                if (SearchAccount())
                    {
                    Console.WriteLine("I would deposit money");
                    //int inputAmount = Convert.ToInt32(Console.ReadLine());
                    }
                else
                if (ErrorAccount())
                    {
                    depositAccount();
                    }
                else menu();
                }
            void withdrawAcount()
                {
                if (SearchAccount())
                    {
                    Console.WriteLine("I would Withdraw money");
                    //Console.WriteLine("Amount: $");
                    //int inputAmount = Convert.ToInt32(Console.ReadLine());
                    }
                else
                if (ErrorAccount())
                    {
                    withdrawAcount();
                    }
                else menu();
                Console.ReadKey();
                }
            void emailAccountStatement()
                {
                if (SearchAccount())
                    {
                    Console.WriteLine("I would Send Statement");
                    }
                else
                if (ErrorAccount())
                    {
                    emailAccountStatement();
                    }
                else menu();
                Console.ReadKey();
                }
            void deleteAccount()
                {
                if (SearchAccount())
                    {
                    Console.WriteLine("I would Delete Account");
                    }
                else
                if (ErrorAccount())
                    {
                    deleteAccount();
                    }
                else menu();
                Console.ReadKey();
                }
            void exitAccount()
                {
                Console.Clear();
                Console.ReadKey();
                }

            void createAccount()
                {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("║         CREATE A NEW ACCOUNT         ║");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║          ENTER THE DETAILS           ║");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("║          First Name:                 ║");
                Console.WriteLine("║          Last Name:                  ║");
                Console.WriteLine("║          Address:                    ║");
                Console.WriteLine("║          Phone:                      ║");
                Console.WriteLine("║          Email:                      ║");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.SetCursorPosition(23, 7);
                string inputFname = Console.ReadLine();
                Console.SetCursorPosition(22, 8);
                string inputLname = Console.ReadLine();
                Console.SetCursorPosition(20, 9);
                string inputAddress = Console.ReadLine();
                Console.SetCursorPosition(18, 10);
                string inputNumber = Console.ReadLine();
                while (NumberCheck(inputNumber))
                    {
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("Invalid number! Please enter a valid number");
                    Console.ReadKey();
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("║          Phone:                      ║");
                    Console.SetCursorPosition(18, 10);
                    inputNumber = Console.ReadLine();
                    }
                Console.SetCursorPosition(18, 11);
                string inputEmail = Console.ReadLine();
                double inputAccountBalance = 0.0;
                int inputUserId = RandomNumberGenerator();
                while (EmailCheck(inputEmail))
                    {
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("Invalid email! Please enter a valid email");
                    Console.ReadKey();
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("║          Email:                      ║");
                    Console.SetCursorPosition(18, 11);
                    inputEmail = Console.ReadLine();
                    }
                CreateAccount(inputUserId, inputFname, inputLname, inputAddress, inputNumber, inputEmail, inputAccountBalance);
                Console.WriteLine("Account Created! Press any key to go back to the menu.");
                Console.ReadKey();
                menu();
                }
            }

        public bool EmailCheck(string email)
            {
            if (email.Contains("@")) return false;
            else return true;
            }

        public bool NumberCheck(string phoneNumber)
            {
            if (phoneNumber.Length < 10) return false;
            else return true;
            }

        public int RandomNumberGenerator()
            {
            Random rnd = new Random();
            int number = rnd.Next(1000001, 9999999);
            return number;
            }

        public bool SearchAccount()
            {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║           SEARCH AN ACCOUNT          ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║          ENTER THE DETAILS           ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║          Account Number:             ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.SetCursorPosition(27, 7);
            string input = Console.ReadLine();
            string[] accounts = Directory.GetFiles("accounts");
            foreach (string i in accounts)
                {
                if (i == "accounts\\" + input + ".txt")
                    {
                    inputAccount = input;
                    return true;
                    }
                }
            return false;
            }

        public bool ErrorAccount()
            {
            Console.WriteLine("Account not found!");
            Console.WriteLine("Check another account (y/n)?");
            while (true)
                {
                try
                    {
                    string inputChoice = Console.ReadLine();
                    switch (inputChoice)
                        {
                        case "y":
                            return true;

                        case "n":
                            return false;
                        }
                    }
                catch (Exception e)
                    {
                    Console.WriteLine(e);
                    Console.ReadKey();
                    }
                }
            }

        public void CreateAccount(int userId, string firstName, string lastName, string address, string phoneNumber, string email, double accountBalance)
            {
            using (var text = new StreamWriter("accounts\\" + userId + ".txt"))
                {
                text.WriteLine("AccountNo|{0}", userId);
                text.WriteLine("First Name|{0}", firstName);
                text.WriteLine("Last Name|{0}", lastName);
                text.WriteLine("Address|{0}", address);
                text.WriteLine("Phone|{0}", phoneNumber);
                text.WriteLine("Email|{0}", email);
                text.WriteLine("Balance|{0}", accountBalance);
                text.Close();
                }
            }
        }

    internal class Account
        {
        private string firstName, lastName, address, email;
        private int phoneNumber, userId;
        private double accountBalance;

        public Account(int tempUserId, double tempAccountBalance, string tempFirstName, string tempLastName, string tempAddress, int tempPhoneNumber, string tempEmail)
            {
            userId = tempUserId;
            accountBalance = tempAccountBalance;
            firstName = tempFirstName;
            lastName = tempLastName;
            address = tempAddress;
            phoneNumber = tempPhoneNumber;
            email = tempEmail;
            }

        public void AccountStatement()
            {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║            ACCOUNT DETAILS            ║");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║       Account No:                     ║");
            Console.WriteLine("║       Account Balance: $              ║");
            Console.WriteLine("║       First Name:                     ║");
            Console.WriteLine("║       Last Name:                      ║");
            Console.WriteLine("║       Address:                        ║");
            Console.WriteLine("║       Phone:                          ║");
            Console.WriteLine("║       Email:                          ║");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.SetCursorPosition(20, 6);
            Console.Write(userId);
            Console.SetCursorPosition(26, 7);
            Console.Write(accountBalance);
            Console.SetCursorPosition(20, 8);
            Console.Write(firstName);
            Console.SetCursorPosition(19, 9);
            Console.Write(lastName);
            Console.SetCursorPosition(17, 10);
            Console.Write(address);
            Console.SetCursorPosition(15, 11);
            Console.Write(phoneNumber);
            Console.SetCursorPosition(15, 12);
            Console.Write(email);
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Enter any key to go back to menu!");
            Console.ReadKey();
            Person person = new Person();
            person.menu();
            }

        public void AccountDeposit(double amount)
            {
            double temp = accountBalance;
            accountBalance = temp + amount;
            }

        public void AccountWithdraw(double amount)
            {
            double temp = accountBalance;
            accountBalance = temp - amount;
            }
        }

    internal class UserLogin
        {
        private string userInput;
        private string passInput;

        public void LoginScreen()
            {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║  WELCOME TO SIMPLE BANKING SYSTEM    ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║          LOGIN TO START              ║");
            Console.WriteLine("║          Username:                   ║");
            Console.WriteLine("║          Password:                   ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.SetCursorPosition(21, 4);
            userInput = Console.ReadLine();
            Console.SetCursorPosition(21, 5);
            passInput = Console.ReadLine();
            Console.SetCursorPosition(3, 8);
            Login();
            }

        public void Login()
            {
            string[] splits = System.IO.File.ReadAllText("login.txt").Split('|');
            if (userInput == splits[0] && passInput == splits[1])
                {
                Person test = new Person();
                test.menu();
                }
            else
                {
                Console.WriteLine("Incorrect details! Please try again");
                Console.ReadKey();
                LoginScreen();
                }
            }
        }

    internal class Program
        {
        private static void Main(string[] args)
            {
            Person person = new Person();
            person.menu();
            }
        }
    }