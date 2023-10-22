public class Student
{
	public string _name; //The '_name' attribute is not encapsulated.
	private int _age; // The '_age' attribute is encapsulated.

	public Student(string name, int age)
	{
		_name = name;
		_age = age;
	}

	public string DisplayAge()
	{
		return $"\n{_name}'s age is: {_age}\n"; // non-encapsulated and encapsulated attributes can be called through the 'DisplayAge()' method.
	}

	public void SetAge(int newAge)
	{
		if (18 <= newAge && newAge <= 30)
		{
			_age = newAge;
		}
		else
		{
			Console.WriteLine($"\n{newAge} is an invalid age\n");
		}
	}
}