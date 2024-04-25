using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public static class Operations
    {
        //Creation of CustomList
        static CustomList<UserDetails> UserCustomList = new CustomList<UserDetails>();

        static CustomList<BookDetails> BookCustomList = new CustomList<BookDetails>();

        static CustomList<BorrowDetails> BorrowCustomList = new CustomList<BorrowDetails>();

        //Current User
        static UserDetails CurrentUser;

        //MainMenu
        public static void MainMenu()
        {
            System.Console.WriteLine("************************ Welcome to the SYNCFUSION LIBRARY ************************");
            bool flag = true;
            do
            {
                //Mainmenu enterance
                System.Console.WriteLine("MainMenu:\n1.User Registration\n2.User Login\n3.Exit");

                //Getting the input from the user
                System.Console.Write("Enter the option from the MainMenu: ");
                int mainOption = int.Parse(Console.ReadLine());

                //Switch the input to correspondent case\
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("**************** User Registration ****************");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("**************** User Login ****************");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("**************** Thank you for using our apllication...Have a nice Day :)  ****************");
                            flag = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("**************** Invalid Option :( ****************");
                            break;
                        }
                }
                //Itertion until user select Ext
            } while (flag);

        }//MainMenu ends

        //User registration
        public static void UserRegistration()
        {
            //getting the user details

            System.Console.Write("Enter the Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter your Department: ");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);

            System.Console.Write("Enter the Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter the Email ID: ");
            string emailID = Console.ReadLine();

            System.Console.Write("Enter the Wallet Balance: ");
            int walletBalance = int.Parse(Console.ReadLine());

            //creating an object
            UserDetails user = new UserDetails(name, gender, department, mobileNumber, emailID, walletBalance);

            //Adding details to the CustomList
            UserCustomList.Add(user);

            //Showing the user ID 
            System.Console.WriteLine($"**********************Registration Succesful**********************\nYour User ID: {user.UserID}\n");

        }//User registration ends

        //User Login
        public static void UserLogin()
        {
            //Getting the user ID
            System.Console.Write("Enter your UserID: ");
            string getUserID = Console.ReadLine().ToLower();

            bool flag = true;

            //Chcek the userid in the user CustomList
            foreach (UserDetails user in UserCustomList)
            {
                if (getUserID.Equals(user.UserID.ToLower()))
                {
                    flag = false;
                    System.Console.WriteLine("Logged in successfully :) ");
                    CurrentUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid User ID. Please enter a valid one :(");
            }
        }//User Login Ends

        //SubMenu starts
        public static void SubMenu()
        {
            bool isSub = true;
            do
            {
                //Submenu Enterance
                System.Console.WriteLine("SubMenu:\n1.Borrow Books\n2.Show Borrowed History\n3.Return Books\n4.Wallet Recharge\n5.Exit");

                //getting the input from the submenu
                System.Console.Write("Enter the option from the SubMenu: ");
                int subOption = int.Parse(Console.ReadLine());

                //Swich the option to the correspondent case
                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("****************** Borrow Books ******************");
                            BorrowBooks();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("****************** Show Borrowed History ******************");
                            ShowBorrewedHistory();
                            break;
                        }

                    case 3:
                        {
                            System.Console.WriteLine("****************** Return Books ******************");
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("****************** Wallet Recharge ******************");
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("****************** You are redirected to MainMenu ******************");
                            isSub = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("****************** Invalid Option :( ******************");
                            break;
                        }
                }
                //Iterate until user select exit
            } while (isSub);

        }//Submenu ends

        //BorrowBook Starts
        public static void BorrowBooks()
        {
            //Printing book details
            foreach (BookDetails book in BookCustomList)
            {
                System.Console.WriteLine($"{book.BookID}\t\t{book.BookName}\t{book.AuthorName}\t\t{book.BookCount}");
            }

            //Ask the user to enter the book ID
            System.Console.Write("Enter the Book ID to Borrow: ");
            string bookID = Console.ReadLine().ToLower();

            //Check the user entered book Id is valid or not
            bool isTrue = true;
            foreach (BookDetails book in BookCustomList)
            {
                if (bookID.Equals(book.BookID.ToLower()))
                {
                    isTrue = false;

                    //ask the user to enter the count of the book
                    System.Console.Write("Enter the count of the book: ");
                    int count = int.Parse(Console.ReadLine());

                    //Check the book availabilty with the book count
                    if (count <= book.BookCount)
                    {
                        //Checking the count of the user borrewed books
                        int currentUserBookRequestCount = 0;
                        foreach (BorrowDetails borrewed in BorrowCustomList)
                        {

                            //Checking the bought book count 
                            if (borrewed.BorrowBookCount <= 3 || borrewed.BorrowBookCount == 0)
                            {
                                //Creating object
                                BorrowDetails borrowNew = new BorrowDetails(book.BookID, CurrentUser.UserID, DateTime.Now, count, Status.Borrowed, 0);
                                BorrowCustomList.Add(borrowNew);

                                //Reducing the book count
                                book.BookCount -= count;

                                //Adding the book borrowed count
                                borrewed.BorrowBookCount += count;

                                System.Console.WriteLine("Book Borrowed Succesfully :) ");
                            }
                            else
                            {
                                //Adding the book request count
                                currentUserBookRequestCount++;
                                if (currentUserBookRequestCount > 3)
                                {
                                    System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {borrewed.BorrowBookCount} and requested count is {currentUserBookRequestCount}, which exceeds 3 ");
                                    break;
                                }
                                System.Console.WriteLine("You are alreay bought 3 books");

                            }
                            break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Books are not available for the selected count");

                        //For getting the borrewed date
                        foreach (BorrowDetails borrewed in BorrowCustomList)
                        {
                            if (book.BookID.Equals(borrewed.BookID))
                            {
                                DateTime borrewedDate = borrewed.BorrowedDate;
                                
                                //Printing the next available date of the book
                                System.Console.WriteLine($"The book will be available on {borrewedDate.AddDays(15).ToString("dd/MM/yyyy")}");
                                break;
                            }
                        }
                    }

                    break;
                }
            }
            if (isTrue)
            {
                //for not valid book id
                System.Console.WriteLine("Invalid Book ID, Please enter valid ID");
            }
        }//BorrowBook ends

        //ShowBorrewedHistory Starts
        public static void ShowBorrewedHistory()
        {
            bool flag = true;
            //Traversing the user ID to check if they alreaady boorrowed or not
            System.Console.WriteLine("BorrowID\tBookID\t\tUserID\t\tBorrowedDate\t\tBorrowBookCount\t\tStatus\t\tPaidFineAmount");

            foreach (BorrowDetails borrewed in BorrowCustomList)
            {
                //Checking the current user ID with the borrewed
                if (CurrentUser.UserID.Equals(borrewed.UserID))
                {
                    flag = false;
                    System.Console.WriteLine($"{borrewed.BorrowId}\t\t{borrewed.BookID}\t\t{borrewed.UserID}\t\t{borrewed.BorrowedDate.ToString("dd/MM/yyyy")}\t\t{borrewed.BorrowBookCount}\t\t{borrewed.Status}\t\t{borrewed.PaidFineAmount}");

                }

            }
            if (flag)
            {
                System.Console.WriteLine("You had nothing Borrwed :(");
            }
        }//ShowBorrewedHistory ends

        //ReturnBooks Starts
        public static void ReturnBooks()
        {
            bool flag = true;

            //For printing the table fromat

            System.Console.WriteLine("BorrowID\tBookID\t\tUserID\t\tBorrowedDate\t\tBorrowBookCount\t\tStatus\t\tPaidFineAmount\t\tReturn Date");
            foreach (BorrowDetails borrewed in BorrowCustomList)
            {
                if (CurrentUser.UserID.Equals(borrewed.UserID))
                {
                    if (borrewed.Status == Status.Borrowed)
                    {
                        
                        System.Console.WriteLine($"{borrewed.BorrowId}\t\t{borrewed.BookID}\t\t{borrewed.UserID}\t\t{borrewed.BorrowedDate.ToString("dd/MM/yyyy")}\t\t{borrewed.BorrowBookCount}\t\t\t{borrewed.Status}\t\t{borrewed.PaidFineAmount}\t\t{borrewed.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy")}");
                    }
                }
            }
            foreach (BorrowDetails borrewed in BorrowCustomList)
            {
                if (CurrentUser.UserID.Equals(borrewed.UserID))
                {
                    if (borrewed.Status == Status.Borrowed)
                    {
                        DateTime returnDate=DateTime.Now;
                        
                        TimeSpan calculateDate=returnDate-borrewed.BorrowedDate;
                        int delayDays=(int)calculateDate.TotalDays;
                        int fineAmount=0;

                        if(delayDays>15)
                        {
                            fineAmount=(delayDays-15)*1;
                        }

                        foreach (BorrowDetails borrow in BorrowCustomList)
                        {
                            if(CurrentUser.UserID.Equals(borrow.UserID) && borrow.Status.Equals(Status.Borrowed))
                            {
                                System.Console.Write("Enter the returning Book ID: ");
                                string returnBook=Console.ReadLine().ToUpper();
                                if(delayDays>15)
                                {
                                    if(CurrentUser.WalletBalance>=borrow.PaidFineAmount)
                                    {
                                        CurrentUser.DeductBalance(fineAmount);
                                        borrow.Status=Status.Returned;
                                        borrow.PaidFineAmount+=fineAmount;
                                        System.Console.WriteLine("Book Returned Successfully");
                                        foreach (BookDetails book in BookCustomList)
                                        {
                                            if(borrow.BookID.Equals(book.BookID))
                                            {
                                                book.BookCount+=borrow.BorrowBookCount;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Recharge your wallet and then continue");
                                        break;
                                    }
                                }
                                else
                                {
                                    borrow.Status=Status.Returned;
                                    System.Console.WriteLine("Book Returned successfully");
                                    break;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Invalid Book ID");
                                break;
                            }
                        }

                    }
                    break;
                }

            }
            //For prinitng the new user
            if (flag)
            {
                System.Console.WriteLine("You have nothing to return");
            }
        }//ReturnBooks ends

        //WalletRecharge Starts
        public static void WalletRecharge()
        {
            //Check the user wants to continue
            System.Console.Write("Do You want to Recharge your wallet (Yes/No): ");
            string option = Console.ReadLine().ToLower();

            if (option.Equals("yes"))
            {
                //Ask the amount to be recharged
                System.Console.Write("Enter the amount to recharged: ");
                int cash = int.Parse(Console.ReadLine());

                //Calling the method from the user details class
                int updatedWalletBalance = CurrentUser.WalletRecharge(cash);

                //Showing the current balance
                System.Console.WriteLine($"Your current balance is: {updatedWalletBalance}");

            }
            else
            {
                System.Console.WriteLine("You Redirected to the SubMenu");
            }
        }//WalletRecharge ends

        //Method for adding default datas
        public static void AddingDefaultDatas()
        {
            //Adding default user Details
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, 9938388333, "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, 9944444455, "priya@gmail.com", 150);

            UserCustomList.Add(user1);
            UserCustomList.Add(user2);

            //Adding default Book Details
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);

            BookCustomList.Add(book1);
            BookCustomList.Add(book2);
            BookCustomList.Add(book3);
            BookCustomList.Add(book4);
            BookCustomList.Add(book5);

            //Adding default Borrow Details

            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);

            BorrowCustomList.Add(borrow1);
            BorrowCustomList.Add(borrow2);
            BorrowCustomList.Add(borrow3);
            BorrowCustomList.Add(borrow4);
            BorrowCustomList.Add(borrow5);

            //Printing user details
            // foreach (UserDetails user in UserCustomList)
            // {
            //     System.Console.WriteLine($"{user.UserID}\t{user.UserName}\t{user.Gender}\t{user.Department}\t{user.MobileNumber}\t{user.MailID}\t{user.WalletBalance}");
            // }



            // //Printing borrow details
            // foreach (BorrowDetails borrow in BorrowCustomList)
            // {
            // }









        }
    }
}