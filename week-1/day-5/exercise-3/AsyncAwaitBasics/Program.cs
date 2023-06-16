using System.Diagnostics;

namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            int numberOfTasks = 5;
            Console.WriteLine("Performing calculations...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            await PerformCalculations(numberOfTasks);
            stopwatch.Stop();
            Console.WriteLine($"All tasks completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
            Console.ReadLine();
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            Console.WriteLine($"Task {Task.CurrentId} started.");
            await Task.Delay(delayInSeconds * 1000);
            Console.WriteLine($"Task {Task.CurrentId} completed.");
        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete
            Task[] tasks = new Task[numberOfTasks];
            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1);
            }
            await Task.WhenAll(tasks);
        }
    }
}