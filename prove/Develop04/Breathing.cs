class Breathing : MindfulFoundation
{

	public Breathing(int time) :base(time)
	{
		Message = new List<string>()
		{
			"( -o-) ZzZ - Breath in",
			"( -_-) zZz - Breath out",
			"( -o-) ZzZ - Breath in",
			"( -_-) zZz - Breath out"	
		};
	}
	

	public new void Animate(List<string> _breath, ref int currentIndex)
	{
		Console.Clear();

		Console.WriteLine(_breath[currentIndex]);

		currentIndex = (currentIndex + 1) % _breath.Count;
	}

	public new void DisplayAnimation()
	{
		
	}


}