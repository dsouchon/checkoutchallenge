using CheckoutDataAccess;
using CheckoutDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace CheckoutOrderService.Controllers
{
    /// <summary>
    /// Web Api 2 Controller for Products
    /// </summary>
    [EnableCorsAttribute("*", "*", "*")]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
           {
            new Product { ID = 1, ProductName = "Tomato Soup", Description = "Groceries", Price = 1 },
            new Product { ID = 2, ProductName = "Yo-yo", Description = "Toys", Price = 3.75M },
            new Product { ID = 3, ProductName = "Hammer", Description = "Hardware", Price = 16.99M }
           };


        // GET: api/Product
        [Route("")]
        [EnableCors(origins: "http://localhost:22414", headers: "*", methods: "*")]
        public IEnumerable<Product> Get()
        {
                        
            return ProductRepository.Get();
            
        }

        // GET: api/Product/5
        [Route("{id:int}")]
        public Product Get(int id)
        {
            Product product = ProductRepository.Get(id);



            return product;

        }

        [Route("{name}")]
        [HttpGet]
        public IEnumerable<Product> GetByName(string name)
        {
            Product[] productArray = ProductRepository.Get(name).ToArray<Product>();

            return productArray;
        }


        // POST: api/Product
        [Route("")]
        public Product Post([FromBody]Product newProduct)
        {
            int id = ProductRepository.Save(newProduct);

            return ProductRepository.Get(id);
        }

        // PUT: api/Product/5
        [Route("{id:int}")]
        public Product Put(int id, [FromBody]Product changedProduct)
        {
            if (changedProduct != null)
            {
                ProductRepository.Save(changedProduct);

            }

            return ProductRepository.Get(changedProduct.ID);
        }

        // DELETE: api/Product/5
        [Route("{id:int}")]
        public IEnumerable<Product> Delete(int id)
        {
            ProductRepository.Delete(id);

            return ProductRepository.Get().ToArray();
        }



    }
}
