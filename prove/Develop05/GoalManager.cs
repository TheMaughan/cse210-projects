using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
	public List<Goal> _goals;
	public int _score;
	//public string _typeName;

	public GoalManager()
	{
		_goals = new List<Goal>();
		_score = 0;
		//_typeName = "";
	}

	public void AddGoal()
	{
		GoalTypeMenu gmenu = new();
		Goal newGoal = gmenu.DisplayCreateGoalMenu();

		if (newGoal != null)
        {
            _goals.Add(newGoal);
        }

	}

	public void RecordEvent()
	{
		Console.Clear();
		Console.WriteLine("Available Goals:");
		for (int i = 0; i < _goals.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {_goals[i].DisplayStatus()}");
		}

		Console.Write("Select the goal index to update: ");
		if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
		{
			_score += _goals[goalIndex - 1].RecordGoal();

			//SaveToFile("goal");
		}
		else
		{
			Console.WriteLine("Invalid goal index");
		}
	}

	public void SaveToFile(string fileName)
	{
		int count = 0;
		try
		{
			if (!fileName.EndsWith(".txt"))
				fileName += ".txt"; //Add the file extension, simplified

			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach(var goal in _goals)
				{

					if (goal is ChecklistGoal checklistGoal)
					{
						// Serialize the goal details and write to the file
						writer.WriteLine($"{count++},{checklistGoal.GetType().Name},{checklistGoal.GetDescription()},{checklistGoal.GetValue()},{checklistGoal.GetTarget()},{checklistGoal.GetCount()},{goal.IsComplete()}");
					}
					else if (goal is EternalGoal eternalGoal)
					{
						writer.WriteLine($"{count++},{eternalGoal.GetType().Name},{eternalGoal.GetDescription()},{eternalGoal.GetValue()},{eternalGoal.GetProgress()},{eternalGoal.IsComplete()}");
					}
					else
					{
						// Serialize the goal details and write to the file
						writer.WriteLine($"{count++},{goal.GetType().Name},{goal.GetDescription()},{goal.GetValue()},{goal.IsComplete()}");
					}
					

				}
			}
			Console.WriteLine($"Goals saved successfully to the file '{fileName}'.\n");
		}

		catch (Exception e)
		{
			Console.WriteLine($"An error occurred while saving the file: {e.Message}");
		}
	}

	public void LoadFromFile(string fileName)
	{
		try
		{
			if (!fileName.EndsWith(".txt"))
				fileName += ".txt";

			if (File.Exists(fileName))
			{
				_goals.Clear();

				using (StreamReader reader = new(fileName))
				{
					//string[] line = System.IO.File.ReadAllLines(fileName);
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						// Deserialize the goal details from the file
						string[] parts = line.Split(",");
						string index = parts[0];
						string typeName = parts[1];
						string description = parts[2];
						int value = int.Parse(parts[3]);
						// bool isComplete = bool.Parse(parts[4]);

						if (typeName == "ChecklistGoal")
						{
							int target = int.Parse(parts[4]);
							int count = int.Parse(parts[5]);
							bool isComplete = bool.Parse(parts[6]);

							Type goalType = Type.GetType(typeName);
							if (goalType == null)
							{
								Console.WriteLine($"Error: Type '{typeName}' not found.");
								// Handle the error, perhaps by skipping this line or logging the issue.
								continue; // Skip to the next iteration of the loop
							}

							// Goal goal = (Goal)Activator.CreateInstance(goalType, description, value, target);
							// goal.SetCount(count);

							ChecklistGoal c = new(description, value, target);
							c.SetCount(count);

							if (isComplete)
							{
								c.IsComplete();
								_score += value * count;
							}

							_goals.Add(c);

						}
						else if (typeName == "EternalGoal")
						{
							int eternalProgress = int.Parse(parts[4]);
							bool isComplete = bool.Parse(parts[5]);

							Type goalType = Type.GetType(typeName);
							if (goalType == null)
							{
								Console.WriteLine($"Error: Type '{typeName}' not found.");
								// Handle the error, perhaps by skipping this line or logging the issue.
								continue; // Skip to the next iteration of the loop
							}

							//Goal goal = (Goal)Activator.CreateInstance(goalType, description, value);
							EternalGoal e = new(description,value);
							e.SetProgress(eternalProgress);

							if (isComplete)
							{
								e.IsComplete();
								_score += eternalProgress + value;
							}

							_goals.Add(e);
						}
						else
						{
							bool isComplete = bool.Parse(parts[4]);
							
							Type goalType = Type.GetType(typeName);
							if (goalType == null)
							{
								Console.WriteLine($"Error: Type '{typeName}' not found.");
								// Handle the error, perhaps by skipping this line or logging the issue.
								continue; // Skip to the next iteration of the loop
							}

							Goal goal = (Goal)Activator.CreateInstance(goalType, description, value);

							if (isComplete)
							{
								goal.IsComplete();
								_score += value;
							}

							_goals.Add(goal);
						}
					}
					Console.WriteLine("File Loaded Successfully!");
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine($"An error occurred while loading goals: {e.Message}");
		}
	}

	public void DisplayGoals()
	{
		Console.WriteLine("Goals:\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
		for (int i = 0; i < _goals.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {_goals[i].DisplayStatus()}");
		}
		Console.WriteLine($"\nTotal Score: {_score} points\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
	}
	
}