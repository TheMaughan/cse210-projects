class SimpleGoal : Goal
{
	public SimpleGoal(string description, int value) : base(description, value)
	{
	}

    public override bool IsComplete()
    {
        return base.IsComplete();
    }
}