using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private int _orderNum;
    private List<Product> _products;
    private Customer _customer;

	public Customer _Customer { get { return _customer; } }

    public Order(int orderNum, Customer customer)
    {
        _orderNum = orderNum;
        _customer = customer;
        _products = new List<Product>();
    }

	public int GetOrderNum() => _orderNum;
	public List<Product> GetProducts() => _products;

    public double GetPrice()
    {
        double totalPrice = _products.Sum(product => product._Price);
        return totalPrice + (_customer.IsInUSA() ? 5 : 35);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string PackingLabel() => string.Join("\n", _products.Select(product => $"{product._Name} - {product._ProductID}"));

    public string GetShipping() => $"{_customer.GetName()}\n{_customer.GetAddress()}";

    public void DisplayOrder()
    {
        Console.WriteLine($"Order: {_orderNum}: ");
        Console.WriteLine($"Packing Label:\n{PackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{GetShipping()}");
        Console.WriteLine($"Total Price: ${GetPrice():F2}");
    }
}
