using System.Net.NetworkInformation;


int adminPin = 0000;
int adminChoice = 0;
int currentPin = 0;
int enteredPin;
int wrongAttempts = 0;
int balance = 1000;
int deposit = 0;
int withdraw = 0;
int choice = 0;
bool isBlocked = false;
string[] transactions = new string[5];
int txIndex = 0;
int secondAccountBalance = 500;
string transferAccountName = "account";
int user1Pin = 1234, user2Pin = 2345, user3Pin = 3456;
int user1Balance = 1000, user2Balance = 2000, user3Balance = 3000;

/*
This do-while loop handles the Admin section of the ATM.
It first asks for the admin PIN. If the entered PIN is correct, it presents a menu with options like viewing all user balances or resetting a user's balance.
The loop continues to display the admin menu until the admin chooses to exit by selecting option 3.
This structure ensures the admin can perform multiple tasks in one session without having to re-enter the PIN each time.
*/



Console.WriteLine("Press 1 if you are Admin \nPress 2 If you are admin: ");
int enterUserChoice = Convert.ToInt32(Console.ReadLine());

switch (enterUserChoice)
{
    case 1:

        do
        {
            Console.WriteLine("If you are a admin enter your pin: ");
            int enterAdminPin = Convert.ToInt32(Console.ReadLine());

            if (enterAdminPin == adminPin)

                Console.WriteLine($" 1. View All User Balances \n 2. Reset Any User's Balance\n 3. Exit ");
            adminChoice = Convert.ToInt32(Console.ReadLine());

            {
                switch (adminChoice)
                {
                    case 1:
                        Console.WriteLine($"{user1Balance}, {user2Balance}, {user3Balance}");
                        break;


                    case 2:

                        Console.WriteLine("Enter pin of account to reset: ");
                        int enterPin = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Amount to reset: ");
                        int resetBalance = Convert.ToInt32(Console.ReadLine());
                        
                        if (user1Pin == enterPin )
                        {
                            user1Balance = resetBalance;
                            Console.WriteLine($"updated balance : {user1Balance}");
                        }
                        else if (user2Pin == enterPin)
                        {
                            user2Balance = resetBalance;
                            Console.WriteLine($"updated balance : {user2Balance}");
                        }
                        else if (user2Pin == enterPin)
                        {
                            user3Balance = resetBalance;
                            Console.WriteLine($"updated balance : {user3Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Pin");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Thank you");

                        break;
                }

            }

        } while (adminChoice != 3);

        break;


    case 2:

        /*
        This while loop checks if the user has entered the wrong PIN multiple times.
        If the number of wrong attempts is less than 3, it allows the user to continue.
        Once inside, the user is asked to enter their PIN. If the entered PIN matches the correct one, the user gains access to the ATM menu.
        To ensure the menu is shown at least once and keeps running until the user chooses to exit, a do-while loop is used inside the PIN validation block.
        */

        while (wrongAttempts < 3)
        {
            //Ask pin take user input
            Console.WriteLine("Enter pin: ");
            enteredPin = Convert.ToInt32(Console.ReadLine());

            switch (enteredPin)
            {
                case 1234:

                    currentPin = user1Pin;

                    if (enteredPin == currentPin && !isBlocked)
                    {
                        Console.WriteLine("Access granted!\n");
                        //If pin is correct inorder to show menu untill user want to exit do while.
                        do
                        {
                            Console.WriteLine("\nATM Menu");
                            Console.WriteLine("1. Check Balance");
                            Console.WriteLine("2. Deposit Money");
                            Console.WriteLine("3. Withdraw Money");
                            Console.WriteLine("4. View Transaction History");
                            Console.WriteLine("5. Transfer funds");
                            Console.WriteLine("6. Change Pin");
                            Console.WriteLine("7. Exit");
                            Console.Write("Enter your choice: ");

                            choice = Convert.ToInt32(Console.ReadLine());


                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine($" Balance: {user1Balance:C}\t");
                                    Console.Write((user1Balance > 500) ? "Good Standing" : "Low balance");
                                    break;

                                case 2:
                                    Console.Write("Enter amount to deposit: ");
                                    deposit = Convert.ToInt32(Console.ReadLine());

                                    if (deposit > 10000)
                                    {
                                        Console.WriteLine("Deposit limit exceeded. Please contact bank.");
                                    }
                                    else
                                    {
                                        user1Balance += deposit;
                                        Console.WriteLine($"Updated balance: {user1Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"deposited: {deposit}";
                                        txIndex++;

                                    }

                                    break;

                                case 3:
                                    Console.Write("Enter amount to withdraw: ");
                                    withdraw = Convert.ToInt32(Console.ReadLine());

                                    if (withdraw <= balance)
                                    {
                                        user1Balance -= withdraw;
                                        Console.WriteLine($"Withdrawn. New balance: {user1Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"withdrawn: {withdraw}";
                                        txIndex++;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds.");
                                    }
                                    break;

                                case 4:

                                    bool hasAny = false;

                                    for (int i = 0; i < transactions.Length; i++)
                                    {
                                        if (!string.IsNullOrWhiteSpace(transactions[i]))
                                        {
                                            Console.WriteLine(transactions[i]);
                                            hasAny = true;
                                        }
                                    }

                                    if (!hasAny)
                                    {
                                        Console.WriteLine("No transactions yet");
                                    }

                                    break;

                                case 5:
                                    Console.WriteLine("Please Enter the accountName:");
                                    string accountName = Convert.ToString(Console.ReadLine());

                                    Console.WriteLine("Please Enter the amount:");
                                    int transferAmount = Convert.ToInt32(Console.ReadLine());


                                    if (accountName.Equals(transferAccountName) && transferAmount <= balance)
                                    {
                                        secondAccountBalance += transferAmount;
                                        user1Balance -= transferAmount;
                                        Console.WriteLine($"Your updated balance: {user1Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"transfered: {transferAmount}";
                                        txIndex++;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Tranfer failed");

                                    }

                                    break;

                                case 6:
                                    Console.WriteLine("Enter your current PIN:");
                                    int pin = Convert.ToInt32(Console.ReadLine());

                                    if (pin == currentPin)
                                    {
                                        Console.WriteLine("Enter your new PIN:");
                                        int newPin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("ReEnter your new PIN:");
                                        int confirmPin = Convert.ToInt32(Console.ReadLine());

                                        if (confirmPin == newPin)
                                        {
                                            currentPin = newPin;
                                            Console.WriteLine("PIN changed successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pin do not match try again!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong pin! Try again!");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;

                                case 7:
                                    Console.WriteLine("Goodbye! Thank you for using our ATM.");
                                    break;

                            }
                        } while (choice != 7);
                    }
                    else
                    {
                        Console.WriteLine("Wrong pin try again: ");
                        wrongAttempts++;

                        if (wrongAttempts == 3)
                        {
                            isBlocked = true;
                        }

                        int remaining = 3 - wrongAttempts;

                        switch (remaining)
                        {
                            case 0:
                                Console.WriteLine("You are banned!");
                                break;

                            case 1:

                                Console.WriteLine("Last attempt");
                                break;

                            case 2:
                                Console.WriteLine("Only two attempts left!");
                                break;
                        }

                    }
                    break;

                case 2345:

                    currentPin = user2Pin;

                    if (enteredPin == currentPin && !isBlocked)
                    {
                        Console.WriteLine("Access granted!\n");

                        //If pin is correct inorder to show menu untill user want to exit do while.
                        do
                        {
                            Console.WriteLine("\nATM Menu");
                            Console.WriteLine("1. Check Balance");
                            Console.WriteLine("2. Deposit Money");
                            Console.WriteLine("3. Withdraw Money");
                            Console.WriteLine("4. View Transaction History");
                            Console.WriteLine("5. Transfer funds");
                            Console.WriteLine("6. Change Pin");
                            Console.WriteLine("7. Exit");
                            Console.Write("Enter your choice: ");

                            choice = Convert.ToInt32(Console.ReadLine());


                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine($" Balance: {user2Balance:C}\t");
                                    Console.Write((user2Balance > 500) ? "Good Standing" : "Low balance");
                                    break;

                                case 2:
                                    Console.Write("Enter amount to deposit: ");
                                    deposit = Convert.ToInt32(Console.ReadLine());

                                    if (deposit > 10000)
                                    {
                                        Console.WriteLine("Deposit limit exceeded. Please contact bank.");
                                    }
                                    else
                                    {
                                        user2Balance += deposit;
                                        Console.WriteLine($"Updated balance: {user2Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"deposited: {user2Balance}";
                                        txIndex++;

                                    }

                                    break;

                                case 3:
                                    Console.Write("Enter amount to withdraw: ");
                                    withdraw = Convert.ToInt32(Console.ReadLine());

                                    if (withdraw <= balance)
                                    {
                                        balance -= withdraw;
                                        Console.WriteLine($"Withdrawn. New balance: {user2Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"withdrawn: {withdraw}";
                                        txIndex++;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds.");
                                    }
                                    break;

                                case 4:
                                    bool hasAny = false;

                                    for (int i = 0; i < transactions.Length; i++)
                                    {
                                        if (!string.IsNullOrWhiteSpace(transactions[i]))
                                        {
                                            Console.WriteLine(transactions[i]);
                                            hasAny = true;
                                        }
                                    }

                                    if (!hasAny)
                                    {
                                        Console.WriteLine("No transactions yet");
                                    }

                                    break;

                                case 5:
                                    Console.WriteLine("Please Enter the accountName:");
                                    string accountName = Convert.ToString(Console.ReadLine());

                                    Console.WriteLine("Please Enter the amount:");
                                    int transferAmount = Convert.ToInt32(Console.ReadLine());


                                    if (accountName.Equals(transferAccountName) && transferAmount <= balance)
                                    {
                                        secondAccountBalance += transferAmount;
                                        user2Balance -= transferAmount;
                                        Console.WriteLine($"Your updated user2Balance: {user2Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"transfered: {transferAmount}";
                                        txIndex++;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Tranfer failed");

                                    }

                                    break;

                                case 6:
                                    Console.WriteLine("Enter your current PIN:");
                                    int pin = Convert.ToInt32(Console.ReadLine());

                                    if (pin == currentPin)
                                    {
                                        Console.WriteLine("Enter your new PIN:");
                                        int newPin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("ReEnter your new PIN:");
                                        int confirmPin = Convert.ToInt32(Console.ReadLine());

                                        if (confirmPin == newPin)
                                        {
                                            currentPin = newPin;
                                            Console.WriteLine("PIN changed successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pin do not match try again!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong pin! Try again!");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;

                                case 7:
                                    Console.WriteLine("Goodbye! Thank you for using our ATM.");
                                    break;

                            }
                        } while (choice != 7);
                    }
                    else
                    {
                        Console.WriteLine("Wrong pin try again: ");
                        wrongAttempts++;

                        if (wrongAttempts == 3)
                        {
                            isBlocked = true;
                        }

                        int remaining = 3 - wrongAttempts;

                        switch (remaining)
                        {
                            case 0:
                                Console.WriteLine("You are banned!");
                                break;

                            case 1:

                                Console.WriteLine("Last attempt");
                                break;

                            case 2:
                                Console.WriteLine("Only two attempts left!");
                                break;
                        }

                    }
                    break;

                case 3456:

                    currentPin = user3Pin;

                    if (enteredPin == currentPin && !isBlocked)
                    {
                        Console.WriteLine("Access granted!\n");
                        //If pin is correct inorder to show menu untill user want to exit do while.
                        do
                        {
                            Console.WriteLine("\nATM Menu");
                            Console.WriteLine("1. Check Balance");
                            Console.WriteLine("2. Deposit Money");
                            Console.WriteLine("3. Withdraw Money");
                            Console.WriteLine("4. View Transaction History");
                            Console.WriteLine("5. Transfer funds");
                            Console.WriteLine("6. Change Pin");
                            Console.WriteLine("7. Exit");
                            Console.Write("Enter your choice: ");

                            choice = Convert.ToInt32(Console.ReadLine());


                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine($" Balance: {user3Balance:C}\t");
                                    Console.Write((user3Balance > 500) ? "Good Standing" : "Low balance");
                                    break;

                                case 2:
                                    Console.Write("Enter amount to deposit: ");
                                    deposit = Convert.ToInt32(Console.ReadLine());

                                    if (deposit > 10000)
                                    {
                                        Console.WriteLine("Deposit limit exceeded. Please contact bank.");
                                    }
                                    else
                                    {
                                        user3Balance += deposit;
                                        Console.WriteLine($"Updated balance: {user3Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"deposited: {deposit}";
                                        txIndex++;

                                    }
                                    break;

                                case 3:
                                    Console.Write("Enter amount to withdraw: ");
                                    withdraw = Convert.ToInt32(Console.ReadLine());

                                    if (withdraw <= balance)
                                    {
                                        user3Balance -= withdraw;
                                        Console.WriteLine($"Withdrawn. New balance: {user3Balance:C}");
                                        transactions[txIndex % transactions.Length] = $"withdrawn: {withdraw}";
                                        txIndex++;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds.");
                                    }
                                    break;

                                case 4:
                                    bool hasAny = false;

                                    for (int i = 0; i < transactions.Length; i++)
                                    {
                                        if (!string.IsNullOrWhiteSpace(transactions[i]))
                                        {
                                            Console.WriteLine(transactions[i]);
                                            hasAny = true;
                                        }
                                    }

                                    if (!hasAny)
                                    {
                                        Console.WriteLine("No transactions yet");
                                    }

                                    break;

                                case 5:
                                    Console.WriteLine("Please Enter the accountName:");
                                    string accountName = Convert.ToString(Console.ReadLine());

                                    Console.WriteLine("Please Enter the amount:");
                                    int transferAmount = Convert.ToInt32(Console.ReadLine());


                                    if (accountName.Equals(transferAccountName) && transferAmount <= balance)
                                    {
                                        secondAccountBalance += transferAmount;
                                        balance -= transferAmount;
                                        Console.WriteLine($"Your updated balance: {balance:C}");
                                        transactions[txIndex % transactions.Length] = $"transfered: {transferAmount}";
                                        txIndex++;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Tranfer failed");

                                    }

                                    break;

                                case 6:
                                    Console.WriteLine("Enter your current PIN:");
                                    int pin = Convert.ToInt32(Console.ReadLine());

                                    if (pin == currentPin)
                                    {
                                        Console.WriteLine("Enter your new PIN:");
                                        int newPin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("ReEnter your new PIN:");
                                        int confirmPin = Convert.ToInt32(Console.ReadLine());

                                        if (confirmPin == newPin)
                                        {
                                            currentPin = newPin;
                                            Console.WriteLine("PIN changed successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pin do not match try again!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong pin! Try again!");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;

                                case 7:
                                    Console.WriteLine("Goodbye! Thank you for using our ATM.");
                                    break;

                            }
                        } while (choice != 7);
                    }
                    else
                    {
                        Console.WriteLine("Wrong pin try again: ");
                        wrongAttempts++;

                        if (wrongAttempts == 3)
                        {
                            isBlocked = true;
                        }

                        int remaining = 3 - wrongAttempts;

                        switch (remaining)
                        {
                            case 0:
                                Console.WriteLine("You are banned!");
                                break;

                            case 1:

                                Console.WriteLine("Last attempt");
                                break;

                            case 2:
                                Console.WriteLine("Only two attempts left!");
                                break;
                        }

                    }
                    break;
            }

        }
        break;
}




