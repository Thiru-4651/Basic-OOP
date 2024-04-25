using System;
using System.IO;
using System.Collections.Generic;
namespace CollegeStudentAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            //Creating the collegestudent admission folder
            if (!Directory.Exists("CollegeStudentAdmission"))
            {
                System.Console.WriteLine("Creating folder");
                Directory.CreateDirectory("CollegeStudentAdmission");
            }

            //Creating the student details file
            if (!File.Exists("CollegeStudentAdmission/StudentDetails.csv"))
            {
                System.Console.WriteLine("Creating file");
                File.Create("CollegeStudentAdmission/StudentDetails.csv").Close();
            }

            //Creating the department details file
            if (!File.Exists("CollegeStudentAdmission/DepartmentDetails.csv"))
            {
                System.Console.WriteLine("Creating file");
                File.Create("CollegeStudentAdmission/DepartmentDetails.csv").Close();
            }

            //Creating the admission details file
            if (!File.Exists("CollegeStudentAdmission/AdmissionDetails.csv"))
            {
                System.Console.WriteLine("Creating file");
                File.Create("CollegeStudentAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {

            //Writing the student details to the file

            string[] students = new string[Operations.StudentList.Count];
            for (int i = 0; i < Operations.StudentList.Count; i++)
            {
                students[i] = Operations.StudentList[i].StudentID + "," + Operations.StudentList[i].StudentName + "," + Operations.StudentList[i].FatherName + "," + Operations.StudentList[i].Gender + "," + Operations.StudentList[i].DOB.ToString("dd/MM/yyyy") + "," + Operations.StudentList[i].Physics + "," + Operations.StudentList[i].Chemistry + "," + Operations.StudentList[i].Maths;
            }
            File.WriteAllLines("CollegeStudentAdmission/StudentDetails.csv", students);


            //Writing the department details to the file

            string[] departments = new string[Operations.DepartmentList.Count];
            for (int i = 0; i < Operations.DepartmentList.Count; i++)
            {
                departments[i] = Operations.DepartmentList[i].DepartmentID + "," + Operations.DepartmentList[i].DepartmentName + "," + Operations.DepartmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("CollegeStudentAdmission/DepartmentDetails.csv", departments);


            //Writing the Admission details to the file

            string [] admissions=new string[Operations.AdmissionList.Count];
            for(int i=0;i<Operations.AdmissionList.Count;i++)
            {
                admissions[i]=Operations.AdmissionList[i].AdmissionID+","+Operations.AdmissionList[i].StudentID+","+Operations.AdmissionList[i].DepartmentID+","+Operations.AdmissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.AdmissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("CollegeStudentAdmission/AdmissionDetails.csv",admissions);

        }

        public static void ReadFromCSV()
        {
            //Reading the studentdetails files
            
            string[] students=File.ReadAllLines("CollegeStudentAdmission/StudentDetails.csv");

            foreach(string student in students )
            {
                StudentDetails newStudent=new StudentDetails(student);
                Operations.StudentList.Add(newStudent);
            }

            //Reading the Department details files

            string [] department=File.ReadAllLines("CollegeStudentAdmission/DepartmentDetails.csv");

            foreach (string deparment1 in department)
            {
                DepartmentDetails newDepartmentDetails=new DepartmentDetails(deparment1);
                Operations.DepartmentList.Add(newDepartmentDetails);
            }

            //Reading the Admission details files

            string [] admissionArray=File.ReadAllLines("CollegeStudentAdmission/AdmissionDetails.csv");

            foreach (string admission in admissionArray)
            {
                AdmissionDetails newAdmissionDetails=new AdmissionDetails(admission);
                Operations.AdmissionList.Add(newAdmissionDetails);
            }
        }
    }
}