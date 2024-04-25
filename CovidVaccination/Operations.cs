using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    //Static Class
    public static class Operations
    {
        //Storing Current user
        static BeneficiaryDetails CurrentBeneficiary;
        //Beneficiary List
        public static List<BeneficiaryDetails> BeneficiaryList = new List<BeneficiaryDetails>();

        //Vaccine List

        public static List<VaccineDetails> VaccineList = new List<VaccineDetails>();

        //vaccination List

        public static List<VaccinationDetails> VaccinationList = new List<VaccinationDetails>();

        //Main Menu
        public static void MainMenu()
        {
            bool flag = true;
            //Enterance of MainMenu
            System.Console.WriteLine("\n\n*******************Welcome to the Vaccination Drive Application*******************");

            do
            {
                System.Console.WriteLine("MainMenu: \n1.Beneficiary Registration\n2.Login\n3.Get Vaccine Info\n4.Exit");

                //Asking the option from the user
                System.Console.Write("Enter the option from main menu: ");

                //stroing it to an variable
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    //Beneficiary Registration
                    case 1:
                        {
                            System.Console.WriteLine("****************Beneficiary Registration Section****************");
                            BeneficiaryRegistration();
                            break;
                        }

                    //Login
                    case 2:
                        {
                            System.Console.WriteLine("****************Login Section****************");
                            Login();
                            break;
                        }

                    //Get Vaccine Info            
                    case 3:
                        {
                            System.Console.WriteLine("****************Vaccine Info Section****************");
                            GetVaccineInfo();
                            break;
                        }

                    //Exit
                    case 4:
                        {
                            System.Console.WriteLine("************************* Thank You For using this application :) *************************");
                            flag = false;
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid Option :( ");
                            break;
                        }
                }

            } while (flag);
        }// Main Menu ends

        //Registration
        public static void BeneficiaryRegistration()
        {
            //Getting user details
            System.Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            System.Console.Write("Enter your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter your City: ");
            string city = Console.ReadLine();

            //Creating a object

            BeneficiaryDetails beneficiary = new BeneficiaryDetails(name, age, gender, mobileNumber, city);

            //Adding User details to the list
            BeneficiaryList.Add(beneficiary);

            System.Console.WriteLine($"Registration Succesfull :)\nYour Registration Number is: {beneficiary.RegistrationNumber}");

        }//Registration ends

        //Login
        public static void Login()
        {
            bool flag = true;

            //ask your registeration number
            System.Console.Write("Enter the registration Number: ");
            string registerationNumber = Console.ReadLine();

            //check the regitration is available in the list
            foreach (BeneficiaryDetails beneficiary in BeneficiaryList)
            {
                if (registerationNumber.Equals(beneficiary.RegistrationNumber))
                {

                    System.Console.WriteLine("You are Logged In Successfully :) ");
                    //stroing the logged in user details to current Beneficiery
                    CurrentBeneficiary = beneficiary;
                    flag = false;
                    SubMenu();
                    break;
                }
            }
            // wrong registration number
            if (flag)
            {
                System.Console.WriteLine("Invalid Registration number :( ");
            }

        }//Login ends

        //SubMenu
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                //Enterance of subemenu
                System.Console.WriteLine("*************SubMenu Section*************");
                System.Console.WriteLine("1.Show My Details \n2.Take Vaccination\n3.My Vaccination Histroy\n4.Next Due Date\n5.Exit");

                //Getting an option of submenu from user
                System.Console.Write("Enter the option SubMenu: ");
                int subOption = int.Parse(Console.ReadLine());

                //switching the option to the corresponding case

                switch (subOption)
                {
                    //Show My Details
                    case 1:
                        {
                            System.Console.WriteLine("****************My Details****************");
                            ShowMyDetails();
                            break;
                        }

                    //Take Vaccination
                    case 2:
                        {
                            System.Console.WriteLine("****************Take Vaccination****************");
                            TakeVaccination();
                            break;
                        }

                    //My Vaccination Histroy
                    case 3:
                        {
                            System.Console.WriteLine("****************My Vaccination Histroy****************");
                            MyVaccinationHistroy();
                            break;
                        }

                    //Next Due Date
                    case 4:
                        {
                            System.Console.WriteLine("****************Next Due Date****************");
                            NextDueDate();
                            break;
                        }

                    //Exit
                    case 5:
                        {
                            System.Console.WriteLine("****************You are redirected to the MainMenu****************");
                            flag = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("**************** Invalid Option :( ****************");
                            break;
                        }
                }
                //Iteration Until user select exit
            } while (flag);
        }//SubMenu ends

        //Show My Details
        public static void ShowMyDetails()
        {
            //Printing the current beneficiary details

            foreach (BeneficiaryDetails beneficiary in BeneficiaryList)
            {
                if (beneficiary.RegistrationNumber.Equals(CurrentBeneficiary.RegistrationNumber))
                {
                    System.Console.WriteLine($"Registration ID: {beneficiary.RegistrationNumber}\nName: {beneficiary.Name}\nAge: {beneficiary.Age}\nGender: {beneficiary.Gender}\nPhone Number: {beneficiary.MobileNumber}\nCity: {beneficiary.City}");
                    break;
                }
            }
        }//Show My Details ends

        //Take Vaccination
        public static void TakeVaccination()
        {
            //Show the list of vaccine
            GetVaccineInfo();

            //Ask the user to enter the vaccine ID
            System.Console.Write("Enter the vaccine ID from the vaccine list: ");
            string vaccineID = Console.ReadLine().ToUpper();

            //Check if it is valid
            bool flag = true;
            foreach (VaccineDetails vaccine in VaccineList)
            {
                if (vaccineID.Equals(vaccine.VaccineID))
                {
                    flag = false;
                    //Get the vaccination history details
                    foreach (VaccinationDetails vaccination in VaccinationList)
                    {
                        if (vaccination.RegistrationNumber.Equals(CurrentBeneficiary.RegistrationNumber))
                        {
                            if (vaccination.DoseNumber == 0)
                            {
                                //If no history check age  
                                if (CurrentBeneficiary.Age > 14)
                                {
                                    System.Console.WriteLine("You are vaccinated Successfully");
                                    vaccine.NoOfDoseAvailable--;
                                    //Update to the vaccination history 
                                    VaccinationDetails vaccinationNew = new VaccinationDetails(CurrentBeneficiary.RegistrationNumber, vaccine.VaccineID, vaccination.DoseNumber + 1, DateTime.Now);
                                    VaccinationList.Add(vaccinationNew);
                                    System.Console.WriteLine("Your vaccination ID is: " + vaccinationNew.VaccinationID);

                                }
                            }
                            else if (vaccination.DoseNumber > 0 && vaccination.DoseNumber < 3)
                            {
                                TimeSpan span = DateTime.Now - vaccination.VaccinatedDate;

                                //To check the same Vaccine
                                if (vaccination.VaccineID.Equals(vaccine.VaccineID))
                                {
                                    if (span.Days > 30)
                                    {
                                        if (vaccine.NoOfDoseAvailable > 0)
                                        {
                                            System.Console.WriteLine("You are vaccinated Successfully");

                                            //Deduct count from the vaccine count
                                            vaccine.NoOfDoseAvailable--;

                                            //Create the vaccination object
                                            VaccinationDetails vaccinationNew = new VaccinationDetails(CurrentBeneficiary.RegistrationNumber, vaccine.VaccineID, vaccination.DoseNumber + 1, DateTime.Now);

                                            //Store the details to the list
                                            VaccinationList.Add(vaccinationNew);
                                            System.Console.WriteLine("Your vaccination ID is: " + vaccinationNew.VaccinationID);
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Vaccine not available");
                                        }
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("You have wait for the completion of 30 days");
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("You are selected the wrong Vaccine");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                            }
                        }
                        break;
                    }






                    break;
                }
            }
            // wrong vaccine ID
            if (flag)
            {
                System.Console.WriteLine("Invalid Vaccine ID");
            }

        }//Take Vaccination ends

        //My Vaccination Histroy
        public static void MyVaccinationHistroy()
        {
            bool flag = true;

            //Trversing the vaccinationList 
            foreach (VaccinationDetails vaccination in VaccinationList)
            {
                //Checking the  vaccination registration number 
                if (vaccination.DoseNumber > 0 && vaccination.RegistrationNumber.Equals(CurrentBeneficiary.RegistrationNumber))
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                //Printing the vaccination details
                System.Console.WriteLine("VaccinationID\tRegistration Number\tVaccineID\tDoseNumber\tVaccinated Date");
                foreach (VaccinationDetails vaccination in VaccinationList)
                {
                    if (vaccination.DoseNumber > 0 && vaccination.RegistrationNumber.Equals(CurrentBeneficiary.RegistrationNumber))
                    {
                        System.Console.WriteLine($"{vaccination.VaccinationID}\t{vaccination.RegistrationNumber}\t{vaccination.VaccineID}\t{vaccination.DoseNumber}\t{vaccination.VaccinatedDate.ToString("dd/MM/yyyy")}");
                    }
                }

            }

            //Printing the if no history
            else
            {
                System.Console.WriteLine("You have No vaccination History");
            }
        }//My Vaccination Histroy ends

        //Next DueDate
        public static void NextDueDate()
        {
            int count = 0;
            DateTime date = new DateTime();
            //Traversing the vaccination List
            foreach (VaccinationDetails vaccination in VaccinationList)
            {
                //Checking the vaccination register number with the CurrentBeneficiary RegistrationNumber
                if (vaccination.RegistrationNumber.Equals(CurrentBeneficiary.RegistrationNumber))
                {
                    count++;
                    date = vaccination.VaccinatedDate;
                }
            }
            //Checking the dose number count 
            if (count > 0 && count < 3)
            {
                System.Console.WriteLine("Your next vaccination is " + date.AddDays(30).ToString("dd/MM/yyyy"));
            }
            else if (count == 3)
            {
                System.Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
            }
            else
            {
                System.Console.WriteLine("you can take vaccine now");
            }
        }//Next DueDate ends

        //GetVaccine Info
        public static void GetVaccineInfo()
        {

            bool flag = true;
            //To check the no ofdose is greater than zero
            foreach (VaccineDetails vaccine in VaccineList)
            {
                if (vaccine.NoOfDoseAvailable > 0)
                {
                    flag = false;
                    break;
                }

            }
            if (!flag)
            {
                System.Console.WriteLine("Vaccine ID\tVaccine Name\tNoOfDoseAvailable\t");
            }

            //Printing the Vaccine details
            foreach (VaccineDetails vaccine in VaccineList)
            {
                System.Console.WriteLine($"{vaccine.VaccineID}\t{vaccine.VaccineName}\t{vaccine.NoOfDoseAvailable}");
            }
        }//Get Vaccine Info ends


        //Adding Default Data
        public static void AddDefaultData()
        {
            //Default Details of Beneficiary List

            BeneficiaryDetails beneficiary1 = new BeneficiaryDetails("Ravichandran", 21, Gender.Male, 8484484, "Chennai");
            BeneficiaryDetails beneficiary2 = new BeneficiaryDetails("Baskaran", 22, Gender.Male, 8484747, "Chennai");

            BeneficiaryList.Add(beneficiary1);
            BeneficiaryList.Add(beneficiary2);

            //Default Details of Vaccine List

            VaccineDetails vaccine1 = new VaccineDetails(VaccineName.Covishield, 50);
            VaccineDetails vaccine2 = new VaccineDetails(VaccineName.Covaccine, 50);

            VaccineList.Add(vaccine1);
            VaccineList.Add(vaccine2);

            //Default Details of Vaccination List

            VaccinationDetails vaccination1 = new VaccinationDetails("BID1001", "CID2001", 1, new DateTime(2021, 11, 11));
            VaccinationDetails vaccination2 = new VaccinationDetails("BID1001", "CID2001", 2, new DateTime(2022, 03, 11));
            VaccinationDetails vaccination3 = new VaccinationDetails("BID1002", "CID2002", 2, new DateTime(2022, 04, 04));


            VaccinationList.Add(vaccination1);
            VaccinationList.Add(vaccination2);
            VaccinationList.Add(vaccination3);



            System.Console.WriteLine();


            System.Console.WriteLine();

            //Printing the default Vaccination details

            // foreach (VaccinationDetails vaccination in VaccinationList)
            // {
            //     System.Console.WriteLine($"Vaccination ID: {vaccination.VaccinationID}\nRegisteration Number: {vaccination.RegistrationNumber}\nVaccine ID: {vaccination.VaccineID}\nDose Number: {vaccination.DoseNumber}\nVaccinated Date: {vaccination.VaccinatedDate}");
            // }
        }
    }
}