public class Product
{
	private string _Name { get; set; }
	private string _ProductID { get; set; }
	private float _Price { get; set; }
	private int _Quantity { get; set; }

	public Product(string name, string id, float price, int quantity)
	{
		_Name = name;
		_ProductID = id;
		_Price = price;
		_Quantity = quantity;
	}
	
	public Product()
	{
		_Name = "";
		_ProductID = "";
		_Price = 0;
		_Quantity = 0;
	}

	public string GetName() => _Name;
	public string GetID() => _ProductID;
	public float GetPrice() => _Price * _Quantity;
	public int GetQuantity() => _Quantity;
	public int RemoveStock(int take)
	{
		_Quantity -= take;
		return _Quantity;
	}	
}