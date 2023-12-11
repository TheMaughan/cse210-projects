class Program
{
    static void Main(string[] args)
    {
        List<Product> products = CSVReader.ReadProducts("products.csv");
        List<Customer> customers = CSVReader.ReadCustomers("customers.csv");
        List<Order> orders = CSVReader.ReadOrders("orders.csv", customers, products);

        // Display details for each order
        foreach (var order in orders)
        {
            Console.WriteLine($"Order {order.GetOrderNum()} for Customer {order._Customer.GetName()}:");

            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.PackingLabel());

            Console.WriteLine("\nShipping Label:");
            Console.WriteLine(order.GetShipping());

            Console.WriteLine($"\nTotal Price: $ {order.GetPrice()}");

            Console.WriteLine("\n--------------------------------\n");
        }
    }
}