using System.Diagnostics;
using DataStructures.DataStructures;

namespace DataStructures.StressTest.Tests;

public class StackTester : Tester
{
    public override string Name => "Stack";
    public override List<TestResult> Run()
    {
        // DEBUG
        Console.WriteLine("Stack Tester STARTED");
        
        var results = new List<TestResult>();
        int[] size = { 1_000, 10_000, 100_000, 200_000, /*300_000, /*1_000_000, /*10_000_000*/ };

        foreach (var n in size)
        {
            // DEBUG
            Console.WriteLine($"Testing {n}...");
            
            // PUSH
            var stack = new MyStack(n);
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
                stack.Push(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Push",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // FIND
            timer.Restart();
            for (int i = 0; i < n; i++)
                stack.Contains(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Find",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // POP
            timer.Restart();
            for (int i = 0; i < n; i++)
                stack.Pop();
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Pop",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // DEBUG
            Console.WriteLine("\tDONE");
        }
        
        return results;
    }
}