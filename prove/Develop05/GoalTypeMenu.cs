class GoalTypeMenu
{
	public List<Goal> _goals;
    //private int _score;

    public string _goalDescription;

    public int _goalValue;

    public GoalTypeMenu()
    {
        _goals = new List<Goal>();
        //_score = 0;
    }

    public Goal DisplayCreateGoalMenu()
    {
        Console.WriteLine("\nCreating a New Goal:");

        Console.Write("Enter goal description: ");
        _goalDescription = Console.ReadLine();

        Console.Write("Enter goal value: ");
        while (!int.TryParse(Console.ReadLine(), out _goalValue))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the goal value.");
            Console.Write("Enter goal value: ");
        }

        Console.WriteLine("Select goal type:");
        Console.WriteLine("a. Simple Goal");
        Console.WriteLine("b. Eternal Goal");
        Console.WriteLine("c. Checklist Goal");

        GoalType goalType = GetGoalTypeInput();

        return CreateGoal(goalType, _goalDescription, _goalValue);
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

    private Goal CreateGoal(GoalType goalType, string description, int value)
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
            Console.WriteLine("Goal created successfully!");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        return newGoal;
    }

}

public enum GoalType
{
    Simple,
    Eternal,
    Checklist
}
