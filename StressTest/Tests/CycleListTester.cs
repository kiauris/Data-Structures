using System.Diagnostics;
using DataStructures.DataStructures;

namespace DataStructures.StressTest.Tests;

public class CycleListTester : Tester
{
    public override string Name => "Cycle List";
    public override List<TestResult> Run()
    {
        // DEBUG
        Console.WriteLine("Cycle List Tester STARTED");
        
        var results = new List<TestResult>();
        int[] size = { 1_000, 10_000, 100_000, 200_000, /*300_000, /*1_000_000, /*10_000_000*/ };

        foreach (var n in size)
        {
            // DEBUG
            Console.WriteLine($"Testing {n}...");
            
            // PUSH
            var list = new MyCycleList(n);
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
                list.Push(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Push",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // POP
            timer.Restart();
            for (int i = 0; i < n; i++)
                list.Pop();
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Pop",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // INSERT
            list.SetCapacity(n*3);
            for (int i = 0; i < n; i++)
                list.Push(i);
            timer.Restart();
            for (int i = 0; i < n; i++)
                list.Insert(i, i * 3 % n);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Insert",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // DELETE
            timer.Restart();
            for (int i = 0; i < n; i++)
                list.Delete(i);
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Delete",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // DEBUG
            Console.WriteLine("\tDONE");
        }
        
        return results;
    }
}