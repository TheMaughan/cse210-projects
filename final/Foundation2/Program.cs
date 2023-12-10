using YamlDotNet.Serialization;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Product> products = ReadProducts("products.yaml");
            List<Customer> customers = ReadCustomers("customers.yaml");

            Order order1 = new Order("000af423", products.Take(2).ToList(), customers[0]);
            Order order2 = new Order("000af973", products.Skip(1).Take(1).ToList(), customers[1]);

            order1.DisplayOrder();
            Console.WriteLine();
            order2.DisplayOrder();

            WriteOrders("orders.yaml", new List<Order> {order1, order2 });
        }
        catch (YamlDotNet.Core.YamlException ye)
        {
            Console.WriteLine($"YAML Exception: {ye.Message}");
            Console.WriteLine($"At line {ye.Start.Line}, column {ye.Start.Column}");
            Console.WriteLine($"Stack Trace: {ye.StackTrace}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during deserialization: {e.Message}");
        }
        
    }
    static List<Product> ReadProducts(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    var deserializer = new DeserializerBuilder().Build();
                    var products = deserializer.Deserialize<List<Product>>(reader);
                    return products ?? new List<Product>();
                }
            }
            else
            {
                Console.WriteLine($"Error: File not found - {filePath}");
                return new List<Product>();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found - {filePath}");
            return new List<Product>();
        }
        catch (YamlDotNet.Core.YamlException ye)
        {
            Console.WriteLine($"YAML Exception: {ye.Message}");
            Console.WriteLine($"At line {ye.Start.Line}, column {ye.Start.Column}");
            
            Console.WriteLine($"Inner Exception: {ye.InnerException}");
            Console.WriteLine($"Stack Trace: {ye.StackTrace}");
            return new List<Product>();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return new List<Product>();
        }

    }

    static List<Customer> ReadCustomers(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    var deserializer = new DeserializerBuilder().Build();
                    var customers = deserializer.Deserialize<List<Customer>>(reader);
                    return customers ?? new List<Customer>();
                }
            }
            else
            {
                Console.WriteLine($"Error: File not found - {filePath}");
                return new List<Customer>();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found - {filePath}");
            return new List<Customer>();
        }
        catch (YamlDotNet.Core.YamlException ye)
        {
            Console.WriteLine($"YAML Exception: {ye.Message}");
            Console.WriteLine($"At line {ye.Start.Line}, column {ye.Start.Column}");
            Console.WriteLine($"Stack Trace: {ye.StackTrace}");
            return new List<Customer>();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return new List<Customer>();
        }

    }


    static void WriteOrders(string filePath, List<Order> orders)
    {
        var serializer = new SerializerBuilder().Build();
        File.WriteAllText(filePath, serializer.Serialize(orders));
    }
}