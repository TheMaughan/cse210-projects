using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "VDC Technician";
        job1._company = "Mortensen Construction";
        job1._startYear = 2023;
        job1._endYear = 2025;

        //job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Correspondence Agent";
        job2._company = "Aptive Environmental";
        job2._startYear = 2021;
        job2._endYear = 2023;

        //job2.Display();

        Resume resume = new Resume("Bryce");
        resume.AddJob(job1);
        resume.AddJob(job2);
        resume.Display();

    }
}