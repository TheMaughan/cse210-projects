using System;

public class VIP : Elevator
{
	private bool _cardKey = false; //Default state is locked.

	//public VIP(int x, int y) : base(x, y)
	public VIP(int x) : base(x)
	{
		// Call the base class constructor with the appropriate parameters.
	}

	public bool ValidKey(bool valid)
	{
		_cardKey = valid;
		
		if (_cardKey)
		{
			_maxFloor = 31;
		}
		else
		{
			_maxFloor = 30;
			Console.WriteLine($"/!\\ Invalid key card! VIP access is denied! /!\\");
		}

		return _cardKey;
	}

	public void VIPFloorCall()
	{
		_cardKey = true;
		// if (_cardKey)
		// {
			Requests.Clear();
			FloorCall(_maxFloor);
		// }
		// else
		// {
		// 	Console.WriteLine($"/!\\ Invalid key card! VIP access is denied! /!\\");
		// }
	}

	public new void Arrived()
	{
		// Restore defaults.
		if (_maxFloor == 31)
		{
			_maxFloor = 30;
			_cardKey = false;
			base.Arrived();	
		}
		// else
		// {
		// 	_maxFloor = 30;
		// 	_cardKey = false;
		// 	base.Arrived();
		// }
		
	}

}