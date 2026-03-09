namespace DataStructures.Menu;

public class Menu
{
    private readonly MenuItem[] _items;
    private int _selectedIndex;

    public Menu(params MenuItem[] items)
    {
        _items = items;
        _selectedIndex = 0;
    }

    public void Run(Func<bool> isRunning)
    {
        while (isRunning())
        {
            Draw();
            
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    _selectedIndex = (_selectedIndex - 1 + _items.Length) % _items.Length;
                    break;

                case ConsoleKey.DownArrow:
                    _selectedIndex = (_selectedIndex + 1) % _items.Length;
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    _items[_selectedIndex].Action.Invoke();
                    break;
                default: continue;
            }
        }
    }

    public void Draw()
    {
        Console.Clear(); 
        Console.WriteLine("=== Menu ===\n");
        for (int i = 0; i < _items.Length; i++)
        {
            if (i == _selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {_items[i].Title}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {_items[i].Title}");
            }
        }
    }
    
}