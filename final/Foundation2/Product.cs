public class Product
{
	private string _Name { get; set; }
	private string _ProductID { get; set; }
	private float _Price { get; set; }
	private int _Quantity { get; set; }

	public Product()
	{

	}

	public Product(string name, string id, float price, int quantity)
	{
		this._Name = name;
		this._ProductID = id;
		this._Price = price;
		this._Quantity = quantity;

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