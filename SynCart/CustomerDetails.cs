using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    /// <summary>
    /// This class use to perform the customer details
    /// </summary> 
    public class CustomerDetails
    {
        /// <summary>
        /// Auto Incrament values cref=customerDetails
        /// </summary>
        private static int s_customerID = 1000;

        /// <summary>
        /// Property for CustomerID
        /// </summary>
        /// <value></value>
        public string CustomerID { get; }
        /// <summary>
        /// Property for Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property for City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Property for MobileNumber
        /// </summary>
        public long MobileNumber { get; set; }
        /// <summary>
        /// Property for WalletBalance
        /// </summary>
        public int WalletBalance { get; set; }
        /// <summary>
        /// Property for MailID
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// Constructor for assinging values to the propertites 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="walletBalance"></param>
        /// <param name="emailID"></param>
        public CustomerDetails(string name, string city, long mobileNumber, int walletBalance, string emailID)
        {
            s_customerID++;
            CustomerID = "CID" + s_customerID;
            Name = name;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailID = emailID;
        }

        /// <summary>
        /// Method for WalletRecharge
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AfterWalletRecharge(int num)
        {
            int final = WalletBalance + num;
            return final;
        }

        /// <summary>
        /// Method for Deducting the wallet Balance
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public void DeductBalance(int cash)
        {
            WalletBalance -= cash;
            // return updatedwallet;
        }
    }
}