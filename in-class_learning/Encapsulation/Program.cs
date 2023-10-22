Student student1 = new Student("Bob", 20);
// We can access the encapsulated data using the 'DisplayAge()' method.
Console.WriteLine(student1.DisplayAge());

// The following line of code will make the program fail because the "_age" attribute is private, or encapsulated and cannot be accessed directly.
Console.WriteLine(student1._age);