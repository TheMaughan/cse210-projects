class Breathing : MindfulFoundation
{

	private bool _breathingIn = true;
	private BreathAnimations breathAnimations;

	public Breathing()
	{
		breathAnimations = new BreathAnimations();
		StartActivity();
	}

    protected override void PerformActivity()
    {
		Console.Clear();
        Console.WriteLine("\nThis activity will help you relax by walking you through a breathing activity.");
		Console.WriteLine("Clear your mind and focus on your breathing.");
		Console.WriteLine("\nPress 'ESC' anytime to exit");

		breathAnimations.DisplayAnimation(_breathingIn, _secondsDuration, _activityDuration);
    }
}