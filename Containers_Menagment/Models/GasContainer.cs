using Containers_Menagment.Interfaces;
using Containers_Menagment.Models.Base;
using Containers_Menagment.Products.Base;

namespace Containers_Menagment.Models;

public class GasContainer : ContainerBase, IHazardNotifier
{
    public double Pressure { get; set; }
    public GasContainer(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct, double pressure) 
        : base(serialNumber, weightOfLoad, height, weight, depth, maxWeight, currentProduct)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        WeightOfLoad = WeightOfLoad*0.05;
    }
}