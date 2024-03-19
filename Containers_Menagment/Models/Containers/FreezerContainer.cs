using Containers_Menagment.Models.Base;

namespace Containers_Menagment.Models.Containers;

public class FreezerContainer(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct) 
        : ContainerBase(serialNumber, weightOfLoad, height, weight, depth, maxWeight, currentProduct)
{
    public double CurrentTemperature { get; set; }

    public override string ToString()
    {
        return base.ToString() + "\nContainer Type: Freezer Container" + "\nCurrent Temperature: " + CurrentTemperature;
    }

}
