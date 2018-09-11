using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAPIClientLibrary
{
    /// <summary>
    /// Model for the item in a basket
    /// </summary>
    public class OrderItemModel
    {
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }

        public ProductModel Product { get; set; }
        public OrderModel Order { get; set; }
    }
}
