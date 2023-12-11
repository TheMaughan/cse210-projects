public class Customer
{
	private readonly string _name;
	private readonly Address _address;

	public Customer(string name, Address address)
	{
		this._name = name;
		this._address = address;
	}

	public bool IsInUSA() => _address.IsInUSA();

	public string GetName() => _name;

	public string GetAddress() => _address.GetAllFieldsasString();
}