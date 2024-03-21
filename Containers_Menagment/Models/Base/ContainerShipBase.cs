using Containers_Menagment.Exceptions;

namespace Containers_Menagment.Models.Base;

public class ContainerShipBase
{
    public List<ContainerBase> CurrentLoadList = [];
    public string Name{ get; set; }

    public double MaxSpeed { get; set; }

    public double MaxWeight { get; set; }

    public int MaxContainerNum 
    { 
        get => CurrentLoadList.Capacity; 
        set 
        { 
            CurrentLoadList.Capacity = value;
        } 
    }

    public ContainerShipBase(string name, double maxSpeed, double maxWeight, int maxContainerNum)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxWeight = maxWeight;
        MaxContainerNum = maxContainerNum;
    }

    public ContainerShipBase(string name, double maxSpeed, double maxWeight, int maxContainerNum, List<ContainerBase> loadList)
    {
        
        Name = name;
        MaxSpeed = maxSpeed;
        MaxWeight = maxWeight;
        MaxContainerNum = maxContainerNum;
        LoadContainer(loadList);
    }

    public void LoadContainer(ContainerBase container)
    {
        if(MaxContainerNum < CurrentLoadList.Count && 
            (CurrentLoadWieght() + container.Weight) >= MaxWeight)
        {
            CurrentLoadList.Add(container);
        }
        else
        {
            throw new OverfillException("Ship is overloaded. Loading Aborted");
        }
            
    }

    public void LoadContainer(List<ContainerBase> loadList)
    {
        if((MaxContainerNum - CurrentLoadList.Count) >= loadList.Count && 
        (CurrentLoadWieght() + LoadWeight(loadList)) >= MaxWeight)
        {
            foreach (ContainerBase container in loadList)
            {
                CurrentLoadList.Add(container);
            }
        }
        else
        {
            throw new OverfillException("Ship is overloaded. Loading Aborted");
        }
    }

    public ContainerBase UnloadContainer(string serialNumber)
    {
        ContainerBase container = CurrentLoadList[FindContainer(serialNumber)];
        CurrentLoadList.RemoveAt(FindContainer(serialNumber));
        return container;
    }

    public void SwitchContainer(string serialNumber, ContainerBase container)
    {
        ContainerBase containerToSwitch = CurrentLoadList[FindContainer(serialNumber)];
        double newWeight = CurrentLoadWieght() - containerToSwitch.Weight + container.Weight;
        if (newWeight < MaxWeight)
        {
            CurrentLoadList[FindContainer(serialNumber)] = container;
        }
    }

    public void MoveToShip(string serialNumber, ContainerShipBase ship)
    {
        ContainerBase containerToMove = CurrentLoadList[FindContainer(serialNumber)];
        if(ship.CurrentLoadWieght() + containerToMove.Weight < ship.MaxWeight && 
        ship.CurrentLoadList.Count + 1 < ship.MaxContainerNum)
        {
            ship.CurrentLoadList.Add(containerToMove);
            CurrentLoadList.Remove(containerToMove);
        }
        else{
            Console.Error.WriteLine("Move Aborted. Not enough space on the other ship");
        }
    }

    public double CurrentLoadWieght(){
        return LoadWeight(CurrentLoadList);
    }

    public static double LoadWeight(List<ContainerBase> containersList){
        double result = 0;
        foreach(ContainerBase container in containersList)
        {
            result += container.Weight;
        }
        return result;
    }

    public override string ToString()
    {
        return "Nazwa: " + Name + " (Max Speed: " + MaxSpeed + "Max Container Number: " + MaxContainerNum + "Max Load: " + MaxWeight;
    }

    private int FindContainer(string serialNumber)
    {
        for (int i = 0; i < CurrentLoadList.Count; i++)
        {
            if(CurrentLoadList[i].SerialNumber == serialNumber)
            {
                return i;
            }
        }
        return -1;
    }

    public void PrintContainersList(){
        int i = 1;
        foreach(ContainerBase container in CurrentLoadList)
            {
                Console.WriteLine(i + ". " + container.ToString());
                i++;
            }
    }

    
}