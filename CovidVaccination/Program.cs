using System;
namespace CovidVaccination;
class Program
{
    public static void Main(string[] args)
    {
        //Calling the AddDefaultData method
        Operations.AddDefaultData();

        //Calling the mainmenu method
        Operations.MainMenu();
    }
}