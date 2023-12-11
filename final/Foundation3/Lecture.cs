class Lecture : Event
{
	private string _speaker;
	private int _capacity;

	public Lecture(string title, string desctiption, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
		: base(title, desctiption, date, time, address)
	{
		this._speaker = speaker;
		this._capacity = capacity;
	}

    public override string GetFullDetails() => $"\n{base.GetFullDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity} attendees\n";

}