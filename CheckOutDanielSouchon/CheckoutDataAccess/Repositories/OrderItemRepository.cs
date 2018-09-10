using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutDataAccess.Repositories
{
    public static class OrderItemRepository
    {

        public static int Save(OrderItem orderItem)
        {
            using (var db = new CheckoutBasketEntities())
            {
                
                if (db.OrderItems.Find(orderItem.ID) != null)
                {
                    db.Entry(orderItem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.OrderItems.Add(orderItem);
                }
                db.SaveChanges();

                return orderItem.ID;


            }

        }

        public static List<OrderItem> Get()
        {

            using (var db = new CheckoutBasketEntities())
            {
                return db.OrderItems.ToList();


            }


        }
        public static OrderItem Get(int? ID)
        {

            using (var db = new CheckoutBasketEntities())
            {
                return db.OrderItems.Find(ID);


            }


        }

        public static List<OrderItem> GetForOrder(int? OrderID)
        {

            using (var db = new CheckoutBasketEntities())
            {
                return db.OrderItems.Where(x=>x.OrderID == OrderID).ToList();


            }


        }

        public static void Delete(int? id)
        {
            using (var db = new CheckoutBasketEntities())
            {
                OrderItem orderItem = db.OrderItems.Find(id);
                db.OrderItems.Remove(orderItem);
                db.SaveChanges();


            }
        }
    }
}
