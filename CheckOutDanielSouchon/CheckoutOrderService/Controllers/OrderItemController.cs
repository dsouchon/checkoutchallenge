using CheckoutDataAccess;
using CheckoutDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace WebApplication9.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
   
    public class OrderItemController : ApiController
    {
        

        // GET: api/OrderItem
        [Route("api/orderitem")]
        public IEnumerable<OrderItem> Get()
        {
            return OrderItemRepository.Get();
        }

        [Route("api/orderitem/getfororder/{id:int}")]
       // [Route("")]
        public IEnumerable<ViewModel.OrderItemViewModel> GetForOrder(int id)
        {
            List<ViewModel.OrderItemViewModel> orderItems = new List<ViewModel.OrderItemViewModel>();

            foreach (var orderItem in OrderItemRepository.GetForOrder(id))
            {
                orderItems.Add(new ViewModel.OrderItemViewModel(orderItem));
            }
            return orderItems;
        }


        // GET: api/OrderItem/5
        [Route("api/orderitem/{id:int}")]
        public ViewModel.OrderItemViewModel Get(int id)
        {
            ViewModel.OrderItemViewModel orderItem = new ViewModel.OrderItemViewModel(OrderItemRepository.Get(id));



            return orderItem;
        }

       
        // POST: api/OrderItem
        [Route("api/orderitem")]
        public OrderItem Post([FromBody]OrderItem newOrderItem)
        {
            int newid = OrderItemRepository.Save(newOrderItem);

            return OrderItemRepository.Get(newid);
        }

        // PUT: api/OrderItem/5
        [Route("api/orderitem/{id:int}")]
        public OrderItem Put(int id, [FromBody]OrderItem changedOrderItem)
        {
            int Id = 0;
            if (changedOrderItem != null)
            {
                Id = OrderItemRepository.Save(changedOrderItem);

            }

            return OrderItemRepository.Get(Id);
        }

        // DELETE: api/OrderItem/5
        [Route("api/orderitem/{id:int}")]
        public string Delete(int id)
        {
            try
            {
                OrderItemRepository.Delete(id);

                return "success";
            }
            catch (Exception e) {

                return "fail:" + e.Message;
            }
        }



    }
}
