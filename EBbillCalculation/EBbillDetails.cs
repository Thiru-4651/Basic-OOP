using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBbillCalculation
{
    public class EBbillDetails
    {
        private static int s_meterID=1000;
        public string MeterID { get; }

        // private static int s_billID=1000;

        // public string BillID{ get;}


        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }
        public double Units { get; set; }

        public EBbillDetails(string userName,long phoneNumber,string mailID,double units)
        {
            // s_meterID++;
            s_meterID++;
            MeterID="EB"+s_meterID;
            UserName=userName;
            PhoneNumber=phoneNumber;
            MailID=mailID;
            Units=units;
        }
        public double CalculateAmount()
        {
            double amount=Units*5;
            return amount;
        }
    }
}