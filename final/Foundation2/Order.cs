using System.Reflection.Metadata;

public class Order
{
	private string _orderNum;
	private List<Product> _products;
	private Customer _customer;

	public Order()
	{
		
	}

	public Order(string orderNum, List<Product> products, Customer customer)
	{
		this._orderNum = orderNum;
		this._products = products;
		this._customer = customer;
	}

	public double GetPrice()
	{
		double totalPrice = _products.Sum(product => product.GetPrice());
		return totalPrice + (_customer.IsInUSA() ? 5 : 35);
	}

	public string PackingLabel() => string.Join("\n", _products.Select(product => $"{product.GetName()} - {product.GetID()}"));

	public string GetShipping() => $"{_customer.GetName()}\n{_customer.GetAddress()}";

	public void DisplayOrder()
	{
		Console.WriteLine($"Order: {_orderNum}: ");
		Console.WriteLine($"Packing Label:\n{PackingLabel()}");
		Console.WriteLine($"Shipping Label:\n{GetShipping()}");
		Console.WriteLine($"Total Price: ${GetPrice():F2}");
	}
}