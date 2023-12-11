using System;
using System.Collections.Generic;
using System.IO;

class CSVReader
{
    public static List<Product> ReadProducts(string filePath)
    {
        List<Product> products = new List<Product>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string name = values[0];
                    string productId = values[1];
                    double price = Convert.ToDouble(values[2]);
                    int quantity = Convert.ToInt32(values[3]);

                    Product product = new Product(name, productId, price, quantity);
                    products.Add(product);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading product file: {ex.Message}");
        }

        return products;
    }

    public static List<Customer> ReadCustomers(string filePath)
    {
        List<Customer> customers = new List<Customer>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string name = values[0];
                    string streetAddress = values[1];
                    string city = values[2];
                    string state = values[3];
					string zip = values[4];
                    string country = values[5];

                    Address address = new Address(streetAddress, city, state, zip, country);
                    Customer customer = new Customer(name, address);
                    customers.Add(customer);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading customer file: {ex.Message}");
        }

        return customers;
    }

    public static List<Order> ReadOrders(string filePath, List<Customer> customers, List<Product> products)
    {
        List<Order> orders = new List<Order>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    int orderNum = Convert.ToInt32(values[0]);
                    int customerIndex = Convert.ToInt32(values[1]) - 1; // Assuming 1-based index
                    Customer customer = customers[customerIndex];

                    Order order = new Order(orderNum, customer);

                    for (int i = 2; i < values.Length; i++)
                    {
                        int productIndex = Convert.ToInt32(values[i]) - 1; // Assuming 1-based index
                        Product product = products[productIndex];
                        order.AddProduct(product);
                    }

                    orders.Add(order);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading order file: {ex.Message}");
        }

        return orders;
    }
}
