using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    /// <summary>
    /// Unit tests to demonstrate the Checkout API Client Library
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        
        public  static CheckoutAPIClientLibrary.OrderModel Order { get; set; }
        public static CheckoutAPIClientLibrary.ProductModel Product {get;set;}
        public CheckoutAPIClientLibrary.OrderItemModel OrderItem { get; set; }

        public static int ProductID;
        public static int OrderID;
        public static int OrderItemID;
        public int Quantity { get; set; }
        [TestInitialize]
        public void Setup()
        {
            
            Product = new CheckoutAPIClientLibrary.ProductModel { ProductName = "Batteries", Description="Lithium-Ion", Price=10.99M };
            Order = new CheckoutAPIClientLibrary.OrderModel { UserName = "dsouchon@gmail.com", DateCreated=DateTime.Now };
            Quantity = 3;
        }
        
        [TestCleanup]
        public void TearDown()
        {

           
        }

        [TestMethod]
        public void CreateProduct()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            CheckoutAPIClientLibrary.ProductModel newProduct = repo.CreateProduct(Product);
            // Tests that we expect to return true.
            ProductID = newProduct.ID;
            Assert.AreEqual(newProduct.Description, Product.Description);

     
        }

        [TestMethod]
        public void CreateOrder()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            CheckoutAPIClientLibrary.OrderModel newOrder =  repo.CreateOrder(Order);
            // Tests that we expect to return true.
            OrderID = newOrder.ID;
            Assert.AreEqual(newOrder.UserName, Order.UserName);

       
            
        }

        [TestMethod]
        public void CreateOrderItem()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            CheckoutAPIClientLibrary.OrderItemModel newOrderItem = repo.CreateOrderItem(new CheckoutAPIClientLibrary.OrderItemModel
            {
                OrderID = OrderID,
                ProductID = ProductID,
                Quantity = Quantity
            });
            // Tests that we expect to return true.

            OrderItemID = newOrderItem.ID;

            Assert.AreEqual(newOrderItem.Quantity, Quantity);

        }

        [TestMethod]
        public void CreateOrderItem2()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            CheckoutAPIClientLibrary.OrderItemModel newOrderItem = repo.CreateOrderItem(new CheckoutAPIClientLibrary.OrderItemModel
            {
                OrderID = OrderID,
                ProductID = ProductID,
                Quantity = Quantity
            });
            // Tests that we expect to return true.

            OrderItemID = newOrderItem.ID;

            Assert.AreEqual(newOrderItem.Quantity, Quantity);

        }

        [TestMethod]
        public void GetOrderItemsForOrder()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            List<CheckoutAPIClientLibrary.OrderItemModel> result = repo.GetOrderItems(OrderID);
            // Tests that we expect to return true.

            Assert.AreEqual(result.Count, 2);

        }


        [TestMethod]
        public void UpdateOrderItem()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            CheckoutAPIClientLibrary.OrderItemModel updatedOrderItem = repo.UpdateOrderItem(OrderItemID, new CheckoutAPIClientLibrary.OrderItemModel
            {
                OrderID = OrderID,
                ProductID = ProductID,
                Quantity = 8
            });
            // Tests that we expect to return true.

            Assert.AreEqual(updatedOrderItem.Quantity, 8);

        }

        [TestMethod]
        public void DeleteOrderItem()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            string result = repo.DeleteOrderItem(OrderItemID);
            // Tests that we expect to return true.

            Assert.AreEqual(result, "success");

        }

        [TestMethod]
        public void DeleteOrderItems()
        {
            CheckoutAPIClientLibrary.Repository repo = new CheckoutAPIClientLibrary.Repository();

            string result = repo.DeleteOrderItems(OrderID);
            // Tests that we expect to return true.

            Assert.IsTrue(result.Contains("success"));

        }

    }
}
