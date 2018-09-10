using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutDataAccess.Repositories
{
    public static class OrderRepository
    {
        public static int Save(Order order)
        {
            using (var db = new CheckoutBasketEntities())
            {
                if (db.Orders.Find(order.ID) != null)
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Orders.Add(order);
                }
                db.SaveChanges();

                return order.ID;


            }

        }

        public static List<Order> Get()
        {

            using (var db = new CheckoutBasketEntities())
            {
                return db.Orders.ToList();


            }


        }
        public static Order Get(int? ID)
        {

            using (var db = new CheckoutBasketEntities())
            {
                return db.Orders.Find(ID);


            }


        }

        public static List<Order> Get(string userName)
        {
            using (var db = new CheckoutBasketEntities())
            {
                return db.Orders.Where(x=>x.UserName.ToLower().Contains(userName)).ToList();


            }
        }


        public static void Delete(int? id)
        {
            using (var db = new CheckoutBasketEntities())
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();


            }
        }

       
    }
}
