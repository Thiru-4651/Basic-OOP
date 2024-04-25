using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    //public  enum number{1,2,3}
    public class VaccinationDetails
    {
        //Field
        private static int s_vaccinationID=3000;

        //Properties
        public string VaccinationID { get;  }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate{ get; set; }

        //Constructor
        public VaccinationDetails(string registrationNumber,string vaccineID,int doseNumber,DateTime vaccinatedDate)
        {
            //Auto Increament
            s_vaccinationID++;
            VaccinationID="VID"+s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedDate;
        }

    }
}