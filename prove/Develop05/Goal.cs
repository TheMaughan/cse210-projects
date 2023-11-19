class Goal
{
	protected string _description;
	protected int _value;

	public Goal(string description, int value)
	{
		this._description = description;
		this._value = value;
	}

	public string GetDescription()
	{
		return _description;
	}

	public int GetValue()
	{
		return _value;
	}

	public virtual int RecordGoal()
	{
		Console.WriteLine($"Goal Completed: {_description} (+{_value} points)");
		return _value;
	}

	public virtual string DisplayStatus()
	{
		return $"[{(IsComplete() ? 'X' : ' ')}] {_description}";
	}

	public virtual bool IsComplete()
	{
		return true;
	}
}