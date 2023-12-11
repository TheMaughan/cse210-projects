class Event
{
	private string _title;
	private string _description;
	private DateTime _date;
	private TimeSpan _time;
	private Address _address;

	public Event(string title, string description, DateTime date, TimeSpan time, Address address)
	{
		_title = title;
		_description = description;
		_date = date;
		_time = time;
		_address = address;
	}

	public virtual string GetStandardDetails() => $"{_title}\n\n{_description}\nDate: {_date.ToShortDateString()} Time: {_time.ToString(@"hh\:mm")}\n\nAddress: {_address}";

	public virtual string GetFullDetails() => GetStandardDetails();

	public virtual string GetShortDetails() => $"\n{GetType().Name}: {_title}\nDate: {_date.ToShortDateString()}\n";

}