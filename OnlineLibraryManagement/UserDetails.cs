using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    //Enum

    public enum Department { Department, ECE, EEE, CSE }

    public enum Gender { Select, Male, Female, Transgender }

    //Class
    public class UserDetails
    {

        //Field for userID
        private static int s_userId = 3000;

        //Properties
        public string UserID { get; } //Because it's read only property

        public string UserName { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        public long MobileNumber { get; set; }

        public string MailID { get; set; }

        public int WalletBalance { get; set; }

        //Constructors

        public UserDetails(string userName, Gender gender, Department department, long mobileNumber, string mailID, int walletBalance)
        {
            s_userId++;
            UserID = "SF" + s_userId;
            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailID = mailID;
            WalletBalance = walletBalance;
        }

        //Methods

        public int WalletRecharge(int amount)
        {
            WalletBalance += amount;
            return WalletBalance;
        }

        public int DeductBalance(int amount)
        {
            WalletBalance -= amount;
            return WalletBalance;
        }
    }

}