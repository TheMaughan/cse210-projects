class Cycling : Activity
{
	private double _speed;

	public Cycling(string date, int minutes, double speed) : base(date, minutes)
	{
		_speed = speed;
	}

	public override double GetDistance() => _speed * _minutes / 60;
	public override double GetSpeed() => _speed;
	public override double GetPace() => 60 / _speed;
	public override string GetSummary() => $"{base.GetSummary()} - Distance: {GetDistance()} miles\nSpeed: {_speed} mph\nPace: {GetPace()} min/mile\n";
}