using Containers_Menagment.Interfaces;
using Containers_Menagment.Models.Base;

namespace Containers_Menagment.Models.Containers;

class FluidContainer : 
    ContainerBase, IHazardNotifier
{
    public bool HazardousLoad { get; set; }

    
    public FluidContainer(double weightOfLoad, double height, double weight, double depth, double maxWeight, ProductBase currentProduct, bool hazardousLoad) : 
        base(weightOfLoad, height, weight, depth, maxWeight, currentProduct)
    {
        HazardousLoad = hazardousLoad;
        SerialNumber = "KON-L" + ID;
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

    public void Notify()
    {
       Console.WriteLine("Warning Danger!!! Container:" + SerialNumber);
    }

    public override string ToString()
    {
        return base.ToString() + "\nContainer Type: Fluid Container" +"\nHazardous Load: " + HazardousLoad;
    }
}