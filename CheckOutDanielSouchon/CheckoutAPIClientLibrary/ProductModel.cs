using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAPIClientLibrary
{
    public partial class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
