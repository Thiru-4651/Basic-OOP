using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollManagementSystem
{
    public class AttendanceDetails
    {
        private static int s_attendaceID = 1000;

        public string AttendanceID { get; }

        public string EmployeeID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public DateTime Date { get; set; }

        public int HoursWorked { get; set; }

        public AttendanceDetails(string employeeID, DateTime date, DateTime checkIn, DateTime checkOut, int hoursWorked)
        {
            s_attendaceID++;
            AttendanceID = "AID" + s_attendaceID;
            EmployeeID = employeeID;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Date = date;
            HoursWorked = hoursWorked;
        }

        public void Salary()
        {
            
        }

        

    }
}