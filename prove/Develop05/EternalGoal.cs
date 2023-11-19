class EternalGoal : Goal
{

	private int _eternalProgress;

	public EternalGoal(string description, int value) : base(description, value)
	{
		_eternalProgress = 0;
	}

	public override int RecordGoal()
	{
		Console.WriteLine($"Eternal Goal Progress: {_description} (+{_value} points)");
		_eternalProgress++;
		return _value;
	}

    public override string DisplayStatus()
    {
        return $"[{_eternalProgress}] {_description}";
    }
}