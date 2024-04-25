using System;
namespace CollegeStudentAdmission;
public class Program
{
    public static void Main(string[] args)
    {
        //File Handling create method
        FileHandling.Create();

        //Calling Default Data method
        //Operations.AddingDefaultData();

        //Calling ReadFrom CSV method
        FileHandling.ReadFromCSV();

        //Calling MainMenu method 
        Operations.MainMenu();

        //Calling the WriteToCsv method
        FileHandling.WriteToCSV();
    }
}