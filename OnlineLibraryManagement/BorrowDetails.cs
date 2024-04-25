using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    //Enum
    public enum Status { Default, Borrowed, Returned }

    //Class
    public class BorrowDetails
    {
       
        //Field for BorrowId
        private static int s_borrowId = 2000;

        //propertie
        public string BorrowId { get; }

        public string BookID { get; set; }

        public string UserID { get; set; }

        public DateTime BorrowedDate { get; set; }

        public int BorrowBookCount { get; set; }

        public Status Status { get; set; }

        public int PaidFineAmount { get; set; }

        //Constructor

        public BorrowDetails(string bookID, string userID, DateTime borrowedDate, int borrowBookCount,Status status, int paidFineAmount)
        {
            s_borrowId++;
            BorrowId = "LB" + s_borrowId;
            BookID = bookID;
            UserID = userID;
            BorrowedDate = borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status = status;
            PaidFineAmount = paidFineAmount;
        }
    }
}