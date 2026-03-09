using System.Text;

namespace DataStructures.StressTest.Tests;

public abstract class Tester
{
    public abstract string Name { get; }
    public abstract List<TestResult> Run();

    public void SaveToCSV(string path, List<TestResult> testResults)
    {
        var sb = new StringBuilder();
        // sb.AppendLine("DataStructure,Method,N,TimeMs");

        foreach (var result in testResults)
            sb.AppendLine($"{result.DataStructure}," +
                          $"{result.Method}," +
                          $"{result.DataSize}," +
                          $"{result.TotalTimeMs},"
                          );
        
        File.AppendAllText(path, sb.ToString());
    }
}