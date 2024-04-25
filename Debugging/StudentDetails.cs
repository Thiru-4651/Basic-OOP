using System;
namespace Debugging
{
    //Enum
    public enum GenderEnum{Select,Male,Female,Transgender}
    public class StudentDetails
    {
        //Field
        //Static Field for Auto Generation of ID.
        private static int s_studentID = 3000;

        //Properties
        public string StudentID { get; }        //21
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; } 
        public GenderEnum Gender { get; set; }
        public int Physics { get; set; }        //5
        public int Chemistry { get; set; }
        public int Maths { get; set; }          //6

        //Constructor
        public StudentDetails(string studentName,string fatherName,DateTime dob,GenderEnum gender,int physics,int chemistry,int maths)
        {
            s_studentID++;                          //19
            StudentID = "SF" + s_studentID;  //20
            StudentName = studentName;       
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }

        //Method

        public double Average()
        {
            return (Physics+Chemistry+Maths)/3;
        }
        public bool CheckEligibility(double cutOff)
        {
            //double average = (double)(Physics + Chemistry + Maths)/3;       //27
            if(Average() >= cutOff)
            {
                return true;
            }
            return false;
        }
    }
}