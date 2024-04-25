using System;
using System.Collections.Generic;
using System.Threading;
namespace PayRollManagementSystem;
class Program
{
    static EmployeeDetails currentEmployee1;

    // public static AttendanceDetails currentEmployee2;
    public static List<EmployeeDetails> PayrollList = new List<EmployeeDetails>();

    public static List<AttendanceDetails> AttendanceList = new List<AttendanceDetails>();

    public static void Main(string[] args)
    {

        AddingDefaultDetails();

        bool isTrue = true;
        int count1 = 0;
        do
        {

            int choice;
            if (count1 == 0)
            {
                System.Console.WriteLine("\n\n--------------Welcome to Application----------------- \n\nMAINMENU:\n\n1.Employee Registration        2.Employee Login        3.Exit");
                System.Console.WriteLine();
                System.Console.Write("Enter the option from MAINMENU: ");
                //count1=0;
                choice = int.Parse(Console.ReadLine());
            }
            else
            {
                System.Console.WriteLine("\nMAINMENU:\n\n1.Employee Registration        2.Employee Login        3.Exit");
                System.Console.Write("\nRe-enter the option from MAINMENU: ");
                count1 = 0;
                choice = int.Parse(Console.ReadLine());
            }

            switch (choice)
            {
                //Registration Process
                case 1:
                    {
                        Registration();
                        break;
                    }

                //Login process
                case 2:
                    {
                        Login();
                        break;
                    }

                //Exit process
                case 3:
                    {
                        isTrue = false;
                        System.Console.WriteLine("\nThank you for Reaching US\n\n--------------Have A Nice Day--------------\n\n");
                        break;
                    }

                //For invalid input
                default:
                    {
                        System.Console.WriteLine("Invalid Input :( ");
                        count1 = 1;
                        break;
                    }
            }


        } while (isTrue);
    }

    //Adding Default Details
    public static void AddingDefaultDetails()
    {
        // Default Employee details

        EmployeeDetails employee1 = new EmployeeDetails("Ravi", DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), 9958858888, Gender.Male, Branch.Eymard, Team.Developer);
        PayrollList.Add(employee1);

        //Default Attendance details

        AttendanceDetails number1 = new AttendanceDetails("SF3001", DateTime.ParseExact("15/05/2022", "dd/MM/yyyy", null), DateTime.ParseExact("09:00 AM", "hh:mm tt", null), DateTime.ParseExact("06:10 PM", "hh:mm tt", null), 8);
        //AttendanceDetails number2 = new AttendanceDetails("AID1002", "SF3002", DateTime.ParseExact("16/05/2022", "dd/MM/yyyy", null), DateTime.ParseExact("9:10 AM", "hh:mm tt", null), DateTime.ParseExact("06:50 PM", "hh:mm tt", null), 8);

        AttendanceList.Add(number1);
        //AttendanceList.Add(number2);
    }


    //Registration


    public static void Registration()
    {
        System.Console.Write("Enter Your Name: ");
        string name = Console.ReadLine();

        System.Console.Write("Enter the Date of Birth (dd/MM/yyyy): ");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        System.Console.Write("Phone Number: ");
        long phone = long.Parse(Console.ReadLine());

        System.Console.Write("Gender: ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

        System.Console.Write("Branch: ");
        Branch branch = Enum.Parse<Branch>(Console.ReadLine(), true);

        System.Console.Write("Team: ");
        Team team = Enum.Parse<Team>(Console.ReadLine(), true);

        EmployeeDetails employee = new EmployeeDetails(name, dob, phone, gender, branch, team);

        PayrollList.Add(employee);

        System.Console.WriteLine("You are successfully Registered! \n");
        System.Console.WriteLine("Your Employee ID is: " + employee.EmployeeID);
        System.Console.WriteLine("\nYou are redirected to the MainMenu");

    }


    //Login


    public static void Login()
    {
        int increament = 0;
        string temp = "";
        do
        {

            //For the first attempt

            if (increament == 0)
            {
                System.Console.Write("Enter your Employee ID: ");
                temp = Console.ReadLine();
            }

            //For more than one attempt

            else
            {
                System.Console.Write("\nRe-Enter the Employee ID: ");
                temp = Console.ReadLine();
            }

            foreach (var employee in PayrollList)
            {
                if (temp == employee.EmployeeID)
                {
                    System.Console.WriteLine("You are successfully Logged In :) ");
                    currentEmployee1 = employee;
                    increament = 0;

                    //Submenu Process

                    Submenu();

                    break;
                }
                else
                {
                    
                    increament = 1;
                }

            }
            if(increament!=0)
            {
                System.Console.WriteLine("\nInvalid Employee ID :( ");
            }
        } while (!(increament == 0));
    }

    public static void Submenu()
    {

        int choice = 0;
        bool flag = false;
        do
        {

            System.Console.WriteLine("\nSUBMENU:\n\n1.Add Attendance        2.Display Details        3.Calculate Salary        4.Exit");
            System.Console.WriteLine();
            System.Console.Write("Enter the option from SUBMENU: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                //Add Attendance
                case 1:
                    {
                        Addattendance();

                        break;
                    }

                //Display Details
                case 2:
                    {
                        Userdetails();

                        break;
                    }

                //Calculate Salary
                case 3:
                    {
                        Calculatesalary();

                        break;
                    }

                //exit
                case 4:
                    {
                        System.Console.WriteLine("\nYou are redirected to the MainMenu");
                        flag = true;
                        break;
                    }

                default:
                    {
                        System.Console.WriteLine("Invalid Option :( ");
                        System.Console.WriteLine("You are redirected to the SUBMENU again ");
                        break;
                    }
            }
        } while (flag == false);
    }

    public static void Addattendance()
    {

        DateTime checkIn;
        DateTime checkOut;

        System.Console.Write("Do you want to Check-In ? (Yes/No): ");
        string decision = (Console.ReadLine()).ToLower();

        if (decision == "yes")
        {
            System.Console.Write("Enter the Check-In date and Time(dd/MM/yyyy hh:mm tt) : ");
            checkIn = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);


            System.Console.Write("Enter the Check-Out Time(dd/MM/yyyy hh:mm tt): ");
            checkOut = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);
            if (checkIn.Month.Equals(checkOut.Month) && checkIn.Year.Equals(checkOut.Year) && checkIn.Date.Equals(checkOut.Date))
            {
                bool result = CalculateHours(checkIn, checkOut);

                if (result)
                {
                    AttendanceDetails attendee1 = new AttendanceDetails(currentEmployee1.EmployeeID, checkIn.Date, checkIn, checkOut, 8);

                    AttendanceList.Add(attendee1);

                    System.Console.WriteLine("\nCheck-in and Checkout Successful and today you have worked 8 Hours”.");

                    //System.Console.WriteLine("Your Attendace ID is: "+attendee1.AttendanceID);
                }else
                {
                    System.Console.WriteLine("You are redirected to the SUBMENU ");
                }

            }
            else
            {
                System.Console.WriteLine("Please Enter Correct Format");
            }


        }
        else
        {
            System.Console.WriteLine("");
        }

    }

    public static void Userdetails()
    {
        System.Console.WriteLine("\nName: " + currentEmployee1.FullName);
        System.Console.WriteLine("DOB: " + currentEmployee1.DOB.ToString("dd/MM/yyyy"));
        System.Console.WriteLine("Mobile Number: " + currentEmployee1.MobileNumber);
        System.Console.WriteLine("Gender: " + currentEmployee1.Gender);
        System.Console.WriteLine("Branch: " + currentEmployee1.Branch);
        System.Console.WriteLine("Team: " + currentEmployee1.Team);
    }

    public static void Calculatesalary()
    {
        double amount = 0;
        foreach (AttendanceDetails item in AttendanceList)
        {
            if (item.EmployeeID == currentEmployee1.EmployeeID)
            {
                System.Console.WriteLine("Attendance ID: " + item.AttendanceID);
                System.Console.WriteLine("Employee ID: " + item.EmployeeID);
                System.Console.WriteLine("Date: " + item.Date.ToString("dd/MM/yyyy"));
                System.Console.WriteLine("Check IN: " + item.CheckIn.ToString("hh:mm tt"));
                System.Console.WriteLine("Employee Out: " + item.CheckOut.ToString("hh:mm tt"));
                System.Console.WriteLine("Hours Worked : " + item.HoursWorked);
                System.Console.WriteLine();
                if (item.CheckIn.Month.Equals(item.CheckOut.Month) && item.CheckIn.Year.Equals(item.CheckOut.Year))
                {
                    amount += 500;
                }

            }
        }
        System.Console.WriteLine("Salary : " + amount);

    }

    public static bool CalculateHours(DateTime checkIn, DateTime checkOut)
    {
        // int hour1 = checkIn.Hour;
        // int hour2 = checkOut.Hour;
        // int workHours = 8;
        // int totalHours = Math.Abs(hour1 - hour2);
        // if (totalHours >= workHours)
        // {
        //     totalHours = workHours;
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
        double totalHours=checkOut.Subtract(checkIn).TotalHours;
        if(totalHours>=8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
