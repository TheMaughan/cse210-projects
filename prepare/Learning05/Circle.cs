class Circle : Shape
{
	protected double _radius;

	public Circle(double radius, string color) : base (color)
	{
		_radius = radius;
	}

	public override double GetArea()
	{
		return _radius * _radius * 3.14;
	}

	public override string Identify()
	{
		return "circle";
	}
}