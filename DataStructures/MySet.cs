namespace DataStructures.DataStructures;

public class MySet
{
    private Node[] _mySet;
    private int[] _chainCount;
    private int _hash;
    
    private int _count;
    
    public MySet(int size = 100_000)
    {
        size = size < 1000 ? 1000 : size;
        _mySet = new Node[size];
        var random = new Random();
        _hash = random.Next(1000, size);
        _count = 0;
        _chainCount = new int[size];
    }

    private int GetHash(int num) => (int)Math.Abs(num % _hash);

    private void Resize()
    {
        if (_count < _mySet.Length * 2) return;
        
        var old = this.GetAllSet();
        var oldSize = _mySet.Length;
        
        _mySet = new Node[oldSize * 2];
        
        var random = new Random();
        _hash = random.Next(1000, oldSize * 2);
        _count = 0;
        _chainCount = new int[oldSize * 2];
        foreach (var num in old)
            Add(num);

    }

    private ref Node? GetNode(int value)
    {
        var index = GetHash(value);
        ref var current = ref _mySet[index];
        while (current != null)
        {
            if (current.GetValue() == value)
                return ref current;
            current = current.GetNext();
        }
        return ref current;
    }
    
    public int Count => _count;
    public int[] GetAllSet()
    {
        var result = new int[_count];
        int index = 0;
        for (int i=0; i < _mySet.Length; i++)
        {
            if (_chainCount[i] == 0) continue;
            var current = _mySet[i];
            while (current != null)
            {
                result[index++] = current.GetValue();
                current = current.GetNext();
            }
        }

        return result;
    }
    
    public int[] GetSortedSet()
    {
        var arr = GetAllSet();
        Array.Sort(arr);
        return arr;
    }

    public void Add(int value)
    {
        Resize();
        var index = GetHash(value);
        if (_chainCount[index] == 0)
        {
            _mySet[index] = new Node(value);
            _chainCount[index] = 1;
            _count++;
            return;
        }

        var current = _mySet[index];
        while (current.GetNext() != null)
        {
            if (current.GetValue() == value)
                return;
            current = current.GetNext();
        }
        if (current.GetValue() == value)
            return;
        
        var newNode = new Node(value);
        newNode.SetPrevious(current);
        current.SetNext(newNode);
        _count++;
        _chainCount[index]++;
    }

    public void Remove(int value)
    {
        var index = GetHash(value);
        
        if (_chainCount[index] == 1)
        {
            _chainCount[index] = 0;
            _count--;
            return;
        }
        
        var node = GetNode(value);
        if (node is null) return;
        if (node.GetPrevious() is not null)
            node.GetPrevious().SetNext(node.GetNext());
        if (node.GetNext() is not null)
            node.GetNext().SetPrevious(node.GetPrevious());
        _count--;
        _chainCount[index]--;
        
    }

    public void Clear()
    {
        for (var i = 0; i < _chainCount.Length; i++)
            _chainCount[i] = 0;
        _count = 0;
    }

    public bool Contains(int value)
    {
        var index = GetHash(value);
        if (_chainCount[index] == 0) return false;
        var current = _mySet[index];
        while (current != null)
        {
            if (current.GetValue() == value)
                return true;
            current = current.GetNext();
        }
        
        return false;
    }

    public MySet Intersect(MySet newSet)
    {
        var result = new MySet();
        for (var i = 0; i < _mySet.Length; i++)
        {
            if (_chainCount[i] == 0) continue;
            var current = _mySet[i];
            while (current != null)
            {
                if (newSet.Contains(current.GetValue()))
                    result.Add(current.GetValue());
                current = current.GetNext();
            }
        }

        return result;
    }

    public MySet Union(MySet newSet)
    {
        var result = new MySet();
        for (var i = 0; i < _mySet.Length; i++)
        {
            if (_chainCount[i] == 0) continue;
            var current = _mySet[i];
            while (current != null)
            {
                result.Add(current.GetValue());
                current = current.GetNext();
            }
        }

        foreach (var num in newSet.GetAllSet())
            result.Add(num);
        
        return result;
    }

    public MySet Except(MySet newSet)
    {
        var result = new MySet();
        for (var i = 0; i < _mySet.Length; i++)
        {
            if (_chainCount[i] == 0) continue;
            var current = _mySet[i];
            while (current != null)
            {
                if (!newSet.Contains(current.GetValue()))
                    result.Add(current.GetValue());
                current = current.GetNext();
            }
        }
        
        return result;
    }

    public bool IsSubsetOf(MySet newSet)
    {
        for (var i = 0; i < _mySet.Length; i++)
        {
            if (_chainCount[i] == 0) continue;
            var current = _mySet[i];
            while (current != null)
            {
                if (!newSet.Contains(current.GetValue()))
                    return false;
                current = current.GetNext();
            }
        }
        
        return true;
    }

    public void Print()
    {
        Console.WriteLine("Current count: " + _count);
        for (var i = 0; i < _mySet.Length; i++)
        {
            if (_chainCount[i] == 0) continue;
            var current = _mySet[i];
            while (current != null)
            {
                Console.Write(current.GetValue() + " ");
                current = current.GetNext();
            }
        }
        Console.WriteLine();
    }
}