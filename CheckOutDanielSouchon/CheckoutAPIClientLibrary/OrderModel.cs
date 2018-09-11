using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAPIClientLibrary
{
    /// <summary>
    /// Model for the Order / Basket
    /// </summary>
    public class OrderModel
    {

        public int ID { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }


        public List<OrderItemModel> OrderItems { get; set; }

    }
}
