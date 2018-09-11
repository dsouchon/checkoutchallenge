using CheckoutDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutOrderService.ViewModel
{
    /// <summary>
    /// ViewModel for Order Item to include Product and Order properties for display
    /// </summary>
    public class OrderItemViewModel
    {

        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }


        public OrderItemViewModel(OrderItem orderItem)
        {
            this.ID = orderItem.ID;
            this.ProductID = orderItem.ProductID;
            this.OrderID = orderItem.OrderID;

            this.Product = CheckoutDataAccess.Repositories.ProductRepository.Get(this.ProductID);
            this.Order = CheckoutDataAccess.Repositories.OrderRepository.Get(this.OrderID);
        }
    }
}