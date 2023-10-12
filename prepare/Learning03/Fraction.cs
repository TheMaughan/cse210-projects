public class Fraction
{
	private int Top { get; set; }
	private int Bottom { get; set; }

	public Fraction()
	{
		Top = 1;
		Bottom = 1;
	}
	public Fraction(int wholeNumber)
	{
		Top = wholeNumber;
		Bottom = 1;
	}
	public Fraction(int top, int bottom)
	{
		Top = top;
		Bottom = bottom;
	}

	public string GetFractionString()
	{
		return $"\nThe fraction is: {Top}/{Bottom}\n";
	}

	public double GetDecimalValue()
	{
		return (double)Top / (double)Bottom;
	}

}