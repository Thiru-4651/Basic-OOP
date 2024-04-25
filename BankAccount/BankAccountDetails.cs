using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount
{
    public enum Gender{select,Male,Female}
    public class BankAccountDetails
    {
        private static int s_customerID=1000;
        public string CustomerId { get; }
        public string CustomerName { get; set; }

        public int Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public BankAccountDetails(string name,Gender gender,int balance,long phone,string mailid,DateTime dateofBirth)
        {
            s_customerID++;
            CustomerId="SF"+s_customerID;
            CustomerName=name;
            Gender=gender;
            Balance=balance;
            Phone=phone;
            MailId=mailid;
            DateOfBirth=dateofBirth;
        }
        //public static int balance=0;
        public int Deposit(int num)
        {
            Balance+=num;
            return Balance;
        }
        public int Withdraw(int num)
        {
            Balance-=num;
            return Balance;
        }
    }
}