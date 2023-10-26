using System;
using System.Collections.Generic;

public class Elevator : ObjectFoundations
{
    private bool _up = false;
    private bool _down = false;
    private bool _isCalled = false;
    private int _CallerNum;
    protected int _maxFloor = 30;

    public List<int> Requests { get; set; }

	//public Elevator(int x) : base(x)
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
        else if (_CallerNum > _maxFloor)
        {
            Requests.RemoveAt(Requests.Count - 1);
            Console.WriteLine($"Invalid floor entry, max floors is {_maxFloor}");
        }
        else
        {
            Arrived();
            Console.WriteLine("\nYou are already at your floor destination.\n");
            Console.WriteLine($"_pointY is logged at {_pointY}\n");
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
                Console.WriteLine($"_pointY is logged at {_pointY}\n"); //Requests[0] & pointY should match.
            }
        }
    }

    public void Arrived()
    {
		// Pending updates include the following:
		// Open & close doors, load & unload patrons, set a delay timer between each action, play elevator music.
		// A seperate set of internal elevator car object families can handle the specifics.
        _isCalled = false;
        _down = false;
        _up = false;
        Requests.RemoveAt(0);
    }
}