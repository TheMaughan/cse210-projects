using System;
using System.Collections.Generic;

public class Elevator : ObjectFoundations
{
	//Default state is not moving and not called.
	private bool _up = false;
	private bool _down = false;
	private bool _isCalled = false;
	private int _CallerNum;

	public List<int> Requests { get; set; };

	public Elevator(int x, int y) : base(x, y)
	{
		Requests = new List<int>();
	}

	public void FloorCall(int floorNum)
	{
		_CallerNum = floorNum;
		_isCalled = true;
		Requests.Add(floorNum);

		if (_pointY < floorNum)
		{
			_up = true;
		}
		else if (_pointY > floorNum)
		{
			_down = true;
		}
		else
		{
			Arrived();
			Console.WriteLine("\nYou are already at your floor destination.\n");
		}
	}

	public void GoToFloor()
	{
		while (_isCalled && Requests.Count > 0)
		{
			if (_up)
			{
				_pointY += 1;
			}

			else if (_down)
			{
				_pointY -= 1;
			}
			else
			{
				Arrived();
				Console.WriteLine($"\nYou have arrived at the floor {Requests[0]}.\n");
			}	
		}
	}

	public void Arrived()
	{
		_isCalled = false;
		_down = false;
		_up = false;
		Requests.RemoveAt(0);
	}

}