using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentPayrollManagement
{

    /// <summary>
    /// Enum WorkLocation used to create instance for Customer <see cref="WorkLocation"/>
    /// </summary>

    public enum WorkLocation { Select, Chennai, Bangalore, Coimbatore }

    /// <summary>
    /// Enum Gender used to create instance for customer <see cref="Gender"/>
    /// </summary>
    public enum Gender { Select, Male, Female }
    /// <summary>
    /// Class customerDetails used to create instance for customer <see cref="EmployeeDetails" />
    /// Refer documentation on <see href="www.syncfusion.com"/>
    /// </summary>
    public class EmployeeDetails
    {
        /// <summary>
        /// Static Field s_employeeID used to autoincreament EmployeeID of the instance of <see cref="EmployeeDteails"/>
        /// </summary>
        private static int s_employeeID = 1000;
        /// <summary>
        /// EmplyeeID property used to hold a employee's ID of instance of  <see cref="EmployeeDetails"/> 
        /// </summary>
        public string EmployeeID { get; }

        /// <summary>
        /// EmployeeName Property used to hold a employee Name of a instance of <see cref="EmployeeDetails"/>
        /// </summary>

        public string EmployeeName { get; set; }

        /// <summary>
        /// Role Property used to hold the Specific Role of the employee of a instance of <see cref="EmployeeDetails"/>
        /// </summary>

        public string Role { get; set; }

        /// <summary>
        /// WorkLocation Property used to hold the Working Location of the employee of a instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public WorkLocation WorkLocation { get; set; }

        /// <summary>
        /// Team Name Property used to hold the Employee Team Name of a instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// DateOfJoining Property used to hold the Joining Date of the employee of a instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public DateTime DateOfJoining { get; set; }

        /// <summary>
        /// NoOfWorkingDays Property used to hold the Working Days of the employee of a instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public double NoOfWorkingDays { get; set; }

        /// <summary>
        /// NoOfLeave Property used to hold the number of days leave taken of the employee of a instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public double NoOfLeave { get; set; }

        /// <summary>
        /// Gender Property used to hold the Gender of the employee of a instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Constructor EmployeeDetails used to initilize the parameter values to its Properties
        /// </summary>
        /// <param name="employeeName">employeeName parameter used to assign its value to assocaited Property</param>
        /// <param name="role">role parameter used to assign its value to assocaited Property</param>
        /// <param name="workLocation">workLocation parameter used to assign its value to assocaited Property</param>
        /// <param name="teamName">teamName parameter used to assign its value to assocaited Property</param>
        /// <param name="dateOfJoining">dateOfJoining parameter used to assign its value to assocaited Property</param>
        /// <param name="noOfWorkingDays">noOfWorkingDays parameter used to assign its value to assocaited Property</param>
        /// <param name="noOfLeave">noOfLeave parameter used to assign its value to assocaited Property</param>
        /// <param name="gender">gender parameter used to assign its value to assocaited Property</param> 


        public EmployeeDetails(string employeeName, string role, WorkLocation workLocation, string teamName, DateTime dateOfJoining, double noOfWorkingDays, double noOfLeave, Gender gender)
        {
            s_employeeID++;
            EmployeeID = "SF" + s_employeeID;
            EmployeeName = employeeName;
            Role = role;
            WorkLocation = workLocation;
            TeamName = teamName;
            DateOfJoining = dateOfJoining;
            NoOfWorkingDays = noOfWorkingDays;
            NoOfLeave = noOfLeave;
            Gender = gender;
        }

        /// <summary>
        /// Method SalaryCalculation used to calculate Salary of the employee base on the total days employee worked of instance of <see cref="EmployeeDetails"/> 
        /// </summary>
        /// <returns>Returns the salary </returns> 
        public double SalaryCalculation()
        {

            double totalDays = NoOfWorkingDays - NoOfLeave;
            double salary = totalDays * 500;
            return salary;
        }
    }
}