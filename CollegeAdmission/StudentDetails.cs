using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class StudentDetails
    {
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public long Phone { get; set; }
        public int Physics{ get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        public static int cutoff { get; set; }
    }

    /*static double cutoff()
    {
        
    }*/
}