// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace PayRollManagementSystem
// {
//     public enum Branch{Branch,Eymard,karuna,Madura}
//     public enum Team{Team,Network,Hardware,Developer,Facility}
//     public class PayrollManage
//     {
//         private static int  s_employeeID=3000;
//         public string EmployeeID { get; }
//         public string FullName { get; set; }
//         public DateTime DOB { get; set; }
//         public long MobileNumber { get; set; }
//         public string Gender { get; set; }
//         public Branch Branch { get; set; }
//         public Team Team { get; set; }

//         public PayrollManage(string fullName,DateTime dob,long mobileNumber,string gender,Branch branch,Team team)
//         {
//             s_employeeID++;
//             EmployeeID="SF"+s_employeeID;
//             FullName=fullName;
//             DOB=dob;
//             MobileNumber=mobileNumber;
//             Gender=gender;
//             Branch=branch;
//             Team=team;
//         }
//     }
// }