using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    public class DepartmentDetails
    {

        // Properties

        private static int s_departmentID=100;

        public string DepartmentID { get; }

        public string DepartmentName { get; set; }

        public int NumberOfSeats { get; set; }

        //Constructor

        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            //Auto Increament
            s_departmentID++;

            //Assiging values to the properties

            DepartmentID="DID"+s_departmentID;

            DepartmentName=departmentName;
            
            NumberOfSeats=numberOfSeats;
        }

         public DepartmentDetails(string newDepartmentDetails)
        {
            string [] values=newDepartmentDetails.Split(",");
            s_departmentID=int.Parse(values[0].Remove(0,3));

            DepartmentID=values[0];

            DepartmentName=values[1];
            
            NumberOfSeats=int.Parse(values[2]);
        }

    }
}