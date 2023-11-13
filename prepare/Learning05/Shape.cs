abstract class Shape
{
	private string _color { get; set; }

	public Shape(string color)
	{
		_color = color;
	}

	public virtual string Color()
	{
		return _color;
	}

	public abstract double GetArea();

	public abstract string Identify();
}