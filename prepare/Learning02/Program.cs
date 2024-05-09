using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Microsoft";
        job1.Display();
        job2.Display();

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs[0]._jobTitle = "Chief Editor";
        Console.WriteLine(myResume._jobs[0]._jobTitle);
    }

}