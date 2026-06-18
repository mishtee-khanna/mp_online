using System;

namespace MVC_ConsoleApp
{
    // Model
    public class BankAccount
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }

    // View
    public class BankView
    {
        public void DisplayAccount(BankAccount account)
        {
            Console.WriteLine("\nAccount Details");
            Console.WriteLine("Account No : " + account.AccountNo);
            Console.WriteLine("Name       : " + account.Name);
            Console.WriteLine("Balance    : " + account.Balance);
        }
    }

    // Controller
    public class BankController
    {
        private BankAccount _account;
        private BankView _view;

        public BankController(BankAccount account, BankView view)
        {
            _account = account;
            _view = view;
        }

        public void Deposit(double amount)
        {
            _account.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= _account.Balance)
                _account.Balance -= amount;
            else
                Console.WriteLine("Insufficient Balance!");
        }

        public void ShowBalance()
        {
            Console.WriteLine("Current Balance : " + _account.Balance);
        }

        public void UpdateView()
        {
            _view.DisplayAccount(_account);
        }
    }

    internal class BankingMVC
    {
        public static void Application()
        {
            Console.Write("Enter Account Number : ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            BankAccount account = new BankAccount
            {
                AccountNo = accNo,
                Name = name,
                Balance = 0
            };

            BankView view = new BankView();
            BankController controller = new BankController(account, view);

            int choice;

            do
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Show Account");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice : ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Amount : ");
                        controller.Deposit(Convert.ToDouble(Console.ReadLine()));
                        break;

                    case 2:
                        Console.Write("Enter Amount : ");
                        controller.Withdraw(Convert.ToDouble(Console.ReadLine()));
                        break;

                    case 3:
                        controller.ShowBalance();
                        break;

                    case 4:
                        controller.UpdateView();
                        break;

                    case 5:
                        Console.WriteLine("Thank You!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 5);
        }
    }
}
