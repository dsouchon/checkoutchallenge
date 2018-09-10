using CheckoutDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using CheckoutDataAccess;

namespace WebApplication9.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        //Order[] orders = new Order[]
        //   {
        //    new Order { ID = 1, UserName = "daniel@gmail.com", DateCreated=DateTime.Now },
        //    new Order { ID = 2, UserName = "mary@gmail.com", DateCreated=DateTime.Now },
        //    new Order { ID = 3, UserName = "bob@gmail.com", DateCreated=DateTime.Now },
        //   };


        // GET: api/Order
        [Route("")]
        public IEnumerable<Order> Get()
        {
            return OrderRepository.Get();
        }

        // GET: api/Order/5
        [Route("{id:int}")]
        public Order Get(int id)
        {
            Order order = OrderRepository.Get(id);

           
            return order;
        }

        [Route("{name}")]
        [HttpGet]
        public IEnumerable<Order> GetByUserName(string name)
        {
            Order[] orderArray = OrderRepository.Get(name).ToArray<Order>();

            return orderArray;
        }


        // POST: api/Order
        [Route("")]
        public Order Post([FromBody]Order newOrder)
        {
            

            int id = OrderRepository.Save(newOrder);
            
            return OrderRepository.Get(id);

        }

        // PUT: api/Order/5
        [Route("{id:int}")]
        public IEnumerable<Order> Put(int id, [FromBody]Order changedOrder)
        {
          
            if (changedOrder != null)
            {
                OrderRepository.Save(changedOrder);
                
            }

            return OrderRepository.Get().ToArray();
        }

        // DELETE: api/Order/5
        [Route("{id:int}")]
        public IEnumerable<Order> Delete(int id)
        {
           
                OrderRepository.Delete(id);

            return OrderRepository.Get().ToArray();
        }



    }
}
