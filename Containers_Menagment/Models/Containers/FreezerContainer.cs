using Containers_Menagment.Models.Base;

namespace Containers_Menagment.Models.Containers;

public class FreezerContainer 
        : ContainerBase
{
    public double CurrentTemperature { get; set; }

    public FreezerContainer(double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct) : 
        base(weightOfLoad, height, weight, depth, maxWeight, currentProduct)
    {
        SerialNumber = "KON-C-" + ID;
    }

    public override string ToString()
    {
        return base.ToString() + "\nContainer Type: Freezer Container" + "\nCurrent Temperature: " + CurrentTemperature;
    }

}
