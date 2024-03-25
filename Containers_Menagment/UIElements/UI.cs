
using Containers_Menagment.Models.Base;
using Containers_Menagment.Models.Containers;

namespace Containers_Menagment.UIElements;

class UI
{
    public List<ContainerShipBase> ListOfShips = [];

    public List<ContainerBase> ListOfContainers = [];

    int NumberOfOptions = 1;

    public void Start()
    {   
        string? UserInput;
        do
        {
            Console.Clear();
            PrintShipList();
            PrintContainersList();
            PrintMenu();

            do
            {   
                Console.WriteLine("Enter choice: ");
                UserInput = Console.ReadLine();
                if(Convert.ToInt32(UserInput) > NumberOfOptions)
                {
                    Console.WriteLine("Wrong input");
                }
            }
            while(Convert.ToInt32(UserInput) > NumberOfOptions);

            switch(UserInput)
            {
                case "1":
                    Console.Clear();
                    AddShip(GetShipFromUser());
                    break;
                case "2":
                    Console.Clear();
                    ChooseContainerType();
                    break;
                case "3":
                    Console.Clear();
                    DeleteShip();
                    break;
                case "4":
                    Console.Clear();
                    UnloadContainer();
                    break;
                case "5":
                    Console.Clear();
                    MoveContainer();
                    break;
                case "6":
                    Console.Clear();
                    DeleteContainer();
                    break;
                case "7":
                    Console.Clear();
                    LoadContainer();
                    break;
            }
        }
        while(UserInput != "0");
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
        Console.WriteLine("Menu: ");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Add Ship");
        if(ListOfShips.Count != 0)
        {
            Console.WriteLine("2. Add Container");
            Console.WriteLine("3. Delete Ship");
            Console.WriteLine("4. Unload Container from the ship");
            Console.WriteLine("5. Move Container from one ship to another");
            NumberOfOptions = 5;
            if(ListOfContainers.Count != 0)
            {
                Console.WriteLine("6. Delete Container");
                Console.WriteLine("7. Load Container on ship");
                NumberOfOptions = 7;
            }
        }
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

    private static ContainerShipBase GetShipFromUser(){
        Console.WriteLine("----------Add Ship----------");
        Console.WriteLine("Enter name: ");
        string? shipName = Console.ReadLine();
        Console.WriteLine("Enter max speed: ");
        double maxSpeed = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter max weight: ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter max container count: ");
        int maxContainerNum = Convert.ToInt32(Console.ReadLine());

        return new ContainerShipBase(shipName, maxSpeed, maxWeight, maxContainerNum);
    }

    private void ChooseContainerType(){
        Console.WriteLine("----------Choose Container's Type----------");
        Console.WriteLine("1. Fluid Container");
        Console.WriteLine("2. Freezer Container");
        Console.WriteLine("3. Gas Container");
        List<string> acceptedOptions = ["1", "2", "3"];
        string? containerType;
        do
        {
        containerType = Console.ReadLine();
        }while(!acceptedOptions.Contains(containerType));
        switch(containerType)
        {
            case "1":
                AddContainer(GetUserFluidContainer());
                break;
            case "2":
                AddContainer(GetUserFreezerContainer());
                break;
            case "3":
                AddContainer(GetUserGasContainer());
                break;
        }
    }

    private static FluidContainer GetUserFluidContainer()
    {
        Console.WriteLine("----------Add Container----------");
        Console.WriteLine("Enter weight of load (kg):");
        double weightOfLoad = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter height (cm): ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter container weight (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter depth (cm): ");
        double depth = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Max Weight of Load (kg): ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter name of the products in container: ");
        ProductBase product = new(Console.ReadLine());
        Console.WriteLine("Is the Load Hazardous(y/n): ");
        bool isHazardous = false;
        if(Console.ReadLine().ToLower() == "y")
        {
            isHazardous = true;
        }

        return new FluidContainer(weightOfLoad, height, weight, depth, maxWeight, product, isHazardous);
    
    }

    private FreezerContainer GetUserFreezerContainer()
    {
        Console.WriteLine("----------Add Container----------");
        Console.WriteLine("Enter weight of load (kg):");
        double weightOfLoad = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter height (cm): ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter container weight (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter depth (cm): ");
        double depth = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Max Weight of Load (kg): ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter name of the products in container: ");
        ProductBase product = new(Console.ReadLine());
        Console.WriteLine("Enter current temperature: ");
        double currentTemperature = Convert.ToDouble(Console.ReadLine());

        return new FreezerContainer(weightOfLoad, height, weight, depth, maxWeight, product, currentTemperature);
    }

    private static GasContainer GetUserGasContainer()
    {
        Console.WriteLine("----------Add Container----------");
        Console.WriteLine("Enter weight of load (kg):");
        double weightOfLoad = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter height (cm): ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter container weight (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter depth (cm): ");
        double depth = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Max Weight of Load (kg): ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter name of the products in container: ");
        ProductBase product = new(Console.ReadLine());
        Console.WriteLine("Enter current pressure: ");
        double currentPressure = Convert.ToDouble(Console.ReadLine());

        return new GasContainer(weightOfLoad, height, weight, depth, maxWeight, product, currentPressure);
    }

    private void DeleteShip()
    {
        PrintShipList();
        Console.WriteLine("Choose ship to delete (id): ");
        int idToDelete = Convert.ToInt32(Console.ReadLine()) - 1;
        ListOfShips.RemoveAt(idToDelete);
    }

    private void UnloadContainer()
    {
        PrintShipsAndLoadedContainers();
        Console.WriteLine("Choose ship (id): ");
        int id = Convert.ToInt32(Console.ReadLine()) - 1;
        ListOfShips[id].PrintContainersList();
        Console.WriteLine("Enter serial number of container to unload: ");
        ContainerBase unloadedContainer = ListOfShips[id].UnloadContainer(Console.ReadLine());
        AddContainer(unloadedContainer);    
    }

    private void MoveContainer()
    {
        PrintShipsAndLoadedContainers();
        Console.WriteLine("Choose ship from which you would like to take container: ");
        int idSrc = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine("Enter serial number of container to move: ");
        string serialNumber = Console.ReadLine();
        Console.WriteLine("Choose ship to move to: ");
        int idDst = Convert.ToInt32(Console.ReadLine()) - 1;
        ListOfShips[idSrc].MoveToShip(serialNumber, ListOfShips[idDst]);
    }

    private void DeleteContainer(){
        PrintContainersList();
        Console.WriteLine("Choose container to delete (id): ");
        int idToDelete = Convert.ToInt32(Console.ReadLine()) - 1;
        ListOfContainers.RemoveAt(idToDelete);
    }

    private void LoadContainer(){
        PrintContainersList();
        Console.WriteLine("Choose container to load (id): ");
        int idContainer = Convert.ToInt32(Console.ReadLine()) - 1;
        PrintShipList();
        Console.WriteLine("Choose ship to load (id): ");
        int idShip = Convert.ToInt32(Console.ReadLine()) - 1;
        ListOfShips[idShip].LoadContainer(ListOfContainers[idContainer]);
    }

    private void PrintShipsAndLoadedContainers()
    {
        int i = 1;
        foreach(ContainerShipBase ship in ListOfShips)
        {
            Console.WriteLine(i + ". " + ship.ToString());
            Console.WriteLine("Containers loaded: ");
            ship.PrintContainersList();
            i++;
        }
    }
}
