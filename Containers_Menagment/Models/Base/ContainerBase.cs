using Containers_Menagment.Exceptions;

namespace Containers_Menagment.Models.Base;

public abstract class ContainerBase{
    public double MaxLoadWeight{ get;}
    public double Height{ get; set;}
    public double Weight{ get; set;}
    public double Depth{ get; set;}
    public double WeightOfLoad{ get; set;}
    public string SerialNumber{ get; set;}
    public string CurrentProduct{ get; set;}

    public ContainerBase(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, string currentProduct) {
        MaxLoadWeight = maxWeight;
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        WeightOfLoad = weightOfLoad;
        CurrentProduct = currentProduct;
    }

    public void Unload(){

    }

    public void Load(double newWeight){
        if(newWeight > MaxLoadWeight){
            throw new OverfillException();
        }
        
    }
}