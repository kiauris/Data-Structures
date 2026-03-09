namespace DataStructures.DataStructures;

public class Node
{
    private int value;
    private Node? next;
    private Node? previous;

    public Node(int data)
    {
        value = data;
        next = null;
        previous = null;
    }
        
    public int GetValue() => value;
    public Node GetNext() => next;
    public Node? GetPrevious() => previous;
    public void SetNext(Node? nextNode) => next = nextNode ?? null;
    public void SetPrevious(Node? previousNode) => previous = previousNode ?? null;
    public void SetData(int data) => value = data;
}