using Containers_Menagment.Interfaces;
using Containers_Menagment.Models.Base;
using Containers_Menagment.Products.Base;

namespace Containers_Menagment.Models;

class FuildContainer : ContainerBase, IHazardNotifier
{
    public Boolean HazardousLoad { get; set; }
    public FuildContainer(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct, Boolean hazardousLoad) 
        : base(serialNumber, weightOfLoad, height, weight, depth, maxWeight, currentProduct){
            HazardousLoad = hazardousLoad;
    }

    void Notify(){
        Console.WriteLine("Warning, potential breach in container: " + SerialNumber);
    }

    public override void Load(double newWeight, ProductBase product)
    {
        if (HazardousLoad){
            if(newWeight <= (MaxLoadWeight*0.5)){
                WeightOfLoad = newWeight;
                CurrentProduct = product;
            }else{
                Console.WriteLine("DANGER!!!\n Max Safe Load exceeded: " + newWeight);
            }
        }else{
            if(newWeight <= (MaxLoadWeight*0.9)){
                WeightOfLoad = newWeight;
                CurrentProduct = product;
            }else{
                Console.WriteLine("DANGER!!!\n Max Safe Load exceeded: " + newWeight);
            }
        }
    }
}