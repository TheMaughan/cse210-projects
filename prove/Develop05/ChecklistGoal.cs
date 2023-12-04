class ChecklistGoal : Goal
{

	private int _targetCount;
	private int _currentCount;

	public ChecklistGoal(string description, int value, int target) : base(description, value)
	{
		this._targetCount = target;
		this._currentCount = 0;
	}

	public override int RecordGoal()
	{
		Console.WriteLine($"Checklist Goal Progress: {_description} (+{_value} points)");
		_currentCount++;

		if (_currentCount == _targetCount)
		{
			Console.WriteLine($"\nCongradulations! Checklist Goal Completed: {_description}");
			return _value + _value; // Points are doubled as a bonus!
		}

		return _value;
	}

    public override string DisplayStatus()
    {
		// if completed show [X]
		if (IsComplete())
		{
			return $"[X] {_description} is Completed {_currentCount}/{_targetCount} times - Value = {_value}";
		}
		// otherwise put a [ ]
		else
		{
			return $"[ ] {_description} is Not Completed {_currentCount}/{_targetCount} times - Value = {_value}";
		}
    }

    public override bool IsComplete()
	{
		return _currentCount == _targetCount;
	}

	public string GetProgress()
	{
		return $"\nGoals completed: {_currentCount} / {_targetCount}";
	}

	public int GetTarget()
	{
		return _targetCount;
	}
	public int GetCount()
	{
		return _currentCount;
	}

	public void SetCount(int count)
	{
		_currentCount = count;
	}
}