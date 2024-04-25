using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
namespace EBbillCalculation;
class Program
{
    public static List<EBbillDetails>detailsList=new List<EBbillDetails>();
    static EBbillDetails currentID;
    public static void Main(string[] args)
    {
        bool flag=true;
        do
        {
            System.Console.WriteLine("Select the process you want to do \n1.Registration\n2.Login\n3.Exit");
            int option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Registration();
                    break;
                }
                case 2:
                {
                    Login();
                    break;
                }
                case 3:
                {
                    flag=false;
                    System.Console.WriteLine("Thank you for reaching US. Have Nice Day!!!");
                    break;
                }
                default:
                {
                    System.Console.WriteLine("Invalid Input");
                    System.Console.WriteLine();
                    break;
                }
                
            }
        }while(flag);
    }
    public static void Registration()
    {
        System.Console.Write("Enter the name: ");
        string userName=Console.ReadLine();

        System.Console.Write("Phone number: ");
        long phoneNumber=long.Parse(Console.ReadLine());

        System.Console.Write("Mail Id: ");
        string mailID=Console.ReadLine();

        System.Console.Write("Units: ");
        double units=double.Parse(Console.ReadLine());

        EBbillDetails bill1=new EBbillDetails(userName,phoneNumber,mailID,units);

        detailsList.Add(bill1);
        System.Console.WriteLine("You are registered successfully! ");
        System.Console.WriteLine("Your meter ID is = "+bill1.MeterID);
    } 
    public static void Login()
    {
        bool flag=true;
        do
        {
        System.Console.Write("Enter your meter id: ");
        string meterid=Console.ReadLine();

        foreach (EBbillDetails bill1 in detailsList)
        {
            if(meterid.Equals(bill1.MeterID))
            {
                System.Console.WriteLine("You are successfully logged in..............");
                currentID=bill1;
                Submenu();
                flag=false;
                break;
            }
        }
        if(flag)
        {
            System.Console.WriteLine("Invalid User!!");
            // System.Console.Write("Enter your meter id: ");
            // meterid=Console.ReadLine();
        }
        } while (flag);

    }
    public static void Submenu()
    {
        bool flag=false;
        do{
        System.Console.WriteLine("1.Calclulate Amount: ");
        System.Console.WriteLine("2.Display User Datails\n3.Exit to Main Menu");
        int choice=int.Parse(Console.ReadLine());
        switch(choice)
        {
            case 1:
            {
                double salary=currentID.CalculateAmount();
                System.Console.WriteLine("The user name: "+currentID.UserName);
                System.Console.WriteLine("Unit: "+currentID.Units);
                System.Console.WriteLine("The bill amount is: "+salary);
                break;
            }
            case 2:
            {
                DisplayUserDetails();
                break;
            }
            case 3:
            {
                flag=true;
                break;
            }
            default:
            {
                System.Console.WriteLine("Invalid input");
                break;
            }

        }
        }while(!flag);
    }
    public static void DisplayUserDetails()
    {
        System.Console.WriteLine("The meter id: "+currentID.MeterID);
        //System.Console.WriteLine();
        System.Console.WriteLine("Name: "+currentID.UserName);
        // System.Console.WriteLine();
        System.Console.WriteLine("Phone: "+currentID.PhoneNumber);
        // System.Console.WriteLine();
        System.Console.WriteLine("Mail ID: "+currentID.MailID);
        System.Console.WriteLine();
        System.Console.WriteLine();
    }
}
