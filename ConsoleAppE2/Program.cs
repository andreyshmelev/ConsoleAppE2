using System;

public class Program
{
    public static void Main(string[] args)
    {
       // using (StreamReader file = new StreamReader("C:\\Users\\Brux\\Downloads\\testE2\\tests\\01"))
        {
            var inputDatasetsCount = int.Parse(Console.ReadLine());
        
            for (int i = 0; i < inputDatasetsCount; i++)
            {
                if (string.IsNullOrEmpty(Console.ReadLine()))
                {
                    var inputSet = Console.ReadLine().Split(" ");

                    var thread_count = int.Parse(inputSet[0]);
                    var job_counter = int.Parse(inputSet[1]);

                    var threadsTimeEnding = new int[thread_count];

                    for (int j = 0; j < job_counter; j++)
                    {
                        var task = Console.ReadLine().Split(" ");

                        var indexofFreeThread = Array.IndexOf(threadsTimeEnding, threadsTimeEnding.Min());

                        var a = int.Parse(task[0]);
                        var b = threadsTimeEnding[indexofFreeThread];


                        threadsTimeEnding[indexofFreeThread] = (a>=b?a:b) + int.Parse(task[1]);
                        Console.Write(threadsTimeEnding[indexofFreeThread] + " ");
                    }
                    Console.WriteLine("");
                }
            }
        }
    }
}

