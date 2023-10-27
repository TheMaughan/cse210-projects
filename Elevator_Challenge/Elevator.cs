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
        // After second thuoght, the commented out code is actually outside of normal elevator behavior.
        // Additional requests are accepcepted while the elevator is moving.
        // if (!_isMoving)
        // {
        if (floorNum < 1 || floorNum > _maxFloor) // Assuming there is no basement floor and limiting the top floor access.
        {
            // Violations are flagged.
            Console.WriteLine($"/!\\ Invalid floor entry /!\\ \nThe valid floors are from 1 to {_maxFloor}.");
            Console.WriteLine($"(⌐■_■)* Error Report\nElevator number: {_pointX}\nAttempted floor: {floorNum}\n");
        }
        else
        {
            _isCalled = true;
            Requests.Add(floorNum);
            _destinationFloor = floorNum;
            MoveElevator();
        }
        //}
        // else
        // {
        //     Console.WriteLine("Elevator is already in motion. Please wait for it to arrive.");
        // }
    }

    private void MoveElevator() // This method moves the elevator and displays the floor number for each floor the elevator passes through.
    {
        if (_isCalled)
        {
            _isMoving = true;
            Console.WriteLine($"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Elevator {_pointX} called to floor {_destinationFloor}.");
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
        Console.WriteLine($"\n ( ^_^)/ You have arrived at the floor {_destinationFloor}.");
        Console.WriteLine($" ====== Elevator {_pointX} is Currently on Floor {_destinationFloor} ====== \n");
        _isMoving = false;
        _isCalled = false;
        Requests.RemoveAt(0);
    }
}
