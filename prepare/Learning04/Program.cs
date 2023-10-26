using System;

//Name, textBookSection, Proplems, Topic(Default value = "MATH ASSIGNMENT")
MathAssignment math1 = new("Bob", "Saxons Book 8 Section 1.7", "3-5, 7, 10");

//Name, Title, Topic(Default value = "WRITING ASSIGNMENT")
WritingAssignment write1 = new(math1.GetName(), "Harry Potter book report");

Console.WriteLine(math1.GetHomeworkList());
Console.WriteLine(write1.GetWritingInformation());


MathAssignment math2 = new("Fred", "Section 7.3", "8-19", "Fractions");
WritingAssignment write2 = new(math2.GetName(), "Celery Cures Cancer", "Medical Science");


Console.WriteLine(math2.GetHomeworkList());
Console.WriteLine(write2.GetWritingInformation());