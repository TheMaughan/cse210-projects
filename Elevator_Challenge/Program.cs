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

vip.ValidKey(true); // Authorizes the VIP Elevator to the 31st floor.
vip.VIPFloorCall(); // This calls the VIP Elevator to the 31st floor.

vip.FloorCall(14); // VIP Elevator can be used to get to any floor.

vip.FloorCall(31);
e2.FloorCall(31);


vip.ValidKey(false);
vip.VIPFloorCall();
vip.FloorCall(31);