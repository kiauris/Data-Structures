using DataStructures.ConsoleUI.DataStructureMenu;

namespace DataStructures.ConsoleUI;

public class MainMenu
{
    public IDataStructureMenu[] Start()
    {
        return
        [
            new OneWayListMenu(),
            new TwoWayListMenu(),
            new CycleListMenu(),
            new StackMenu(),
            new QueueMenu()
        ];
    }
}