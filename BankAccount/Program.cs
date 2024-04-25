using System;
using System.Collections.Generic;
using System.Data.Common;
namespace BankAccount;
class Program
{
    // int balance = 0;
    public static void Main(string[] args)
    {
        string toContinue = "yes";
        List<BankAccountDetails> accountList = new List<BankAccountDetails>();
        do
        {

            Console.WriteLine("!!Welcome!! what process do you want do? \n1.Registration \n2.Login \n3.Exit");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        System.Console.Write("Enter your name: ");
                        string customerName = Console.ReadLine();

                        System.Console.Write("Gender: ");
                        Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

                        System.Console.Write("Balance: ");
                        int balance = int.Parse(Console.ReadLine());

                        System.Console.Write("Phone Number: ");
                        long phone = long.Parse(Console.ReadLine());

                        System.Console.Write("Mail ID: ");
                        string mailId = Console.ReadLine();

                        System.Console.Write("Date of Birth (dd/MM/yyyy): ");
                        DateTime dateofBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        BankAccountDetails customer1 = new BankAccountDetails(customerName, gender, balance, phone, mailId, dateofBirth);
                        //id = 1001;

                        System.Console.WriteLine("You Are registered successfully !\nYour customer ID is " + customer1.CustomerId);

                        accountList.Add(customer1);
                        accountList.AddRange(accountList);

                        break;
                    }
                case 2:
                    {
                        System.Console.Write("Enter your customer ID: ");
                        string temp = Console.ReadLine();
                        foreach (var customer in accountList)
                        {
                            if (temp==customer.CustomerId)
                            {

                                System.Console.WriteLine("You Are successfully Logged In");
                                do
                                {
                                    System.Console.WriteLine("Menu:\n1.Deposit\n2.Withdraw\n3.Balance check\n4.Exit");
                                    int loginOption = int.Parse(Console.ReadLine());
                                    switch (loginOption)
                                    {
                                        case 1:
                                            {
                                                System.Console.Write("Cash in numbers: ");
                                                int depositcash = int.Parse(Console.ReadLine());
                                                int total = customer.Deposit(depositcash);
                                                System.Console.WriteLine("Cash was successfully deposited.");
                                                System.Console.WriteLine("Your current balance is " + total);
                                                break;
                                            }
                                        case 2:
                                            {
                                                System.Console.Write("Cash in numbers: ");
                                                int withdrawcash = int.Parse(Console.ReadLine());
                                                int total = customer.Withdraw(withdrawcash);
                                                System.Console.WriteLine("Your current balance is " + total);
                                                break;

                                            }
                                        case 3:
                                            {
                                                System.Console.WriteLine("Your current balance is " + customer.Balance);
                                                break;
                                            }
                                        case 4:
                                            {
                                                toContinue = "no";
                                                System.Console.WriteLine("You are going to be logged off....");
                                                break;
                                            }
                                    }
                                } while (toContinue == "yes");
                            }
                            else
                            {
                                System.Console.WriteLine("Invalid User ID");
                            }
                            toContinue = "yes";
                        }
                        break;
                    }

                case 3:
                    {
                        toContinue = "no";
                        System.Console.WriteLine("Thank you reaching US ..Have a nice day!");
                        break;
                    }
            }
            // if(toContinue=="yes")
            // {
            // Console.Write("Do you want to continue(yes/no): ");

            // toContinue = Console.ReadLine();
            // }
            // else{
            //     System.Console.WriteLine("Thank you! Have a nice day");
            // }


        } while (toContinue == "yes");

    }
}