namespace DataStructures.DataStructures;

public class MyQueue
{
    private Node? _head;
    private Node? _tail;
    private int _count;
    private int _capacity;

    public MyQueue(int capacity = 100)
    {
        _head = _tail = null;
        _capacity = capacity;
        _count = 0;
    }
    
    public int GetCount() => _count;

    public void Push(int data)
    {
        if (_count == _capacity) return;
        _count++;
        if (_head == null)
        {
            _head = _tail = new Node(data);
        }
        else
        {
            var newNode = new Node(data);
            _tail.SetNext(newNode);
            _tail = newNode;
        }
    }

    public void Pop()
    {
        if (_head is null) return;
        if (_count == 1)
            _head = _tail = null;
        else 
            _head = _head.GetNext();
        _count--;
    }

    public int? Peek() => _tail?.GetValue();

    public bool Contains(int data)
    {
        if (_head is null) return false;
        var current = _head;
        while (current != null)
        {
            if (current.GetValue() == data) return true;
            current = current.GetNext();
        }
        return false;
    }

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
        _count = newCapacity;
        current.SetNext(null);
    }

    public void Clear()
    {
        _head = _tail = null;
        _count = 0;
        _capacity = 100;
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