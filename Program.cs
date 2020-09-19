using System;
using System.IO;
using System.Net.Mail;

namespace assignment1
    {
    internal class Program
        {
        private static void Main(string[] args)
            {
            UserLogin user = new UserLogin();
            user.LoginScreen() ;
            }
        }

    internal class UserLogin
    // Relevent functions for user to login.
        {
        private string userInput, passInput;

        public void LoginScreen()
        // Function respsonsible to display login screen and obtain user values.
            {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|  WELCOME TO SIMPLE BANKING SYSTEM    |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|══════════════════════════════════════|");
            Console.WriteLine("|          LOGIN TO START              |");
            Console.WriteLine("|          Username:                   |");
            Console.WriteLine("|          Password:                   |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.SetCursorPosition(21, 6);
            userInput = Console.ReadLine();
            Console.SetCursorPosition(21, 7);
            MaskPassword();
            }

        public void MaskPassword()
        // Function respsonsible to mask the password with a "*"
            {
            while (true)
                {
                // Create a new variable that reads invidual keys. Depending on what key is pressed, certain actions will occur
                var character = Console.ReadKey(true);
                if (character.Key == ConsoleKey.Enter)
                // On clicking the "Enter" key, Login() will be called.
                    {
                    Login();
                    }
                if (character.Key == ConsoleKey.Backspace && passInput.Length > 0)
                    {
                    // On clicking "Backspace", as long as password is more than 0, the length of * will decrease by 1 as well as the length of password.
                    Console.Write("\b \b");
                    passInput = passInput.Remove(passInput.Length - 1);
                    }
                else
                // When clicking any other key, this will add the input character to the password and add to the number of * displaying.
                    {
                    passInput += character.KeyChar;
                    Console.Write("*");
                    }
                }
            }

        public void Login()
        // Function responsible for checking that the credentials are correct.
            {
            // Splits the file into an array of strings, each string representing an account.
            string[] lines = System.IO.File.ReadAllLines("login.txt");
            // Checks for correct credentials, going through each line of the text file until the corrent pair is found.
            for (int i = 0; i < lines.Length; i++)
                {
                string[] details = lines[i].Split('|');
                if (userInput == details[0] && passInput == details[1])
                // If credentials are correct, user is logged in and can access the menu.
                    {
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Valid Credentials!... Please enter");
                    Console.ReadKey();
                    Person person = new Person();
                    person.Menu();
                    break;
                    }
                }
            // When all lines are processed and there is still no correct match, Login request is rejected.
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Incorrect details! Please try again");
            userInput = string.Empty;
            passInput = string.Empty;
            Console.ReadKey();
            LoginScreen();
            }
        }

    internal class Person
    // Relevent functions to navigate available features.
        {
        private int inputUserId, menuChoice;
        private string inputFname, inputLname, inputAddress, inputEmail, inputPNumber, inputAccount;
        private double inputAccountBalance;
        private double amount;

        public void Menu()
        // Main menu after user logs in successfully.
            {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  WELCOME TO SIMPLE BANKING SYSTEM  |");
            Console.WriteLine("|════════════════════════════════════|");
            Console.WriteLine("|     1. Create a new account        |");
            Console.WriteLine("|     2. Search for an account       |");
            Console.WriteLine("|     3. Deposit                     |");
            Console.WriteLine("|     4. Withdraw                    |");
            Console.WriteLine("|     5. A/C Statement               |");
            Console.WriteLine("|     6. Delete Account              |");
            Console.WriteLine("|     7. Exit                        |");
            Console.WriteLine("|════════════════════════════════════|");
            Console.WriteLine("|   Enter a Number between 1-7:      |");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.SetCursorPosition(32, 11);
            string input = Console.ReadLine();
            // Need to validate user input, to ensure it is within acceptible bounds.
            validateMenuChoice();
            while (true)
            // User has to enter a number between 1-7 in order to use a specific feature.
                {
                if (validateMenuChoice())
                    {
                    switch (Convert.ToInt32(input))
                        {
                        case 1:
                            createForm();
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
                }

            // Nearly all functions will involve the bool SearchAccount(), GetAccount() and bool ConfirmChoice() to remove repetitve code.
            void displayAccountDetails()
            // Function responsible in showing the statement of an existing account.
                {
                string title = "SEARCH AN ACCOUNT";
                // If SearchAccount() returns true, function continues, using the user input.
                if (SearchAccount(title))
                    {
                    // Gets details from the located account.
                    GetAccount();
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    //Displays the statement to the user.
                    account.AccountStatement();
                    Console.WriteLine("Enter any key to go back to menu!");
                    Console.ReadKey();
                    Menu();
                    }
                else
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Account not found!");
                Console.WriteLine("Check another account (y/n)?");
                Console.SetCursorPosition(29, 12);
                if (ConfirmChoice())
                // Await's user response to attempt the function again, otherwise return menu.
                    {
                    displayAccountDetails();
                    }
                else Menu();
                }

            void depositAccount()
            // Function responsible for depositing money to an existing account.
                {
                string title = "DEPOSIT";
                // If SearchAccount() returns true, function continues, using the user input.
                if (SearchAccount(title))
                    {
                    // Setting minor interface features to maintain ease of use for the user.
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Account found! Enter the amount...");
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("|          Amount : $                  |");
                    Console.SetCursorPosition(21, 8);
                    // User attempts to input the value as a double type.
                    string inputValue = Console.ReadLine();
                    while (validateAmount(inputValue))
                        {
                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine("Invalid amount! Please enter a valid amount");
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine("|          Amount : $                  |");
                        Console.SetCursorPosition(22, 8);
                        inputValue = Console.ReadLine();
                        }
                    // Gets details from the located account and set it.
                    GetAccount();
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    // Updates the value of the provided account.
                    account.AccountDeposit(amount);
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Deposit Successful!                                         ");
                    Console.ReadKey();
                    Menu();
                    }
                else
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Account not found!");
                Console.WriteLine("Check another account (y/n)?");
                Console.SetCursorPosition(29, 12);
                if (ConfirmChoice())
                // Await's user response to attempt the function again, otherwise return menu.
                    {
                    depositAccount();
                    }
                else Menu();
                }

            void withdrawAcount()
            // Function responsible for withdrawing money to an existing account.
                {
                string title = "WITHDRAW";
                // If SearchAccount() returns true, function continues, using the user input.
                if (SearchAccount(title))
                    {
                    // Setting minor interface features to maintain ease of use for the user.
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Account found! Enter the amount...");
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("|          Amount : $                  |");
                    Console.SetCursorPosition(21, 8);
                    // User attempts to input the value as a double type.
                    string inputValue = Console.ReadLine();
                    while (validateAmount(inputValue))
                        {
                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine("Invalid amount! Please enter a valid amount");
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine("|          Amount : $                  |");
                        Console.SetCursorPosition(22, 8);
                        inputValue = Console.ReadLine();
                        }                    // Gets details from the located account and set it.
                    GetAccount();
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    // Updates the value of the provided account.
                    account.AccountWithdraw(amount);
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Withdraw Successful!                                ");
                    Console.ReadKey();
                    Menu();
                    }
                else
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Account not found!");
                Console.WriteLine("Check another account (y/n)?");
                Console.SetCursorPosition(29, 12);
                if (ConfirmChoice())
                // Await's user response to attempt the function again, otherwise return menu.
                    {
                    withdrawAcount();
                    }
                else Menu();
                Console.ReadKey();
                }

            void emailAccountStatement()
            // Function responsible for sending an account statment.
                {
                string title = "STATEMENT";
                // If SearchAccount() returns true, function continues, using the user input.
                if (SearchAccount(title))
                    {
                    // Gets details from the located account and set it.
                    GetAccount();
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    account.AccountStatement();
                    Console.WriteLine("Send Email (y/n)?");
                    Console.SetCursorPosition(22, 15);
                    // Awaits confirmation to continue the function, otherwise return to menu.
                    if (ConfirmChoice())
                        {
                        // Calls in the function to send the email, using the set email.
                        account.SendEmail();
                        Console.WriteLine("Email sending...");
                        Console.SetCursorPosition(0, 17);
                        Console.WriteLine("Email sent successfully!...");
                        Console.ReadKey();
                        Menu();
                        }
                    else
                        {
                        Menu();
                        }
                    }
                else
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Account not found!");
                Console.WriteLine("Check another account (y/n)?");
                Console.SetCursorPosition(29, 12);

                if (ConfirmChoice())
                    {
                    emailAccountStatement();
                    }
                else Menu();
                Console.ReadKey();
                }

            void deleteAccount()
            // Function responsible for deleting an existing account
                {
                string title = "DELETE AN ACCOUNT";
                // If SearchAccount() returns true, function continues, using the user input.
                if (SearchAccount(title))
                    {
                    // Gets details from the located account and set it.
                    GetAccount();
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    account.AccountStatement();
                    Console.WriteLine("Delete Account (y/n)?");
                    Console.SetCursorPosition(22, 15);
                    // Awaits confirmation to continue the function, otherwise return to menu.
                    if (ConfirmChoice())
                        {
                        // Calls in the function to delete the email.
                        account.AccountDelete();
                        Console.SetCursorPosition(0, 17);
                        Console.WriteLine("Account Deleted...");
                        Console.ReadKey();
                        Menu();
                        }
                    else
                        {
                        Menu();
                        }
                    }
                // If SearchAccount() returns false, ConfirmChoice() is invoked (Function failed in locating the account).
                else
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Account not found!");
                Console.WriteLine("Check another account (y/n)?");
                Console.SetCursorPosition(29, 12);
                if (ConfirmChoice())
                    {
                    deleteAccount();
                    }
                else Menu();
                Console.ReadKey();
                }

            void exitAccount()
            // Function responsible for closing the program.
                {
                Console.Clear();
                System.Environment.Exit(1);
                }

            bool validateMenuChoice()
            // Function responsible for validating menu choice.
                {
                try
                    {
                    menuChoice = Convert.ToInt32(input);
                    if (menuChoice > 7)
                        {
                        Console.WriteLine("Invalid input. Please enter a number between 1-7!");
                        Console.ReadKey();
                        Menu();
                        return false;
                        }
                    else return true;
                    }
                catch (Exception e)
                    {
                    Console.WriteLine("Invalid input. Please enter a number between 1-7!");
                    Console.ReadKey();
                    Menu();
                    return false;
                    }
                }

            bool validateAmount(string inputValue)
            // Function responsible for validating menu choice.
                {
                try
                    {
                    amount = Convert.ToDouble(inputValue);
                    return false;
                    }
                catch (Exception e)
                    {
                    return true;
                    }
                }

            void createForm()
            // Function responsible for creating an account.

                {
                // Collects all user inputs.
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|         CREATE A NEW ACCOUNT         |");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|══════════════════════════════════════|");
                Console.WriteLine("|          ENTER THE DETAILS           |");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|          First Name:                 |");
                Console.WriteLine("|          Last Name:                  |");
                Console.WriteLine("|          Address:                    |");
                Console.WriteLine("|          Phone:                      |");
                Console.WriteLine("|          Email:                      |");
                Console.WriteLine("|                                      |");
                Console.WriteLine("╚══════════════════════════════════════╝");
                double inputAccountBalance = 0.0;
                int inputUserId = RandomNumberGenerator();
                Console.SetCursorPosition(23, 7);
                string inputFname = Console.ReadLine();
                Console.SetCursorPosition(22, 8);
                string inputLname = Console.ReadLine();
                Console.SetCursorPosition(20, 9);
                string inputAddress = Console.ReadLine();
                Console.SetCursorPosition(18, 10);
                string inputNumber = Console.ReadLine();
                // Calls NumberCheck() to validate phone number
                while (NumberCheck(inputNumber))
                // While NumberCheck() is true, user cannot complete createAccount(), until it returns false.
                    {
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("Invalid number! Please enter a valid number");
                    Console.ReadKey();
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("|          Phone:                      |");
                    Console.SetCursorPosition(18, 10);
                    inputNumber = Console.ReadLine();
                    }
                Console.SetCursorPosition(18, 11);
                string inputEmail = Console.ReadLine();
                // Calls EmailCheck() to validate email.
                while (EmailCheck(inputEmail))
                // While EmailCheck() is true, user cannot complete createAccount(), until it returns false.
                    {
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("Invalid email! Please enter a valid email");
                    Console.ReadKey();
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("|          Email:                      |");
                    Console.SetCursorPosition(18, 11);
                    inputEmail = Console.ReadLine();
                    }
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("Is the information correct (y/n)?");
                if (ConfirmChoice())
                    {
                    // Uses all user inputs to call CreateAccount(), where an account will be created.
                    CreateAccount(inputUserId, inputFname, inputLname, inputAddress, inputNumber, inputEmail, inputAccountBalance);
                    Console.WriteLine("\n \nAccount Created! details will be provided via email.");
                    // Confirms account creation through sending an email.
                    Account account = new Account(inputUserId, inputAccountBalance, inputFname, inputLname, inputAddress, inputPNumber, inputEmail);
                    Console.WriteLine("\n Account number is: {0}", inputUserId);
                    Console.WriteLine("\n Email being sent, please wait 4-6 seconds before clicking any key");
                    account.SendEmail();
                    Console.ReadKey();
                    Menu();
                    }
                else
                    {
                    createForm();
                    }
                Console.ReadKey();
                Menu();
                }
            }

        public void GetAccount()
        // Using an existing Account Number, file is split into different variables.
            {
            // Identify each line uniquely using an Array String.
            string[] lines = System.IO.File.ReadAllLines("accounts\\" + inputAccount + ".txt");
            // Identify the specific line and split the line to obtain the correct variable.
            // Assign each variable to their correpsonding value.
            string[] detail = lines[0].Split('|');
            inputFname = detail[1];
            detail = lines[1].Split('|');
            inputLname = detail[1];
            detail = lines[2].Split('|');
            inputAddress = detail[1];
            detail = lines[3].Split('|');
            inputPNumber = detail[1];
            detail = lines[4].Split('|');
            inputEmail = detail[1];
            detail = lines[5].Split('|');
            inputUserId = Convert.ToInt32(detail[1]);
            detail = lines[6].Split('|');
            inputAccountBalance = Convert.ToDouble(detail[1]);
            }

        public bool EmailCheck(string email)
        // Boolean function responsible for validating the email.
            {
            // the string value of email must contain "@".
            if (email.Contains("@")) return false;
            else return true;
            }

        public bool NumberCheck(string phoneNumber)
        // Boolean function responsible for validating the phone number.
            {
            // the string length of phonenumber be less than 10.
            if (phoneNumber.Length < 10) return false;
            else return true;
            }

        public int RandomNumberGenerator()
        // Function responsible for generating a random int for Account Number.
            {
            // Generates a number within the given boundary.
            Random rnd = new Random();
            int number = rnd.Next(1000001, 9999999);
            return number;
            }

        public bool SearchAccount(string title)
        // Function responsible For locating an account by Account Number if it exists.

            {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("|                                      |");
            Console.Write("|           {0}                        ", title);
            Console.SetCursorPosition(39, 2);
            Console.WriteLine("|");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|══════════════════════════════════════|");
            Console.WriteLine("|          ENTER THE DETAILS           |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|          Account Number:             |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.SetCursorPosition(27, 7);
            string searchInput = Console.ReadLine(); // I enter 10001 into the thing
            // Creates an array string of account names
            string[] accounts = Directory.GetFiles("accounts");
            foreach (string i in accounts)
            // Processes each value to check whether the input exists in the array string
                {
                if (i == "accounts\\" + searchInput + ".txt") // IF THE FUNCTION FINDS IT 
                    {
                    // If a file with the input value exists, then inputAccount is assigned to the searched value.
                    // Returns true to show that the Function has successfully located an account.
                    int number = Convert.ToInt32(searchInput);
                    inputAccount = searchInput;
                    inputUserId = number; // 100001
                    return true;
                    }
                }
            // If function fails to locate an account with the input value, then no such file exists.
            return false;
            }

        public bool ConfirmChoice()
        // Function Responsible to validate user's choice.
            {
            while (true)
                {
                try
                    {
                    char input = Console.ReadKey().KeyChar.ToString().ToLower()[0];
                    if (char.IsLetter(input))
                        {
                        switch (input)
                            {
                            case 'y':
                                return true;

                            case 'n':
                                return false;

                            default:
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("Please select from the options listed");
                                break;
                            }
                        }

                    }
                catch (Exception e)
                    {
                    Console.WriteLine("Error. Please select 'y' or 'no'");
                    Console.ReadKey();
                    ConfirmChoice();
                    }
                }
            }

        public void CreateAccount(int userId, string firstName, string lastName, string address, string phoneNumber, string email, double accountBalance)
        // Function responsible for creating an account, using values from the user.
            {
            // Creates a txt.file within the accounts folder.
            using (var text = new StreamWriter("accounts\\" + userId + ".txt"))
                {
                // Writes text in way that is always identical for each new value.
                text.WriteLine("First Name|{0}", firstName);
                text.WriteLine("Last Name|{0}", lastName);
                text.WriteLine("Address|{0}", address);
                text.WriteLine("Phone|{0}", phoneNumber);
                text.WriteLine("Email|{0}", email);
                text.WriteLine("AccountNo|{0}", userId);
                text.WriteLine("Balance|{0}", accountBalance);
                text.Close();
                }
            }
        }

    internal class Account
    // Relevent functions for a specifed account.
        {
        private string firstName, lastName, address, phoneNumber, email;
        private int userId;
        private double accountBalance, amount;

        public Account(int tempUserId, double tempAccountBalance, string tempFirstName, string tempLastName, string tempAddress, string tempPhoneNumber, string tempEmail)
        // Obtain values from the Person class and assigns it to relevent variables.
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
        // Function responsible for displaying all relevent data to the user.
            {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|            ACCOUNT DETAILS            |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|═══════════════════════════════════════|");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|       Account No:                     |");
            Console.WriteLine("|       Account Balance: $              |");
            Console.WriteLine("|       First Name:                     |");
            Console.WriteLine("|       Last Name:                      |");
            Console.WriteLine("|       Address:                        |");
            Console.WriteLine("|       Phone:                          |");
            Console.WriteLine("|       Email:                          |");
            Console.WriteLine("|                                       |");
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
            }

        public void AccountDeposit(double amt)
        // Function responsible for computing the deposit function.

            {
            // Calculates new account balance.
            double temp = accountBalance;
            amount = amt;
            string type = "deposit";
            accountBalance = temp + amount;
            // Line of string to replace the original line.
            string text = "Balance|" + accountBalance;
            // Locates the correct file to update.
            string[] lines = System.IO.File.ReadAllLines("accounts\\" + userId + ".txt");
            lines[6] = text;
            // Overwrites the original line with a new string of text that includes the updated account balance.
            File.WriteAllLines("accounts\\" + userId + ".txt", lines);
            updateTransaction(type);
            }

        public void AccountWithdraw(double amt)
        // Function responsible for computing the withdraw function.
            {
            double temp = accountBalance;
            amount = amt;
            string type = "withdraw";
            accountBalance = temp - amount;
            // Line of string to replace the original line.
            string text = "Balance|" + accountBalance;
            // Locates the correct file to update.
            string[] lines = System.IO.File.ReadAllLines("accounts\\" + userId + ".txt");
            lines[6] = text;
            // Overwrites the original line with a new string of text that includes the updated account balance.
            File.WriteAllLines("accounts\\" + userId + ".txt", lines);
            updateTransaction(type);
            }

        public void SendEmail()
        // Function responsible for sending an email containing the account statment.

            {
            // Assigning the recipant email.
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress("kphetmany@gmail.com");
            MailMessage message = new MailMessage(from, to);
            // Body and Subject of the email being sent.
            string htmlString = "Here is your Bank Statement: \n \n Account Number:" + userId + "\n Account Balance: $" + accountBalance + "\n First Name: " + firstName + "\n Last Name: " + lastName + "\n Address: " + address + "\n Phone Number: " + phoneNumber;
            message.Subject = "A/C Bank Statement";
            message.Body = htmlString;
            // Password to authorize sending the email.
            string password = "DotNet123";
            // SmptpClient is used to send the email.
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 25;
            smtpServer.Credentials = new System.Net.NetworkCredential("dotnetappken@gmail.com", password);
            smtpServer.EnableSsl = true;
            try
                {
                // Request to send the email.
                smtpServer.Send(message);
                }
            catch (Exception e)
                {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", e.ToString()); 
                Console.WriteLine("Email could not be sent! Please return to the menu");
                Console.ReadKey();

                }
            }

        public void AccountDelete()
        // Function responsible for deleting the file.
            {
            // Delete the file based on the location of the file.
            File.Delete("accounts\\" + userId + ".txt");
            }

        public void updateTransaction(string type)
        // Function responsible for recording a history of transactions whether depositing or withdrawing.
            {
            // obtains current date.
            string date = DateTime.Now.ToString("dd.MM.yyyy");
                {
                using (StreamWriter writer = new StreamWriter("accounts\\" + userId + ".txt", true))
                    {
                    // Appends to the text file, adding a new line of text.
                    writer.Write("{0}|{1}|{2}|{3}", date, type, amount, accountBalance);
                    writer.Close();
                    }
                }
            }
        }
    }