using Containers_Menagment.Interfaces;
using Containers_Menagment.Models.Base;

namespace Containers_Menagment.Models.Containers;

public class GasContainer(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct, double pressure)
     : ContainerBase(serialNumber, weightOfLoad, height, weight, depth, maxWeight, currentProduct), IHazardNotifier
{
    public double Pressure { get; set; } = pressure;

    public override void Unload()
    {
        WeightOfLoad *= 0.05;
    }

    public void Notify()
    {
        Console.WriteLine("Warning Danger!!! Container: " + SerialNumber);
    }

    public override string ToString()
    {
        return base.ToString() + "\nContainer Type: Gas Container" + "\nCurrent Pressure: " + Pressure;
    }
}