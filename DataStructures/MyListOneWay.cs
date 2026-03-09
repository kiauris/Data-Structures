namespace DataStructures.DataStructures;

public class MyListOneWay
{
    private Node? _head;
    private Node? _tail;
    private int _capacity;
    private int _count;
    
    public MyListOneWay(int capacity = 100)
    {
        _head = null;
        _tail = null;
        _capacity = capacity;
        _count = 0;
    }
    
    public int GetCount() => _count;
    public int? GetHeadValue() => _head?.GetValue();
    public int? GetTailValue() => _tail?.GetValue();
    
    public int? GetValueAt(int index)
    {
        if (index < 1 || index > _capacity || _count == 0) return null;
        var current = _head;
        while (index != 1)
        {
            current = current.GetNext();
            index--;
        }
        return current.GetValue();
    }

    public void SetCapacity(int newCapacity)
    {
        if (newCapacity < 0) throw new ArgumentOutOfRangeException(nameof(newCapacity));
        _capacity = newCapacity;
        if (_count <= newCapacity) return;
        if (newCapacity == 0)
        {
            _count = 0;
            return;
        }
        _tail = FindNode(newCapacity);
        _count = _capacity;
        _tail.SetNext(null);
    }

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

    public void PopFront()
    {
        if (_count == 0) return;
        _count--;
        if (_tail == _head)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.GetNext();
        }
    }
    public void PopBack()
    {
        if (_tail == null) return;
        _count--;
        if (_tail == _head)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            var newTail = _head;
            while (newTail.GetNext() != _tail)
                newTail = newTail.GetNext();
            newTail.SetNext(null);
            _tail = newTail;
        }
    }

    private Node? FindNode(int position)
    {
        if (position < 1 || position > _count) return null;
        var current = _head;
        var currentPosition = 1;
        while (currentPosition != position)
        {
            current = current.GetNext();
            currentPosition++;
        }
        return current;
    }
    public void Insert(int data, int position)
    {
        if (_count == _capacity || position < 1 || position > _capacity) return;
        if (_count == 0)
        {
            _head = new Node(data);
            _tail = _head;
            _count++;
            return;
        }
        if (position == 1)
        {
            var newHead = new Node(data);
            newHead.SetNext(_head);
            _head = newHead;
        }
        else if (position > _count)
        {
            var newTail = new Node(data);
            _tail.SetNext(newTail);
            _tail = newTail;
        }
        else
        {
            var prev = FindNode(position - 1);
            var newNode = new Node(data);
            newNode.SetNext(prev.GetNext());
            prev.SetNext(newNode);
        }
        _count++;
    }

    public void Delete(int position)
    {
        if (_count == 0 || position < 1 || position > _count) return;
        if (position == _count)
        {
            PopBack();
        }
        else if (position == 1)
        {
           _head = _head.GetNext();
           _count--;
        }
        else
        {
            var prev = FindNode(position - 1);
            var next = prev.GetNext().GetNext();
            prev.SetNext(next);
            _count--;
        }
        
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
        if (position == _count)
        {
            _tail.SetData(newValue);
            return;
        }
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