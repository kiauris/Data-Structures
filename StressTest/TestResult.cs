namespace DataStructures.StressTest;

public record TestResult(
    string DataStructure,
    string Method,
    int DataSize,
    long TotalTimeMs
    );