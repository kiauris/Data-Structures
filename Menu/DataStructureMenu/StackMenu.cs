using DataStructures.DataStructures;

namespace DataStructures.Menu.DataStructureMenu;

public class StackMenu : IDataStructureMenu
{
    public string Title => "Stack";

    private MyStack _stack;

    public StackMenu()
    {
        _stack = new MyStack();
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
            _stack.Print();
            _stack.Push(data);
            _stack.Print();
        }
        else 
            Console.WriteLine("Invalid number");
        Pause();
    }
    private void Pop()
    {
        _stack.Print();
        _stack.Pop();
        _stack.Print();
        Pause();
    }
    private void Peek()
    {
        var element = _stack.Peek();
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
            _stack.Print();
            _stack.SetCapacity(cap);
            _stack.Print();
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
            _stack.Print();
            Console.WriteLine((_stack.Contains(dataSearch)?"List contains ":"List does not contain ") + dataSearch);
        }
        else
        {
            Console.WriteLine("Invalid number");
        }

        Pause();
    }

    private void Clear()
    {
        _stack.Clear();
        Pause();
    }
    private void Print()
    {
        _stack.Print();
        Pause();
    }
}