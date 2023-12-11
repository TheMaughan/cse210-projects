class Address
{
	public string _Street { get; set; }
	public string _City { get; set; }
	public string _State { get; set; }
	public string _Zip { get; set; }

	public Address(string street, string city, string state, string zip)
	{
		_Street = street;
		_City = city;
		_State = state;
		_Zip = zip;
	}

	public override string ToString() => $"\n{_Street}\n{_City}, {_State}  {_Zip}\n";


}