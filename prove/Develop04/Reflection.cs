using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Threading;

class Reflection : MindfulFoundation
{

	protected List<string> _question = new List<string>
	{
		"Why was this experience meaningful to you?",
		"Have you ever done anything like this before?",
		"How did you get started?",
		"How did you feel when it was complete?",
		"What made this time different than other times when you were not as successful?",
		"What is your favorite thing about this experience?",
		"What could you learn from this experience that applies to other situations?",
		"What did you learn about yourself through this experience?",
		"How can you keep this experience in mind in the future?"
	};

	public Reflection()
	{
		Message = new List<string>()
		{
			"Think of a time when you stood up for someone else.",
			"Think of a time when you did something really difficult.",
			"Think of a time when you helped someone in need.",
			"Think of a time when you did something truly selfless."	
		};
	}

    protected override void PerformActivity()
    {
		Console.WriteLine("\nPress 'ESC' anytime to exit the activiy.\n==============================================");
        Console.WriteLine("\nThis activity will help you reflect on times in your life when you have shown strength and resilience.");
		Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.\n");

		Random random = new Random();
		int time = 0;
		int totalQ = _question.Count;
		int QIndex = 0;

		while (time < _activityDuration)
		{
			
			string message = Message[random.Next(Message.Count)];
			Console.WriteLine($"Prompt: {message}");
			DisplayAnimation();

			for (int i = 0; i < totalQ && time < _activityDuration; i++)
			{
				
				string prompt = _question[random.Next(_question.Count)];	
				Console.WriteLine($"{prompt}");
				DisplayAnimation();

				QIndex = (QIndex + 1) % totalQ;
				time += _secondsDuration;
			}
		}
    }
}