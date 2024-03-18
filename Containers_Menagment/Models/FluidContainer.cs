using Containers_Menagment.Interfaces;
using Containers_Menagment.Models.Base;

namespace Containers_Menagment.Models;

class FuildContainer : ContainerBase, IHazardNotifier
{
    public FuildContainer(string serialNumber, double weightOfLoad, double height, double weight, double depth, double maxWeight, string currentProduct) 
        : base(serialNumber, weightOfLoad, height, weight, depth, maxWeight, currentProduct)
    {
    }
}