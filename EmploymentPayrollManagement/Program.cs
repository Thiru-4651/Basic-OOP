using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.Arm;
namespace EmploymentPayrollManagement;
class Program 
{
    public static List<EmployeeDetails> employeeDetailsList=new List<EmployeeDetails>();
    static EmployeeDetails currentemployee;
    public static void Main(string[] args)
    {
        bool flag=false;
        do
        {
            System.Console.WriteLine("**************** Employee Payrol Management *****************");
            System.Console.WriteLine("1. Registration\n2. Login\n3. Exit");
            int choice=int.Parse(Console.ReadLine());
            
            switch(choice)
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
                    System.Console.WriteLine("*********** Thank You...) ************ ");
                    flag=true;
                    break;
                }
                default:
                {
                    System.Console.WriteLine("************* Invalid Input ***************");
                    break;
                }
            }
            
        } while (!flag);
        
    }
    public static void Registration()
    {
        System.Console.Write("Enter the Name: ");
        string employeeName=Console.ReadLine();

        System.Console.Write("Enter the Role: ");
        string role=Console.ReadLine();

        System.Console.Write("Enter the Work Location (chennai,bangalore,coimabatore): ");
        WorkLocation workLocation=Enum.Parse<WorkLocation>(Console.ReadLine(),true);

        System.Console.Write("Enter the Team Name: ");
        string teamName=Console.ReadLine();

        System.Console.Write("Enter the Date of Joining: ");
        DateTime dateOfJoining=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

        System.Console.Write("Enter the Number of Working Days in month: ");
        double noOfWorkingDays=double.Parse(Console.ReadLine());

        System.Console.Write("Enter the Number of leave taken: ");
        double noOfLeave=double.Parse(Console.ReadLine());

        System.Console.Write("Gender(Male/Female): ");
        Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);

        EmployeeDetails employee=new EmployeeDetails(employeeName,role,workLocation,teamName,dateOfJoining,noOfWorkingDays,noOfLeave,gender);
        
        employeeDetailsList.Add(employee);
        Console.WriteLine("You Are registered Successfully ");
        System.Console.WriteLine("Your emplyeee ID is "+employee.EmployeeID);
    }
    public static void Login()
    {
        bool flag=true;
        System.Console.WriteLine("Enter Your Employee ID");
        string ID=Console.ReadLine();
        foreach (EmployeeDetails employee in employeeDetailsList)
        {
            if(ID.Equals(employee.EmployeeID))
            {
                flag=false;
                System.Console.WriteLine("You are Successfully logged in");
                currentemployee=employee;

                Submenu();
                break;
            }  
        }
        if(flag)
            {
                System.Console.WriteLine("Invalid Employee ID");
            }
    }
    public static void Submenu()
    {
        bool flag=false;
        do
        {
            
            //System.Console.WriteLine("**************** Employee Payrol Management *****************");
            System.Console.WriteLine("1. Calculate Salary \n2. Display Details \n3. Exit");
            int choice=int.Parse(Console.ReadLine());
            
            switch(choice)
            {
                case 1:
                {
                    CalculateSalary();
                    break;
                }
                case 2:
                {
                    DisplayDetails();
                    break;
                }
                case 3:
                {
                    //System.Console.WriteLine("*********** Thank You..:) ************ ");
                    flag=true;
                    break;
                }
                default:
                {
                    System.Console.WriteLine("************* Invalid Input ***************");
                    break;
                }
            }
            
        } while (!flag);
    }
    public static void CalculateSalary()
    {
        double salary=currentemployee.SalaryCalculation();
        System.Console.WriteLine("Your Salary is = "+salary);
    }
    public static void DisplayDetails()
    {
        System.Console.WriteLine($"Employee ID: {currentemployee.EmployeeID}\nEmployee Name: {currentemployee.EmployeeName}\nRole: {currentemployee.Role}\nWork Location: {currentemployee.WorkLocation}");
        System.Console.WriteLine($"Team Name: {currentemployee.TeamName}\nDate of joining: {currentemployee.DateOfJoining.ToString("dd/MM/yyyy")}\nNumber of working days: {currentemployee.NoOfWorkingDays}\nNumber of leave taken: {currentemployee.NoOfLeave}\nGender: {currentemployee.Gender}");
    }
}