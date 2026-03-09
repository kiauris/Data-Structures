namespace DataStructures.DataStructures;

public class MyCycleList
{
    private Node? _head;
    private int _count;
    private int _capacity;

    public MyCycleList(int capacity = 100)
    {
        _head = null;
        _count = 0;
        _capacity = capacity;
    }
    
    public int GetCount() => _count;
    public int? GetHeadValue() => _head?.GetValue();

    public void Push(int data)
    {
        if (_count == _capacity) return;
        _count++;
        if (_head == null)
        {
            _head = new Node(data);
            _head.SetNext(_head);
            _head.SetPrevious(_head);
        }
        else
        {
            var newNode = new Node(data);
            var prev = _head.GetPrevious();
            prev.SetNext(newNode);
            newNode.SetPrevious(prev);
            newNode.SetNext(_head);
            _head.SetPrevious(newNode);
        }
    }

    public void Pop()
    {
        if (_count == 0) return;
        if (_count == 1)
        {
            _head = null;
        }
        else if (_count == 2)
        {
            _head.SetPrevious(_head);
            _head.SetNext(_head);
        }
        else
        {
            var newTail = _head.GetPrevious().GetPrevious();
            newTail.SetNext(_head);
            _head.SetPrevious(newTail);
        }
        _count--;
    }
    public int? Peek() => _head?.GetPrevious()?.GetValue();

    public void SetCapacity(int newCapacity)
    {
        if (newCapacity < 0) throw new ArgumentOutOfRangeException(nameof(newCapacity));
        _capacity = newCapacity;
        if (newCapacity == 0)
        {
            _head = null;
            _count = 0;
            return;
        }
        if (_count > _capacity)
        {
            var newTail = FindNode(newCapacity);
            newTail.SetNext(_head);
            _head.SetPrevious(newTail);
            _count = _capacity;
        }
    }

    private Node? FindNode(int position)
    {
        if (position < 1 || position > _count || _head == null) return null;
        var current = _head;
        var currentCount = 1;
        while (currentCount < position)
        {
            current = current.GetNext();
            currentCount++;
        }
        return current;
    }

    public void Insert(int data, int position)
    {
        if (_count == _capacity || position < 1 || position > _capacity) return;
        if (_count == 0)
        {
            Push(data);
        }
        else if (position == 1)
        {
            var newNode = new Node(data);
            newNode.SetPrevious(_head.GetPrevious());
            newNode.SetNext(_head);
            _head.GetPrevious().SetNext(newNode);
            _head.SetPrevious(newNode);
            _head = newNode;
            _count++;
        }
        else
        {
            var newNode = new Node(data);
            if (position > _count)
                position = _count + 1;
            var prev = FindNode(position - 1);
            newNode.SetPrevious(prev);
            newNode.SetNext(prev.GetNext());
            prev.GetNext().SetPrevious(newNode);
            prev.SetNext(newNode);
            _count++;
        }
    }

    public void Delete(int position)
    {
        if (_count == 0 || position < 1 || position > _count) return;
        if (_count == 1 || position == _count)
        {
            Pop();
        }
        else
        {
            var prev = FindNode((position - 1) == 0 ? _count : position - 1);
            var next = prev.GetNext().GetNext();
            prev.SetNext(next);
            next.SetPrevious(prev);
            _count--;
            if (position == 1)
                _head = next;
        }
    }

    public bool Contains(int data)
    {
        if (_head.GetValue() == data) return true;
        var current = _head.GetNext();
        while (current != _head)
        {
            if (current.GetValue() == data)
                return true;
            current = current.GetNext();
        }
        return false;
    }

    public void SetNode(int newValue, int position)
    {
        if (_count == 0 || position < 1 || position > _count) return;
        var node = FindNode(position);
        node?.SetData(newValue);
    }

    public void Print()
    {
        Console.WriteLine("Capacity: " + _capacity + "\nCurrent count: " + _count);
        if (_head is null) return;
        Console.Write(_head.GetValue() + " ");
        var current = _head.GetNext();
        while (current != _head)
        {
            Console.Write(current.GetValue() + " ");
            current = current.GetNext();
        }
        Console.WriteLine();
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
        _capacity = 100;
    }

}