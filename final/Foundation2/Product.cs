public class Product
{
	private string _name;
	private string _productID;
	private double _price;
	private int _quantity;

	public string _Name { get {return _name; } }
	public string _ProductID { get {return _productID; } }
	public double _Price { get {return _price * _quantity; } }

	public Product(string name, string id, double price, int quantity)
	{
		this._name = name;
		this._productID = id;
		this._price = price;
		this._quantity = quantity;
	}

	// public string GetName() => _Name;
	// public string GetID() => _ProductID;
	// public double GetPrice() => _Price * _Quantity;
	// public int GetQuantity() => _Quantity;
	public int RemoveStock(int take)
	{
		_quantity -= take;
		return _quantity;
	}	
}