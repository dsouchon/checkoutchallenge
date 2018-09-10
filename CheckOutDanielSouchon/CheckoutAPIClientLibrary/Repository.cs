using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckoutAPIClientLibrary
{
    public class Repository
    {
        private static readonly HttpClient client = new HttpClient();

        public ProductModel CreateProduct(ProductModel product)
        {
            var url = $"http://localhost:61263/api/Product";
            // Add content

            var json = JsonConvert.SerializeObject(product);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Get the results from the API, remove any escape characters and deserialize the object to the OrderModel object.
            var resultObject =
            JsonConvert.DeserializeObject<ProductModel>(Regex.Unescape(client.PostAsync(url,
              httpContent).Result.Content.ReadAsStringAsync().Result));

            return resultObject;

        }

        public OrderModel GetOrder(int? orderid)
        {
            var url = $"http://localhost:61263/api/Order/{orderid}";
            // Add content

                       // Get the results from the API, remove any escape characters and deserialize the object to the OrderModel object.
            var resultObject =
            JsonConvert.DeserializeObject<OrderModel>(Regex.Unescape(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result));

            return resultObject;

        }

        public List<OrderItemModel> GetOrderItems(int orderid)
        {
            var url = $"http://localhost:61263/api/orderitem/getfororder/{orderid}";
            // Add content

            // Get the results from the API, remove any escape characters and deserialize the object to the OrderModel object.
            var resultObject =
            JsonConvert.DeserializeObject<List<OrderItemModel>>(Regex.Unescape(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result));

            return resultObject;

        }


        public OrderModel CreateOrder(OrderModel order)
        {
            var url = $"http://localhost:61263/api/Order";
            // Add content

            var json = JsonConvert.SerializeObject(order);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Get the results from the API, remove any escape characters and deserialize the object to the OrderModel object.
            var resultObject =
            JsonConvert.DeserializeObject<OrderModel>(Regex.Unescape(client.PostAsync(url,
              httpContent).Result.Content.ReadAsStringAsync().Result));
                      
            return resultObject;

        }

        public OrderItemModel CreateOrderItem(OrderItemModel item)
        {
            var url = $"http://localhost:61263/api/OrderItem";
            // Add content

            var json = JsonConvert.SerializeObject(item);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Get the results from the API, remove any escape characters and deserialize the object to the OrderItemModel object.
            var resultObject =
            JsonConvert.DeserializeObject<OrderItemModel>(Regex.Unescape(client.PostAsync(url,
              httpContent).Result.Content.ReadAsStringAsync().Result));

            return resultObject;

        }

        public OrderItemModel UpdateOrderItem(int id, OrderItemModel item)
        {
            var url = $"http://localhost:61263/api/OrderItem/{id}";
            // Add content

            var json = JsonConvert.SerializeObject(item);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Get the results from the API, remove any escape characters and deserialize the object to the OrderItemModel object.
            var resultObject =
            JsonConvert.DeserializeObject<OrderItemModel>(Regex.Unescape(client.PutAsync(url,
              httpContent).Result.Content.ReadAsStringAsync().Result));

            return resultObject;

        }


        public string DeleteOrderItems(int orderid)
        {
            StringBuilder resultSb = new StringBuilder();

            OrderModel order = GetOrder(orderid);

            List<OrderItemModel> orderItems = GetOrderItems(orderid);

            foreach (var orderItem in orderItems)
            {
                int id = orderItem.ID;

                string url = $"http://localhost:61263/api/OrderItem/{id}";

                var resultObject = JsonConvert.DeserializeObject<string>(Regex.Unescape(client.DeleteAsync(url).Result.Content.ReadAsStringAsync().Result));

                resultSb.AppendLine(resultObject);
            }

            return resultSb.ToString();

        }

        public string DeleteOrderItem(int id)
        {
            var url = $"http://localhost:61263/api/OrderItem/{id}";

         
            var resultObject = JsonConvert.DeserializeObject<string>(Regex.Unescape(client.DeleteAsync(url).Result.Content.ReadAsStringAsync().Result));

            return resultObject;
            
        }

      




    }
}
