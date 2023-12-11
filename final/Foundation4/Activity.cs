class Activity
{
	protected string _date;
	protected int _minutes;

	public Activity(string date, int minutes)
	{
		_date = date;
		_minutes = minutes;
	}

	public virtual double GetDistance() => 0;
	public virtual double GetSpeed() => 0;
	public virtual double GetPace() => 0;
	public virtual string GetSummary() => $"{_date} ({_minutes} min)";

}