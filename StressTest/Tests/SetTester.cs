using System.Diagnostics;
using DataStructures.DataStructures;

namespace DataStructures.StressTest.Tests;

public class SetTester : Tester
{
    public override string Name => "Set";
    public override List<TestResult> Run()
    {
        // DEBUG
        Console.WriteLine("Set Tester STARTED");
        
        var results = new List<TestResult>();
        int[] size = { 1_000, 10_000, 100_000, 200_000, 300_000, 1_000_000, /*10_000_000*/ };

        foreach (var n in size)
        {
            // DEBUG
            Console.WriteLine($"Testing {n}...");
            
            // ADD
            var set = new MySet(2 * n + 1);
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
                set.Add(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Add",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // REMOVE
            timer.Restart();
            for (int i = 0; i < n; i++)
                set.Remove(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Remove",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // CONTAINS
            for (int i = 0; i < n; i++)
                set.Add(i);
            timer.Restart();
            for (int i = 0; i < n; i++)
                set.Contains(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Contains",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // DEBUG
            Console.WriteLine("\tDONE");
        }
        
        return results;
    }
}