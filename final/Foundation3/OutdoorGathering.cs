class OutdoorGathering : Event
{
	private string _weatherStatement;

	public OutdoorGathering(string title, string desctiption, DateTime date, TimeSpan time, Address address, string weatherStatement)
		: base(title, desctiption, date, time, address)
	{
		this._weatherStatement = weatherStatement;
	}

	public override string GetFullDetails() => $"\n{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {_weatherStatement}\n";
}