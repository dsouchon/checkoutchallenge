Checkout Challenge Solution

Consists of:

1. CheckoutOrderService
This is a .NET Web API 2 service used for managing an order
It has CORS enabled to allow for cross-origin calls

2. CheckoutAPIClientLibrary
The client library provides simpler access to the API with simpler classes and methods like:
CreateOrder, CreateOrderItem, UpdateOrderItem
for a developer to integrate with the API

3. CheckoutDataAccess
This persists the data using Entity Framework and a SQL Server database
The attached script CreateDatabase.sql should be run to set up the database in SQL Server

4. UnitTestProject1	
Tests to verify the methods of the API Client Library