using System.Runtime.InteropServices;

namespace Containers_Menagment.Models.Base;

public class ContainerShipBase
{
    List<ContainerBase> CurrentLoadList = [];
    public string Name{ get; set; }

    public string RegistrationNumber{ get; set; }

    public string MotherPort{ get; set; }

    public string BuildYear{ get; set; }

    public ContainerShipBase(string name, string registrationNumber, string motherPort, string buildYear)
    {
        Name = name;
        RegistrationNumber = registrationNumber;
        MotherPort = motherPort;
        BuildYear = buildYear;
    }

    public ContainerShipBase(string name, string registrationNumber, string motherPort, string buildYear, List<ContainerBase> loadList)
    {
        CurrentLoadList = loadList;
        Name = name;
        RegistrationNumber = registrationNumber;
        MotherPort = motherPort;
        BuildYear = buildYear;
    }

    public void LoadContainer(ContainerBase container)
    {
        CurrentLoadList.Add(container);
    }

    public void LoadContainer(List<ContainerBase> loadList)
    {
        foreach (ContainerBase container in loadList)
        {
            CurrentLoadList.Add(container);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        CurrentLoadList.RemoveAt(FindContainer(serialNumber));
    }

    public void SwitchContainer(string serialNumber, ContainerBase container)
    {
        CurrentLoadList[FindContainer(serialNumber)] = container;
    }

    public void MoveToShip(string serialNumber, ContainerShipBase ship)
    {
        ContainerBase containerToMove = CurrentLoadList[FindContainer(serialNumber)];
        ship.CurrentLoadList.Add(containerToMove);
        CurrentLoadList.Remove(containerToMove);
    }

    public override string ToString()
    {
        return "";
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
}