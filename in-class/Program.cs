// See https://aka.ms/new-console-template for more information
Console.WriteLine("");

Player ronaldo = new Player("Christian Ronaldo", 7);
Player bob = new Player("Bob Builder", 10);
Player fred = new Player("Fred Himmerdinger", 5);

ronaldo.Display();
bob.Display();
fred.Display();

Console.WriteLine("");

Team worms = new Team("Wild Worms");
Team birds = new Team("Early Birds");

worms.AddPlayer(bob);
worms.AddPlayer(fred);
birds.AddPlayer(ronaldo);

Match game = new Match(worms, birds);
game.DecideWin();

worms.DisplayRoster();
birds.DisplayRoster();

Console.WriteLine("");