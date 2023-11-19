class GoalTypeMenu
{
	private List<Goal> _goals;
    private int _score;

    public GoalTypeMenu()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayCreateGoalMenu()
    {
        Console.WriteLine("\nCreating a New Goal:");
        Console.Write("Enter goal description: ");
        string goalDescription = Console.ReadLine();

        Console.Write("Enter goal value: ");
        int goalValue;
        while (!int.TryParse(Console.ReadLine(), out goalValue))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the goal value.");
            Console.Write("Enter goal value: ");
        }

        Console.WriteLine("Select goal type:");
        Console.WriteLine("a. Simple Goal");
        Console.WriteLine("b. Eternal Goal");
        Console.WriteLine("c. Checklist Goal");

        GoalType goalType = GetGoalTypeInput();

        CreateGoal(goalType, goalDescription, goalValue);
    }

    private GoalType GetGoalTypeInput()
    {
        while (true)
        {
            ConsoleKeyInfo goalTypeKey = Console.ReadKey(true);

            switch (goalTypeKey.KeyChar)
            {
                case 'a':
                    return GoalType.Simple;
                case 'b':
                    return GoalType.Eternal;
                case 'c':
                    return GoalType.Checklist;
                default:
                    Console.WriteLine("Invalid option for goal type. Please choose a, b, or c.");
                    break;
            }
        }
    }

    private void CreateGoal(GoalType goalType, string description, int value)
    {
        Goal newGoal = null;

        switch (goalType)
        {
            case GoalType.Simple:
                newGoal = new SimpleGoal(description, value);
                break;
            case GoalType.Eternal:
                newGoal = new EternalGoal(description, value);
                break;
            case GoalType.Checklist:
                Console.Write("Enter target count for the Checklist Goal: ");
                int targetCount;
                while (!int.TryParse(Console.ReadLine(), out targetCount) || targetCount <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for the target count.");
                    Console.Write("Enter target count for the Checklist Goal: ");
                }
                newGoal = new ChecklistGoal(description, value, targetCount);
                break;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

}

public enum GoalType
{
    Simple,
    Eternal,
    Checklist
}
