using System;
using Microsoft.Data.SqlClient;

namespace MVC_BankingApp
{
    // MODEL
    public class BankAccount
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }

    // VIEW
    public class BankView
    {
        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void DisplayAccount(BankAccount acc)
        {
            Console.WriteLine("\n----- Account Details -----");
            Console.WriteLine("Account No : " + acc.AccountNo);
            Console.WriteLine("Name       : " + acc.Name);
            Console.WriteLine("Balance    : " + acc.Balance);
        }
    }

    // CONTROLLER
    public class BankController
    {
        string conStr =
            "Server=localhost;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True;";

        private BankView view;

        public BankController(BankView view)
        {
            this.view = view;
        }

        public void CreateAccount(int accNo, string name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query =
                    "INSERT INTO Accounts(AccountNo,Name,Balance) VALUES(@acc,@name,0)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@acc", accNo);
                cmd.Parameters.AddWithValue("@name", name);

                con.Open();
                cmd.ExecuteNonQuery();

                view.ShowMessage("Account Created Successfully!");
            }
        }

        public void Deposit(int accNo, double amount)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query =
                    "UPDATE Accounts SET Balance = Balance + @amt WHERE AccountNo=@acc";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@amt", amount);
                cmd.Parameters.AddWithValue("@acc", accNo);

                con.Open();
                cmd.ExecuteNonQuery();

                view.ShowMessage("Amount Deposited!");
            }
        }

        public void Withdraw(int accNo, double amount)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string checkQuery =
                    "SELECT Balance FROM Accounts WHERE AccountNo=@acc";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@acc", accNo);

                con.Open();

                double balance = Convert.ToDouble(checkCmd.ExecuteScalar());

                if (balance >= amount)
                {
                    string query =
                        "UPDATE Accounts SET Balance = Balance - @amt WHERE AccountNo=@acc";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@acc", accNo);

                    cmd.ExecuteNonQuery();

                    view.ShowMessage("Amount Withdrawn!");
                }
                else
                {
                    view.ShowMessage("Insufficient Balance!");
                }
            }
        }

        public void ShowBalance(int accNo)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query =
                    "SELECT * FROM Accounts WHERE AccountNo=@acc";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@acc", accNo);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    BankAccount acc = new BankAccount
                    {
                        AccountNo = Convert.ToInt32(dr["AccountNo"]),
                        Name = dr["Name"].ToString(),
                        Balance = Convert.ToDouble(dr["Balance"])
                    };

                    view.DisplayAccount(acc);
                }
                else
                {
                    view.ShowMessage("Account Not Found!");
                }
            }
        }
    }

    // MAIN
    class Program
    {
        static void Main(string[] args)
        {
            BankView view = new BankView();
            BankController controller = new BankController(view);

            int choice;

            do
            {
                Console.WriteLine("\n===== BANK MENU =====");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Account No: ");
                        int accNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        controller.CreateAccount(accNo, name);
                        break;

                    case 2:
                        Console.Write("Enter Account No: ");
                        accNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Amount: ");
                        double dep = Convert.ToDouble(Console.ReadLine());

                        controller.Deposit(accNo, dep);
                        break;

                    case 3:
                        Console.Write("Enter Account No: ");
                        accNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Amount: ");
                        double wd = Convert.ToDouble(Console.ReadLine());

                        controller.Withdraw(accNo, wd);
                        break;

                    case 4:
                        Console.Write("Enter Account No: ");
                        accNo = Convert.ToInt32(Console.ReadLine());

                        controller.ShowBalance(accNo);
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