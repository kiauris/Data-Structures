using DataStructures.Menu;
using DataStructures.StressTest;
using DataStructures.StressTest.Tests;

public class Program
{
    public  static void RunPresentation()
    {
        bool running = true;
        
        var dataStruct = new MainMenu().Start();
        
        List<MenuItem> menuItems = new List<MenuItem>();
        foreach (var item in dataStruct)
            menuItems.Add(new MenuItem(item.Title, item.Run));
        menuItems.Add(new MenuItem("Exit", () => running = false));
        
        var menu = new Menu(menuItems.ToArray());
        menu.Run(() => running);
    }

    public static void RunStressTest(string outputFilePath, bool append)
    {
        var test = new StressTest(outputFilePath);
        test.Run(append);
    }
    
    public static void Main(string[] args)
    {
        RunPresentation();
    }
}