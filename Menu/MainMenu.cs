using DataStructures.Menu.DataStructureMenu;

namespace DataStructures.Menu;

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