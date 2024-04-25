using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    /// <summary>
    /// Enum for OrderStatus information
    /// </summary>
    public enum OrderStatus { Default, Ordered, Cancelled }
    /// <summary>
    /// This class use to perform the Order details
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Auto Incrament values cref=OrderDetails
        /// </summary>
        private static int s_orderID = 1000;
        /// <summary>
        /// Property for OrderID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// Property for CustomerID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// Property for ProductID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// Property for Price
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Property for PruchaseDate
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Property for Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Property for OrderStatus
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Constructor for assinging values to the propertites
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="productID"></param>
        /// <param name="price"></param>
        /// <param name="purchaseDate"></param>
        /// <param name="quantity"></param>
        /// <param name="orderStatus"></param>
        public OrderDetails(string customerID, string productID, int price, DateTime purchaseDate, int quantity, OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            ProductID = productID;
            Price = price;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }
    }
}