using System.Diagnostics;
using DataStructures.StressTest.Tests;

namespace DataStructures.StressTest;

public class StressTest
{
    private Tester[] _testers;
    private string _outputFilePath;

    public StressTest(string outputFilePath)
    {
        _outputFilePath = outputFilePath;
        _testers = CreateTesters();
    }
        
    private Tester[] CreateTesters()
    {
        return
        [
            new ListOneWayTester(),
            new ListTwoWayTester(),
            new CycleListTester(),
            new StackTester(),
            new QueueTester()
        ];
    }

    public void Run(bool append)
    {
        if (!append)
            File.WriteAllText(_outputFilePath, "DataStructure,Method,N,TimeMs\n");
        
        // DEBUG
        var timer = new Stopwatch();
        timer.Start();
        
        foreach (var tester in _testers)
        {
            var cycleTimer = Stopwatch.StartNew();
            cycleTimer.Start();
            
            tester.SaveToCSV(_outputFilePath, tester.Run());
            
            // DEBUG
            Console.WriteLine($"Time elapsed for {tester.Name}: {cycleTimer.ElapsedMilliseconds} ms");
        }
        
        // DEBUG
        Console.WriteLine($"Total time: {timer.ElapsedMilliseconds} ms");
    }
}