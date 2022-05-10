using System;

public class Program
{
    public static void Main(string[] args)
    {
        using (StreamReader file = new StreamReader("C:\\Users\\Brux\\Downloads\\testE2\\tests\\01"))

        {

            var inputDatasetsCount = int.Parse(file.ReadLine());
            for (int i = 0; i < inputDatasetsCount; i++)
            {
                if (string.IsNullOrEmpty(file.ReadLine()))
                {
                    var inputSet = file.ReadLine().Split(" ");

                    var thread_count = int.Parse(inputSet[0]);
                    var job_counter = int.Parse(inputSet[1]);
                    Console.WriteLine("thread_count: " + thread_count);
                    Console.WriteLine("job_counter: " + job_counter);
                    
                    int lasttime = 0;

                    var resultCollection = new int[job_counter];


                    int howmanyskip = 0;
                    for (int j = 0; j < job_counter; j++)
                    {
                        var task = file.ReadLine().Split(" ");

                        int currentStartTime = int.Parse(task[0]);
                        int currentPeriod = int.Parse(task[1]);


                        // если есть свободные потоки на начало 
                        if (thread_count>0)
                        {
                            thread_count--;
                            resultCollection[j] = currentStartTime + currentPeriod ;
                        }
                        else // если нет свободных потоков на начало. то ждем того который максимально рано закончит, то есть выбираем минимум времени
                        {

                            int minimumEndTimeForAnyThread = resultCollection.Skip(howmanyskip).Take(j - howmanyskip).Min(); // вот этот максимально рано закончит
                            Console.WriteLine("освободился поток в : " + minimumEndTimeForAnyThread);
                            Console.WriteLine("howmanyskip : " + howmanyskip);
                            resultCollection[j] = minimumEndTimeForAnyThread + currentPeriod;
                            howmanyskip++;
                        }

                    }
                    Console.WriteLine(String.Join(" ", resultCollection));

                    Console.WriteLine("\n");
                }
            }
        }
    }
}
