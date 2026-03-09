using System.Diagnostics;
using DataStructures.DataStructures;

namespace DataStructures.StressTest.Tests;

public class ListOneWayTester : Tester
{
    public override string Name => "One-way list";
    public override List<TestResult> Run()
    {
        // DEBUG
        Console.WriteLine("List One-Way Tester STARTED");
        
        var results = new List<TestResult>();
        int[] size = { 1_000, 10_000, 100_000, 200_000, /*300_000, /*1_000_000, /*10_000_000*/ };

        foreach (var n in size)
        {
            
            // DEBUG
            Console.WriteLine($"Testing {n}...");
            
            // PUSH
            var list = new MyListOneWay(n);
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
            
            // POP BACK
            timer.Restart();
            for (int i = 0; i < n; i++)
                list.PopBack();
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Pop Back",
                n,
                timer.ElapsedMilliseconds
            ));
            
            // POP FRONT
            timer.Restart();
            for (int i = 0; i < n; i++)
                list.PopFront();
            timer.Stop();
            results.Add(new TestResult(
                Name,
                "Pop Front",
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