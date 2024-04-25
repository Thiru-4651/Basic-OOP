using System;
using System.Collections.Generic;
namespace CollegeAdmission;

class Program
{
    public static void Main(string[] args)
    {
        /*List<StudentDetails>studentList=new List<StudentDetails>();

        string option="";
        do{
        StudentDetails student=new StudentDetails();
        
        System.Console.Write("Name: ");
        student.StudentName=Console.ReadLine();

        System.Console.Write("Enter your father name: ");
        student.FatherName=Console.ReadLine();

        System.Console.Write("Gender: ");
        student.Gender=Console.ReadLine();

        System.Console.Write("Enter your dob (dd/MM/yyyy): ");
        student.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        
        System.Console.Write("Phone Number: ");
        student.Phone=long.Parse(Console.ReadLine());

        System.Console.Write("Physics mark: ");
        student.Physics=int.Parse(Console.ReadLine());

        System.Console.Write("Chemistry mark: ");
        student.Chemistry=int.Parse(Console.ReadLine());

        System.Console.Write("Maths mark: ");
        student.Maths=int.Parse(Console.ReadLine());

       // int avg=ma
        //student1.cutoff=cutOff(75);

        studentList.Add(student);

        System.Console.Write("Do you continue yes/no: ");
        option=Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        }while(option=="yes");



        foreach (StudentDetails student9 in studentList)
        {
        System.Console.WriteLine("Name: "+student9.StudentName+"\nFather Name: "+student9.FatherName+"\nGender: "+student9.Gender+"\nDateOfBirth: "+student9.DOB.ToString("dd/MM/yyyy"));
        System.Console.WriteLine("Phone: "+student9.Phone+"\nPhysics: "+student9.Physics+"\nChemistry: "+student9.Chemistry+"\nMaths: "+student9.Maths);
        Console.WriteLine();
        }*/

        StudentDetails student=new StudentDetails();

        System.Console.Write("Name: ");
        student.StudentName=Console.ReadLine();

        Section student1=new Section();
        student1.WhichSection="a";
        student1.TotalStrength=50;
        System.Console.WriteLine(student1.StudentName);

    }
    
}