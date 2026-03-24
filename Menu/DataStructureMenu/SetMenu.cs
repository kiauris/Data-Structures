using DataStructures.DataStructures;

namespace DataStructures.Menu.DataStructureMenu;

public class SetMenu : IDataStructureMenu
{
    public string Title => "Set";

    private MySet[] _set;
    private int _currentSetIndex;

    public SetMenu()
    {
        _set = new MySet[10];
        for (int i = 0; i < 10; i++)
            _set[i] = new MySet();
        _currentSetIndex = 0;
    }

    public void Run()
    {
        bool running = true;
        var menu = new Menu(
            new MenuItem("Print", Print),
            new MenuItem("Change set", ChangeSet),
            new MenuItem("Add", Add),
            new MenuItem("Remove", Remove),
            new MenuItem("Clear", Clear),
            new MenuItem("Check if set contains element", Contains),
            new MenuItem("Intersect current set with another set", Intersect),
            new MenuItem("Union current set and another set", Union),
            new MenuItem("Except another set from current set", Except),
            new MenuItem("Check if current set is a subset of another set", IsSubsetOf),
            new MenuItem("Back", () => running = false)
        );
        menu.Run(() => running);
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    private static int? GetDataFromUser(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int data))
        {
            if (data < min || data > max)
            {
                Console.WriteLine("Invalid number");
                return null;
            }

            return data;
        }
        else
        {
            Console.WriteLine("Invalid number");
            return null;
        }
    }
    
    private void PrintSetCurrentAndIndex(int index)
    {
        Console.Write($"First set {_currentSetIndex + 1} : ");
        _set[_currentSetIndex].Print();
        Console.WriteLine($"Second set {index + 1} : ");
        _set[index].Print();
        Console.WriteLine();
    }

    private void Add()
    {
        var data = GetDataFromUser("Enter new data: ");
        if (data == null) return;
        _set[_currentSetIndex].Print();
        _set[_currentSetIndex].Add((int)data);
        _set[_currentSetIndex].Print();

        Pause();
    }

    private void Remove()
    {
        var data = GetDataFromUser("Enter element to remove: ");
        if (data == null) return;
        _set[_currentSetIndex].Print();
        _set[_currentSetIndex].Remove((int)data);
        _set[_currentSetIndex].Print();
        Pause();
    }

    private void Clear()
    {
        _set[_currentSetIndex].Print();
        _set[_currentSetIndex].Clear();
        _set[_currentSetIndex].Print();

        Pause();
    }

    private void Contains()
    {
        var data = GetDataFromUser("Enter data to check: ");
        if (data == null) return;

        _set[_currentSetIndex].Print();
        Console.WriteLine((_set[_currentSetIndex].Contains((int)data) ? "Set contains " : "Set does not contain ") +
                          data);
        Pause();
    }

    private void Intersect()
    {
        var data = GetDataFromUser("Enter id of second set: ", 1, 10);
        if (data == null) return;
        var secondSet = (int)data - 1;
        PrintSetCurrentAndIndex(secondSet);
        Console.WriteLine("Result: ");
        _set[_currentSetIndex].Intersect(_set[secondSet]).Print();
        PrintSetCurrentAndIndex(secondSet);

        Pause();
    }

    private void Union()
    {
        var data = GetDataFromUser("Enter id of second set: ", 1, 10);
        if (data == null) return;
        var secondSet = (int)data - 1;
        PrintSetCurrentAndIndex(secondSet);
        Console.WriteLine("Result: ");
        _set[_currentSetIndex].Union(_set[secondSet]).Print();
        PrintSetCurrentAndIndex(secondSet);

        Pause();
    }

    private void Except()
    {
        var data = GetDataFromUser("Enter id of second set: ", 1, 10);
        if (data == null) return;
        var secondSet = (int)data - 1;
        PrintSetCurrentAndIndex(secondSet);
        Console.WriteLine("Result: ");
        _set[_currentSetIndex].Except(_set[secondSet]).Print();
        PrintSetCurrentAndIndex(secondSet);

        Pause();
    }

    private void IsSubsetOf()
    {
        var data = GetDataFromUser("Enter id of second set: ", 1, 10);
        if (data == null) return;
        var secondSet = (int)data - 1;
        PrintSetCurrentAndIndex(secondSet);
        Console.WriteLine(_set[_currentSetIndex].IsSubsetOf(_set[secondSet])
            ? $"Set {_currentSetIndex + 1} IS a subset of set {secondSet + 1}"
            : $"Set {_currentSetIndex + 1} is NOT a subset of set {secondSet + 1}");

        Pause();
    }

    private void ChangeSet()
    {
        var data = GetDataFromUser("Enter set ID(1-10): ");
        if (data == null) return;
        _currentSetIndex = (int)data - 1;

        Pause();
    }

    private void Print()
    {
        Console.WriteLine("Set " + (_currentSetIndex + 1));
        _set[_currentSetIndex].Print();
        Pause();
    }
}