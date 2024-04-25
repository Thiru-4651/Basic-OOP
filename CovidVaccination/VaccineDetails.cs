using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    //Enum
    public enum VaccineName{VaccineName,Covishield,Covaccine}

    public class VaccineDetails
    {
        //Field
        private static int s_vaccineID=2000;
        
        //Properties
        public string VaccineID { get; }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        //Constructor
        public VaccineDetails(VaccineName vaccineName,int noOfDoseAvailable)
        {
            //AutoIncreament
            s_vaccineID++;
            VaccineID="CID"+s_vaccineID;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }

    }
}