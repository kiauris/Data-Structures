namespace DataStructures.DataStructures;

public class MyStack
{
    private Node? _head;
    private Node? _tail;
    private int _count;
    private int _capacity;

    public MyStack(int capacity = 100)
    {
        _head = null;
        _tail = null;
        _capacity = capacity;
        _count = 0;
    }
    
    public int GetCount() => _count;

    public void Push(int value)
    {
        if (_count == _capacity) return;
        _count++;
        if (_head == null)
        {
            _head = new Node(value);
            _tail = _head;
        }
        else
        {
            var newNode = new Node(value);
            newNode.SetPrevious(_tail);
            _tail.SetNext(newNode);
            _tail = newNode;
        }
    }

    public void Pop()
    {
        if (_count == 0) return;
        if (_count == 1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.GetPrevious();
            _tail.SetNext(null);
        }
        _count--;
    }

    public bool Contains(int value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.GetValue() == value)
                return true;
            current = current.GetNext();
        }
        return false;
    }

    public int? Peek() => _tail?.GetValue();

    public void SetCapacity(int newCapacity)
    {
        if (newCapacity < 0) throw new ArgumentOutOfRangeException(nameof(newCapacity));
        _capacity = newCapacity;
        if (_count <= newCapacity) return;

        if (newCapacity == 0)
        {
            _head = _tail = null;
            _count = 0;
            return;
        }
        var current = _head;
        var currentCount = 1;
        while (currentCount < newCapacity)
        {
            currentCount++;
            current = current.GetNext();
        }
        _tail = current;
        _count = _capacity;
        current.SetNext(null);
    }

    public void Clear()
    {
        _head = _tail = null;
        _capacity = 100;
        _count = 0;
    }
    public void Print()
    {
        Console.WriteLine("Capacity: " + _capacity + "\nCurrent count: " + _count);
        var current = _head;
        while (current != null)
        {
            Console.Write(current.GetValue() + " ");
            current = current.GetNext();
        }
        Console.WriteLine();
    }

}