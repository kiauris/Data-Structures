using DataStructures.DataStructures;

namespace DataStructures.Menu.DataStructureMenu;

public class OneWayListMenu : IDataStructureMenu
{
    public string Title => "One-way List";

    private MyListOneWay _list;
    
    public OneWayListMenu()
    {
        _list = new MyListOneWay();
    }

    public void Run()
    {
        bool running = true;

        var menu = new Menu(
            new MenuItem("Push", Push),
            new MenuItem("Pop", Pop),
            new MenuItem("Insert", Insert),
            new MenuItem("Delete", Delete),
            new MenuItem("Print", Print),
            new MenuItem("Set element", SetElement),
            new MenuItem("Set capacity", SetCapacity),
            new MenuItem("Check if list contains element", Contains),
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
            _list.Print();
            _list.Push(data);
            _list.Print();
        }
        else 
            Console.WriteLine("Invalid number");
        Pause();
    }
    private void Pop()
    {
        _list.Print();
        _list.PopBack();
        _list.Print();
        Pause();
    }
    
    private void Insert()
    {
        _list.Print();
        Console.Write("Enter position: ");
        if (!int.TryParse(Console.ReadLine(), out int positionInsert))
            Console.WriteLine("Invalid number");
        Console.Write("Enter value: ");
        if (int.TryParse(Console.ReadLine(), out int valueInsert))
        {
            _list.Print();
            _list.Insert(valueInsert, positionInsert);
            _list.Print();
        }
        else
        {
            Console.WriteLine("Invalid number");
        }

        Pause();
    }
    
    private void Delete()
    {
        Console.Write("Enter position: ");
        if (int.TryParse(Console.ReadLine(), out int positionDelete))
        {
            _list.Print();
            _list.Delete(positionDelete);
            _list.Print();
        }
        else
        {
            Console.WriteLine("Invalid number");
        }

        Pause();
    }

    private void SetElement()
    {
        _list.Print();
        Console.Write("Enter position: ");
        if (!int.TryParse(Console.ReadLine(), out int positionSet))
            Console.WriteLine("Invalid number");
        Console.Write("Enter value: ");
        if (int.TryParse(Console.ReadLine(), out int valueSet))
        {
            _list.Print();
            _list.SetNode(valueSet, positionSet);
            _list.Print();
        }
        else
        {
            Console.WriteLine("Invalid number");
        }
        Pause();
    }
    
    private void SetCapacity()
    {
        Console.Write("Enter new capacity: ");
        if (int.TryParse(Console.ReadLine(), out int cap))
        {
            _list.Print();
            _list.SetCapacity(cap);
            _list.Print();
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
            _list.Print();
            Console.WriteLine((_list.Contains(dataSearch)?"List contains ":"List does not contain ") + dataSearch);
        }
        else
        {
            Console.WriteLine("Invalid number");
        }

        Pause();
    }
    private void Print()
    {
        _list.Print();
        Pause();
    }
    
    private void Clear()
    {
        _list.Clear();
        Pause();
    }
}