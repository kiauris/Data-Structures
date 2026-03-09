namespace DataStructures.DataStructures;

public class MyListTwoWay
{
    private Node? _head;
    private Node? _tail;
    private int _count;
    private int _capacity;

    public MyListTwoWay(int capacity = 100)
    {
        _head = null;
        _tail = null;
        _count = 0;
        _capacity = capacity;
    }
    
    public int GetCount() => _count;

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
        Node? current = null;
        if (_count - _capacity < _capacity)
        {
            current = _tail;
            var currentCount = _count;
            while (currentCount > _capacity)
            {
                currentCount--;
                current = current.GetPrevious();
            }
        }
        else
        {
            current = _head;
            var currentCount = 1;
            while (currentCount < _capacity)
            {
                currentCount++;
                current = current.GetNext();
            }
        }
        _tail = current;
        _count = _capacity;
        current.SetNext(null);
    }

    public void PushFront(int data)
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
            _head.SetPrevious(newNode);
            newNode.SetNext(_head);
            _head = newNode;
        }
    }
    public void PushBack(int data)
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
            newNode.SetPrevious(_tail);
            _tail = newNode;
        }
    }

    public void PopFront()
    {
        if (_count == 0) return;
        _head = _head.GetNext();
        _head.SetPrevious(null);
        _count--;
    }
    public void PopBack()
    {
        if (_count == 0) return;
        if (_tail == _head)
        {
            _tail = _head = null;
        }
        else
        {
            _tail = _tail.GetPrevious();
            _tail.SetNext(null);
        }
        _count--;
    }
    private Node? FindNode(int position)
    {
        if (position < 1 || position > _count) return null;
        var current = _head;
        if (position < _count - position)
        {
            var currentCount = 1;
            while (currentCount != position)
            {
                currentCount++;
                current = current.GetNext();
            }
        }
        else
        {
            current = _tail;
            var currentCount = _count;
            while (currentCount > position)
            {
                currentCount--;
                current = current.GetPrevious();
            }
        }
        return current;
    }
    public void Insert(int data, int position)
    {
        if (_count == _capacity || position < 1 || position > _capacity) return;
        if (_count == 0)
        {
            _head = _tail = new Node(data);
            _count++;
            return;
        }
        if (position == 1)
        {
            var newHead = new Node(data);
            newHead.SetNext(_head);
            _head.SetPrevious(newHead);
            _head = newHead;
        }
        else if (position > _count)
        {
            var newTail = new Node(data);
            _tail.SetNext(newTail);
            newTail.SetPrevious(_tail);
            _tail = newTail;
        }
        else
        {
            var originalNode = FindNode(position);
            var newNode = new Node(data);
            // ERROR ->
            originalNode.GetPrevious().SetNext(newNode);
            // <- ERROR
            newNode.SetNext(originalNode);
            newNode.SetPrevious(originalNode.GetPrevious());
            originalNode.SetPrevious(newNode);
        }
        _count++;
    }
    public void Delete(int position)
    {
        if (_count == 0 || position < 1 || position > _capacity) return;
        if (position == 1)
        {
            PopFront();
            return;
        }

        if (position == _count)
        {
            PopBack();
            return;
        }
        var node = FindNode(position);
        node.GetPrevious().SetNext(node.GetNext());
        node.GetNext().SetPrevious(node.GetPrevious());
        _count--;
    }
    
    public bool Contains(int data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.GetValue() == data)
                return true;
            current = current.GetNext();
        }

        return false;
    }

    public void SetNode(int newValue, int position)
    {
        if (position < 1 || position > _count) return;
        var node = FindNode(position);
        node?.SetData(newValue);
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