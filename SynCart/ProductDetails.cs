using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    /// <summary>
    /// This class use to perform the Product details
    /// </summary
    public class ProductDetails
    {
        /// <summary>
        /// Auto Incrament values cref=ProductDetails
        /// </summary>
        private static int s_prodeuctID = 100;
        /// <summary>
        /// Property for ProductID
        /// </summary>
        public string ProductID { get; }
        /// <summary>
        /// Property for ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Property for Price
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Property for Stock
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Property for ShippingDuration
        /// </summary>
        public int ShippingDuration { get; set; }
        /// <summary>
        /// Constructor for assinging values to the propertites
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        /// <param name="shippingDuration"></param>
        public ProductDetails(string productName, int price, int stock, int shippingDuration)
        {
            s_prodeuctID++;
            ProductID = "PID" + s_prodeuctID;
            ProductName = productName;
            Price = price;
            Stock = stock;
            ShippingDuration = shippingDuration;
        }


    }
}