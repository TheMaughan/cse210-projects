// See https://aka.ms/new-console-template for more information


Elevator e1 = new Elevator(1);
Elevator e2 = new Elevator(2);
VIP vip = new VIP(3);

e1.FloorCall(20);
e1.FloorCall(18);
e1.FloorCall(18);


//Testing behavior
e2.FloorCall(3);
e2.FloorCall(300);
e2.FloorCall(3);

vip.VIPFloorCall(); // Someone on the 31st floor called the VIP elevator.
//vip.FloorCall(31); // Oops, you need to use the your Key Card again!
vip.FloorCall(14); // VIP Elevator can be used to get to any floor.

vip.ValidKey(true); // Authorizes the VIP Elevator to the 31st floor.
vip.FloorCall(31); // Someone in the VIP elevator requested the 31st floor (shouldn't work, no new keycard)
vip.FloorCall(30); // VIP leaves the VIP floor, _keyCard should now be false.
vip.FloorCall(31);

e2.FloorCall(31); // Other Elevators cannot access the 31st floor.

//vip.ValidKey(false);
vip.VIPFloorCall();// Someone on the 31st floor called the VIP elevator.
