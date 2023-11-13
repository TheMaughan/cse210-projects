class Square : Shape
{
	protected double _side;

	public Square(double side, string color) : base (color)
	{
		_side = side;
	}

	public override double GetArea()
	{
		return _side * _side;
	}

	public override string Identify()
	{
		return "square";
	}

}