using System;
using System.Collections.Generic;
using System.Threading;
namespace SynCart;
class Program
{
    //Global Object for storing the current Customer details
    static CustomerDetails CurrentCustomer;

    //List for stroing the customer details
    public static List<CustomerDetails> CustomerList = new List<CustomerDetails>();

    //List for stroing the order details
    public static List<OrderDetails> OrderList = new List<OrderDetails>();

    //List for stroing the product details
    public static List<ProductDetails> ProductList = new List<ProductDetails>();

    public static void Main(string[] args)
    {
        bool isTrue = true;
        int count1 = 0;
        do
        {
            //For adding the default data
            AddingDefaultDetails();

            int choice;
            //For first time entry
            if (count1 == 0)
            {
                //Mainmenu entrance
                System.Console.WriteLine("\n\n--------------Welcome to Application----------------- \n\nMAINMENU:\n\n1.Customer Registration        2.Login        3.Exit");
                System.Console.WriteLine();
                System.Console.Write("Enter the option from MAINMENU: ");
                //count1=0;
                choice = int.Parse(Console.ReadLine());
            }
            //For more than one time entry

            else
            {
                System.Console.WriteLine("\nMAINMENU:\n\n1.Customer Registration        2.Login        3.Exit");
                System.Console.Write("\nRe-enter the option from MAINMENU: ");
                count1 = 0;
                choice = int.Parse(Console.ReadLine());
            }

            //Switching the choice
            switch (choice)
            {
                //Registration Process
                case 1:
                    {
                        Registration();
                        break;
                    }

                //Login process
                case 2:
                    {
                        Login();
                        break;
                    }

                //Exit process
                case 3:
                    {
                        isTrue = false;
                        System.Console.WriteLine("\nThank you for Reaching US\n\n--------------Have A Nice Day--------------\n\n");
                        break;
                    }

                //For invalid input
                default:
                    {
                        System.Console.WriteLine("\nInvalid Input :( ");
                        count1 = 1;
                        break;
                    }
            }

            //Iterating until user select exit
        } while (isTrue);
    }

    public static void AddingDefaultDetails()
    {
        //Adding default values for the customer details

        CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");

        CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");

        CustomerList.Add(customer1);
        CustomerList.Add(customer2);

        //Adding default values for the order details

        OrderDetails order1 = new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Ordered);

        OrderDetails order2 = new OrderDetails("CID1002", "PID103", 40000, DateTime.Now, 2, OrderStatus.Ordered);

        OrderList.Add(order1);
        OrderList.Add(order2);

        //Adding default values for the product details


        ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10000, 10, 3);

        ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 15000, 5, 2);

        ProductDetails product3 = new ProductDetails("Camara (Sony)", 20000, 3, 4);

        ProductDetails product4 = new ProductDetails("iPhone", 50000, 5, 6);

        ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 40000, 3, 3);

        ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 1000, 5, 2);

        ProductDetails product7 = new ProductDetails("Speakers (Boat)", 500, 4, 2);

        ProductList.Add(product1);

        ProductList.Add(product2);

        ProductList.Add(product3);

        ProductList.Add(product4);

        ProductList.Add(product5);

        ProductList.Add(product6);

        ProductList.Add(product7);

    }
    //Registration method
    public static void Registration()
    {
        //Getting the user details
        System.Console.Write("Name: ");
        string name = Console.ReadLine();

        System.Console.Write("City: ");
        string city = Console.ReadLine();

        System.Console.Write("Mobile Number: ");
        long phone = long.Parse(Console.ReadLine());

        System.Console.Write("Wallet Balance: ");
        int walletBalance = int.Parse(Console.ReadLine());

        System.Console.Write("Email ID: ");
        string emailID = Console.ReadLine();

        //Creating the new customer object
        CustomerDetails customer = new CustomerDetails(name, city, phone, walletBalance, emailID);

        //Adding the customer details to the list
        CustomerList.Add(customer);

        //Showing the customerID to the user
        System.Console.WriteLine("You are successfully Registered! \n");
        System.Console.WriteLine("Your customer ID is: " + customer.CustomerID);
        System.Console.WriteLine("\nYou are going to be redirected to the MainMenu");

    }

    //Login method
    public static void Login()
    {
        int increament = 0;
        string temp = "";
        do
        {

            //For the first attempt

            if (increament == 0)
            {
                System.Console.Write("Enter your Customer ID: ");
                temp = Console.ReadLine();
            }

            //For more than one attempt

            else
            {
                System.Console.Write("\nRe-Enter the Employee ID: ");
                temp = Console.ReadLine();
            }

            //Checking the customer ID
            foreach (CustomerDetails customer in CustomerList)
            {
                if (temp == customer.CustomerID)
                {
                    System.Console.WriteLine("\nYou are successfully Logged In :) ");
                    CurrentCustomer = customer;
                    increament = 0;

                    //Submenu Process

                    Submenu();

                    break;
                }
                else
                {
                    increament = 1;
                }
            }
            //For invalid customerID
            if (!(increament == 0))
            {
                System.Console.WriteLine("\nInvalid Customer ID :( ");
            }
            //Iterating until user enters the customerID
        } while (!(increament == 0));
    }

    //Submenu Process
    public static void Submenu()
    {
        bool flag = true;
        do
        {
            //Submenu process
            System.Console.WriteLine("\nSUBMENU:\n\ta.Purchase\n\tb.Order History\n\tc.Cancel Order\n\td.Wallet Balance\n\te.Wallet Recharge\n\tf.Exit");
            System.Console.Write("Enter the option from SUBMENU: ");

            //getting the input from the user  
            char option = char.Parse(Console.ReadLine());

            //Switching the option to the correspoding the case
            switch (option)
            {
                case 'a':
                    {

                        Purchase();
                        break;
                    }

                case 'b':
                    {
                        OrderHistory();
                        break;
                    }

                case 'c':
                    {
                        CancelOrder();
                        break;
                    }

                case 'd':
                    {
                        WalletBalance();
                        break;
                    }

                case 'e':
                    {
                        WalletRecharge();
                        break;
                    }

                case 'f':
                    {
                        //Exit process
                        flag = false;
                        System.Console.WriteLine("You are redirected to the MAINMENU ");
                        break;
                    }

                default:
                    {
                        //For invalid option
                        System.Console.WriteLine("Invalid OPtion :( \n");
                        break;
                    }
            }
            //Iterating until user select exit
        } while (flag);
    }

    //Purchase method
    public static void Purchase()
    {
        int total = 0;

        //Showing the product details to the user
        foreach (ProductDetails product in ProductList)
        {
            System.Console.WriteLine("Product ID: " + product.ProductID + "\t" + "Product Name: " + product.ProductName + "\tPrice Per Quantity: " + product.Price + "\tAvailable Stock Quantity: " + product.Stock + "\tShipping Duration: " + product.ShippingDuration);
        }

        //Getting the productID from the user
        System.Console.Write("Enter the product ID to buy: ");
        string choose = Console.ReadLine();

        int deliverycharge = 50;
        bool flag = true;

        //Checing the product ID
        foreach (ProductDetails product in ProductList)
        {
            if (choose.Equals(product.ProductID))
            {
                flag = false;

                //Getting the count of the product
                System.Console.Write("The count of your selected product: ");
                int count = int.Parse(Console.ReadLine());

                //Checking the count with the stock
                if (count < product.Stock)
                {
                    //Calculating the total price
                    total = count * product.Price + deliverycharge;

                    //Checking the if user has enough balance
                    if (total > CurrentCustomer.WalletBalance)
                    {
                        System.Console.WriteLine("Insufficient wallet Balance.Please recharge your wallet and do purchase again");
                    }

                    else
                    {
                        //Deducting the total price from the user balance
                        CurrentCustomer.DeductBalance(total);

                        //Creating the new order object
                        OrderDetails order1 = new OrderDetails(CurrentCustomer.CustomerID, product.ProductID, total, DateTime.Now, count, OrderStatus.Ordered);

                        //Adding the order details to the list
                        OrderList.Add(order1);

                        //Showing the orderID with delivery date to the customer
                        System.Console.WriteLine("\nOrder Placed Successfully. Order ID is: " + order1.OrderID);
                        System.Console.WriteLine("\nYour order will be delivered on: " + DateTime.Now.AddDays(product.ShippingDuration).ToString("dd/MM/yyyy"));

                        //Reducing the stock count 
                        product.Stock -= count;
                    }

                }

                //For count was greter than the stock
                else
                {
                    System.Console.WriteLine("Required count not available. Current availability is: " + product.Stock);
                }
            }
        }

        //For invalid product ID
        if (flag)
        {
            System.Console.WriteLine("\nInvalid Product ID :( ");
            System.Console.WriteLine("You are redirected to the SUBMENU");
        }
    }

    //OrderHistory Method
    public static void OrderHistory()
    {
        //Traversing the orderList 
        foreach (OrderDetails order in OrderList)
        {
            //Checing the order list with the current customerID
            if (CurrentCustomer.CustomerID.Equals(order.CustomerID))
            {
                //Printing the details
                System.Console.WriteLine($"Order ID : {order.OrderID}\tCustomer ID : {order.CustomerID}\tProductID : {order.ProductID}\tTotalPrice : {order.Price}\tPurchase Date : {order.PurchaseDate.ToString("dd/MM/yyyy")}\tQuantity Purchased : {order.Quantity}\tOrder Status : {order.OrderStatus}");
            }
        }

    }

    //CancelOrder method
    public static void CancelOrder()
    {
        bool flag = true;

        //Traversing teh orderLIst
        foreach (OrderDetails order in OrderList)
        {
            //Checking the orderlist with the order status ordered
            if (order.CustomerID.Equals(CurrentCustomer.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
            {
                flag = false;
                System.Console.WriteLine($"OrderID: {order.OrderID}\tCustomerID: {order.CustomerID}\tProductID: {order.ProductID}\tTotalPrice: {order.Price}\tPurchaseDate: {order.PurchaseDate}\tOrderQuantity:{order.Quantity}\tOrderStatus: {order.OrderStatus}");
            }
        }

        //if yes 
        if (!flag)
        {
            //Getting the orderID
            System.Console.WriteLine("Enter the orderID to cancel ");
            string userEnteredOrderID = Console.ReadLine().ToUpper();

            //Cheking the orderlist with the user entered orderID
            foreach (OrderDetails order in OrderList)
            {
                if (userEnteredOrderID.Equals(order.OrderID) && order.CustomerID.Equals(CurrentCustomer.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))

                {
                    //If product ID prsent
                    foreach (ProductDetails product in ProductList)
                    {
                        if (product.ProductID.Equals(order.ProductID))
                        {
                            //Incrasing the stock count
                            product.Stock += order.Quantity;

                            //Returning the amount to the user 
                            CurrentCustomer.AfterWalletRecharge(order.Price);

                            //Changing the orderstatus to canceled
                            order.OrderStatus = OrderStatus.Cancelled;
                            System.Console.WriteLine("Order cancelled successfully");
                        }
                    }
                }
            }
        }

        //If user have no orders
        else
        {
            System.Console.WriteLine("You have no orders to cancel");
        }
    }

    //Wallet balance showing method
    public static void WalletBalance()
    {
        System.Console.Write("your Current Wallet Balance is: " + CurrentCustomer.WalletBalance);
    }

    //Wallet recharge method
    public static void WalletRecharge()
    {
        //Confirming the user for the wallet Recharge
        System.Console.Write("Do you want Recharge your wallet (yes/no): ");
        string option = Console.ReadLine().ToLower();
        if (option.Equals("yes"))
        {

            //Getting the cash from the user
            System.Console.Write("Enter the cash you want to recharge: ");
            int cash = int.Parse(Console.ReadLine());

            //Increasing the balance with the user entered cash
            int final = CurrentCustomer.AfterWalletRecharge(cash);
            System.Console.WriteLine("Your updated Wallet Balance is: " + final);

        }

        else
        {
            System.Console.WriteLine("You are Redirected to the SUBMENU");
        }
    }
}

