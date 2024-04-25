using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    //Enum
    public enum Gender{Select,Male,Female,Others}

    //Class
    public class BeneficiaryDetails
    {

        //Fields

        private static int s_registrationNumber=1000;

        //Properties

        public String RegistrationNumber { get;  } //Read-Only
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public string City { get; set; }

        //Constructor

        public BeneficiaryDetails(string name,int age,Gender gender,long mobileNumber,string city)
        {
            //Assiging Values to the Properties

            s_registrationNumber++;
            RegistrationNumber="BID"+s_registrationNumber;
            Name=name;
            Age=age;
            Gender=gender;
            MobileNumber=mobileNumber;
            City=city;
        }
   
    }
}