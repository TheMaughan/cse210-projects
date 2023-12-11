using System.Security.Cryptography.X509Certificates;

public class Address
{
	private string _street;
	private string _state;
	private string _city;
	private string _zip;
	private string _country;

	public Address(string street, string city, string state, string zip, string country)
	{
		_street = street;
		_state = state;
		_city = city;
		_zip = zip;
		_country = country;
	}

	public bool IsInUSA() => string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase);

	public string GetAllFieldsasString() => $"\n{_street}\n{_city}, {_state}  {_zip}\n{_country}\n";
}