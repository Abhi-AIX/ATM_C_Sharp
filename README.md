# Console-Based ATM System in C#

This is a beginner-friendly C# console application that simulates a real-world ATM system, allowing both Admin and User interactions.

## What This App Does

This project lets you:

- Log in as Admin or User
- View and manage account balances
- Deposit and withdraw money
- View transaction history
- Transfer funds to another account
- Change your PIN
- Handle incorrect attempts and account blocking

## Admin Features

- Accessed with PIN `0000`
- Can:
  - View all user balances
  - Reset a user’s balance
  - Exit the admin panel

## User Features

Users have different PINs:
- `1234`, `2345`, `3456`

Once logged in, a user can:

- Check balance
- Deposit money
- Withdraw money
- View last 5 transactions
- Transfer money to another account (with name check)
- Change PIN securely
- Exit the system

## Security Features

- Allows only 3 wrong PIN attempts
- After 3 failed attempts, user is blocked
- Each account has its own balance and transactions

## Key Concepts Practiced

- if-else & switch statements
- do-while and while loops
- Arrays for transaction history
- User input validation
- Basic condition handling
- PIN security logic

## How to Run

1. Open this project in Visual Studio
2. Build and run the program
3. Follow the prompts in the console

## Learning Goal

This ATM project is perfect for:

- Practicing procedural programming
- Getting real with user interaction
- Building logic-heavy, menu-based applications
- Preparing to later transition into OOP and Classes

## Next Steps

You can improve this project by:

- Adding support for multiple users with a List or Dictionary
- Moving data to files (CSV, JSON, or database)
- Using OOP concepts for cleaner structure
- Creating a GUI with Windows Forms or WPF

### Project Status: `Learning & Practice`

“I’ve done this project to feel the real essence of procedural programming — I wish I had written it this way earlier!”
