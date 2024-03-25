using Containers_Menagment.Exceptions;

namespace Containers_Menagment.Models.Base;

public abstract class ContainerBase
{
    private static int currentIDNumber = 0;
    public double MaxLoadWeight { get; internal set;}
    public double Height { get; internal set; }
    public double Weight { get; internal set; }
    public double Depth { get; internal set; }
    public double WeightOfLoad { get; internal set; }
    public string? SerialNumber { get; internal set; }
    public int ID {get; set;}
    public ProductBase? CurrentProduct { get; set; }

    public ContainerBase(double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct){
        currentIDNumber++;
        ID = currentIDNumber;
        WeightOfLoad = weightOfLoad;
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxLoadWeight = maxWeight;
        CurrentProduct = currentProduct;
    }

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