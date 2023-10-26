using System;
using System.Collections.Generic;

public class Elevator : ObjectFoundations
{
    private bool _isMoving = false;
    private bool _isCalled = false;
    protected int _maxFloor = 30;
    private int _destinationFloor;
    
    public List<int> Requests { get; set; }

    public Elevator(int x) : base(x)
    {
        Requests = new List<int>();
    }

    public void FloorCall(int floorNum)
    {
        if (!_isMoving)
        {
            if (floorNum < 1 || floorNum > _maxFloor)
            {
                Console.WriteLine($"Invalid floor entry. The valid floors are from 1 to {_maxFloor}.");
            }
            else
            {
                _isCalled = true;
                Requests.Add(floorNum);
                _destinationFloor = floorNum;
                MoveElevator();
            }
        }
        else
        {
            Console.WriteLine("Elevator is already in motion. Please wait for it to arrive.");
        }
    }

    private void MoveElevator()
    {
        if (_isCalled)
        {
            _isMoving = true;
            Console.WriteLine($"\nElevator called to floor {_destinationFloor}. Moving...");
            if (_destinationFloor > _pointY)
            {
                Console.WriteLine("Moving up...");
            }
            else if (_destinationFloor < _pointY)
            {
                Console.WriteLine("Moving down...");
            }

            while (_pointY != _destinationFloor)
            {
                if (_pointY < _destinationFloor)
                {
                    _pointY++;
                }
                else if (_pointY > _destinationFloor)
                {
                    _pointY--;
                }

                Console.WriteLine($"Current floor: {_pointY}");
            }

            Arrived();
        }
    }

    protected void Arrived()
    {
        Console.WriteLine($"\nYou have arrived at the floor {_destinationFloor}.");
        _isMoving = false;
        _isCalled = false;
        Requests.RemoveAt(0);
    }
}
