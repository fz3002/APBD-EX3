using System.ComponentModel;
using Containers_Menagment.Models.Base;

namespace Containers_Menagment.UI;

class UI
{
    public List<ContainerShipBase> ListOfShips = [];

    public List<ContainerBase> ListOfContainers = [];

    public UI(){
        PrintShipList();
        PrintContainersList();
        PrintMenu();
    }

    private void PrintShipList()
    {
        Console.WriteLine("List of ships");
        foreach (ContainerShipBase ship in ListOfShips)
        {
            Console.WriteLine(ship);
        }
        if(ListOfShips.Count == 0)
        {
            Console.WriteLine("Brak");
        }

    }

    private void PrintMenu()
    {
        int NumberOfOptions = 1;
        Console.WriteLine("Menu: ");
        Console.WriteLine("1. Add Ship");
        if(ListOfShips.Count != 0)
        {
            Console.WriteLine("2. Add Container");
            Console.WriteLine("3. Delete Ship");
            Console.WriteLine("4. Unload Container form the ship");
            Console.WriteLine("5. Move Container from one ship to another");
            NumberOfOptions = 5;
            if(ListOfContainers.Count != 0)
            {
                Console.WriteLine("6. Delete Container");
                Console.WriteLine("7. Load Container on ship");
                NumberOfOptions = 7;
            }
        }
        //TODO: UserInput handling for menu
    }

    private void PrintContainersList()
    {
        Console.WriteLine("List of containers");
        foreach (ContainerBase container in ListOfContainers)
        {
            Console.WriteLine(container);
        }
        if(ListOfContainers.Count == 0)
        {
            Console.WriteLine("Brak");
        }
    }

    private void AddShip(ContainerShipBase ship)
    {
        ListOfShips.Add(ship);
    }

    private void AddContainer(ContainerBase container){
        ListOfContainers.Add(container);
    }

}
