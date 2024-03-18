using Containers_Menagment.Exceptions;
using Containers_Menagment.Products.Base;

namespace Containers_Menagment.Models.Base;

public abstract class ContainerBase{
    public double MaxLoadWeight{ get;}
    public double Height{ get; set;}
    public double Weight{ get; set;}
    public double Depth{ get; set;}
    public double WeightOfLoad{ get; set;}
    public string SerialNumber{ get; set;}
    public ProductBase CurrentProduct{ get; set;}

    public ContainerBase(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct) {
        MaxLoadWeight = maxWeight;
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        WeightOfLoad = weightOfLoad;
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
}