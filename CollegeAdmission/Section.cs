using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class Section : StudentDetails
    {
        public string WhichSection { get; set; }
        public int TotalStrength { get; set; }
    }
}