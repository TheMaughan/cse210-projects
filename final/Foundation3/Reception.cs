class Reception : Event
{
	private string _rsvEmail;

	public Reception(string title, string desctiption, DateTime date, TimeSpan time, Address address, string rsvEmail)
		: base(title, desctiption, date, time, address)
	{
		this._rsvEmail = rsvEmail;
	}

	public override string GetFullDetails() => $"\n{base.GetFullDetails()}\nType: Reception\nRSVP Email: {_rsvEmail}\n";
}