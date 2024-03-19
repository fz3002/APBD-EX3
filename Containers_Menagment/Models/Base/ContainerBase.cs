using Containers_Menagment.Exceptions;

namespace Containers_Menagment.Models.Base;

public abstract class ContainerBase(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct)
{
    public double MaxLoadWeight { get; } = maxWeight;
    public double Height { get; set; } = height;
    public double Weight { get; set; } = weight;
    public double Depth { get; set; } = depth;
    public double WeightOfLoad { get; set; } = weightOfLoad;
    public string SerialNumber { get; set; } = serialNumber;
    public ProductBase? CurrentProduct { get; set; } = currentProduct;

    public virtual void Unload(){
        WeightOfLoad = 0;
        CurrentProduct = null;
    }

    public virtual void Load(double newWeight, ProductBase product){
        if(newWeight > MaxLoadWeight){
            throw new OverfillException();
        }
        WeightOfLoad = newWeight;
        CurrentProduct = product;
    }

    public override string ToString()
    {
        return "Container: " + SerialNumber + 
                "\nMax Weight: " + MaxLoadWeight + 
                "\nCurrent Product: " + CurrentProduct + 
                "\nCurrent Load Weight: " + WeightOfLoad + 
                "\nFull Weight: " + Weight;
    }
}