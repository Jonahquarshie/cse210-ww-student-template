using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address(
            "123 Main Street",
            "Salt Lake City",
            "Utah",
            "USA");

        Customer customer1 = new Customer(
            "Divine Sesi",
            address1);

        Product product1 = new Product(
            "Wireless Mouse",
            "P1001",
            25.50,
            2);

        Product product2 = new Product(
            "Keyboard",
            "P1002",
            45.00,
            1);

        Product product3 = new Product(
            "USB Cable",
            "P1003",
            10.00,
            3);

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // Order 2
        Address address2 = new Address(
            "45 Oxford Road",
            "London",
            "England",
            "UK");

        Customer customer2 = new Customer(
            "Emily Johnson",
            address2);

        Product product4 = new Product(
            "Laptop Stand",
            "P2001",
            35.00,
            1);

        Product product5 = new Product(
            "Webcam",
            "P2002",
            60.00,
            2);

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // Store the orders in a list
        List<Order> orders = new List<Order>
        {
            order1,
            order2
        };


        // Display each order
        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine($"========== ORDER {orderNumber} ==========");
            Console.WriteLine();

            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            orderNumber++;
        }
    }
}