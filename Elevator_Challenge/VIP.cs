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
		}

		return _cardKey;
	}

	public void VIPFloorCall()
	{
		if (_cardKey)
		{
			Requests.Clear();
			FloorCall(_maxFloor);
		}
		else
		{
			Console.WriteLine($"/!\\ Invalid key card! VIP access is denied! /!\\");
		}
	}

	public new void Arrived()
	{
		// Restore defaults.
		_maxFloor = 30;
		_cardKey = false;
		base.Arrived();
	}

}