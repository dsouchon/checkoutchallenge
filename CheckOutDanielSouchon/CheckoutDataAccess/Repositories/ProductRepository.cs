using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace CheckoutDataAccess.Repositories
{
    /// <summary>
    /// CRUD repository for Products
    /// </summary>
    [EnableCors(origins: "http://localhost:22414", headers: "*", methods: "*")]
    
    public static class ProductRepository
    {

        public static int Save(Product product)
        {
            try
            {
                using (var db = new CheckoutBasketEntities())
                {

                    var entity = db.Products.Where(c => c.ID == product.ID).AsQueryable().FirstOrDefault();
                    if (entity == null)
                    {
                        db.Products.Add(product);
                    }
                    else
                    {
                        db.Entry(entity).CurrentValues.SetValues(product);
                    }

                   db.SaveChanges();

                    return product.ID;


                }
            }
            catch (Exception e)
            {
                throw;

            }
        }
        public static IEnumerable<Product> Get()
        {

            using (var db = new CheckoutBasketEntities())
            {
               
                IQueryable<Product> products = from p in db.Products
                                               orderby p.ProductName descending
                                               select p;
                Product[] productsArray = products.ToArray();

                return productsArray;
            }


        }

        public static List<Product> Get(string productName)
        {
            using (var db = new CheckoutBasketEntities())
            {
                return db.Products.Where(x => x.ProductName.ToLower().Contains(productName)).ToList();


            }
        }

        public static Product Get(int? ID)
        {

            using (var db = new CheckoutBasketEntities())
            {
                return db.Products.Find(ID);


            }


        }


        public static void Delete(int? id)
        {
            using (var db = new CheckoutBasketEntities())
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();


            }
        }

    }
}
