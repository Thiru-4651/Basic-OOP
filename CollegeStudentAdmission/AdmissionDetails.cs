using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    public enum AdmissionStatus { Select, Admitted, Cancelled }

    public class AdmissionDetails
    {
        //         a.	AdmissionID – (Auto Increment ID - AID1001)
        // b.	StudentID
        // c.	DepartmentID
        // d.	AdmissionDate
        // e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)

        // Properties

        private static int s_admissionID = 1000;

        public string AdmissionID { get; }

        public string StudentID { get; set; }

        public string DepartmentID { get; set; }

        public DateTime AdmissionDate { get; set; }

        public AdmissionStatus AdmissionStatus { get; set; }

        //Constructor

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            //Auto Increament

            s_admissionID++;

            //Assiging values to the properties

            AdmissionID = "AID" + s_admissionID;

            StudentID = studentID;

            DepartmentID = departmentID;

            AdmissionDate = admissionDate;
            
            AdmissionStatus = admissionStatus;

        }

        public AdmissionDetails(string newAdmissionDetails)
        {
            string [] stringArray = newAdmissionDetails.Split(",");

            s_admissionID=int.Parse(stringArray[0].Remove(0,3));

            AdmissionID = stringArray[0];

            StudentID = stringArray[1];

            DepartmentID = stringArray[2];

            AdmissionDate = DateTime.ParseExact(stringArray[3],"dd/MM/yyyy",null);
            
            AdmissionStatus = Enum.Parse<AdmissionStatus>(stringArray[4]);

        }
    }
}