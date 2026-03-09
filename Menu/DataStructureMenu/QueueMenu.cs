using DataStructures.DataStructures;

namespace DataStructures.Menu.DataStructureMenu;

public class QueueMenu : IDataStructureMenu
{
    public string Title => "Queue";

    private MyQueue _queue;

    public QueueMenu(int capacity = 100)
    {
        _queue = new MyQueue(capacity);
    }
    public void Run()
    {
        bool running = true;
        
        var menu = new Menu(
            new MenuItem("Push", Push),
            new MenuItem("Pop", Pop),
            new MenuItem("Peek", Peek),
            new MenuItem("Check if list contains element", Contains),
            new MenuItem("Set capacity", SetCapacity),
            new MenuItem("Print", Print),
            new MenuItem("Clear", Clear),
            new MenuItem("Back", () => running = false)
        );
        
        menu.Run(() => running);
    }
    
    private static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
    private void Push()
    {
        Console.Write("Enter new data: ");
        if (int.TryParse(Console.ReadLine(), out int data))
        {
            _queue.Print();
            _queue.Push(data);
            _queue.Print();
        }
        else 
            Console.WriteLine("Invalid number");
        Pause();
    }
    private void Pop()
    {
        _queue.Print();
        _queue.Pop();
        _queue.Print();
        Pause();
    }
    private void Peek()
    {
        var element = _queue.Peek();
        if (element is not null)
            Console.WriteLine("Element on top " + element);
        else
            Console.WriteLine("Nothing to peek");
        Pause();
    }
    private void SetCapacity()
    {
        Console.Write("Enter new capacity: ");
        if (int.TryParse(Console.ReadLine(), out int cap))
        {
            _queue.Print();
            _queue.SetCapacity(cap);
            _queue.Print();
        }
        else
        {
            Console.WriteLine("Invalid number");
        }

        Pause();
    }
    private void Contains()
    {
        Console.Write("Enter data to check: ");
        if (int.TryParse(Console.ReadLine(), out int dataSearch))
        {
            _queue.Print();
            Console.WriteLine((_queue.Contains(dataSearch)?"List contains ":"List does not contain ") + dataSearch);
        }
        else
        {
            Console.WriteLine("Invalid number");
        }

        Pause();
    }

    private void Clear()
    {
        _queue.Clear();
        Pause();
    }
    private void Print()
    {
        _queue.Print();
        Pause();
    }
}