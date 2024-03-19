namespace Containers_Menagment.Models.Base;

public class ProductBase(string name, double minTemp)
{
    public string Name { get; set; } = name;

    public double MinTemperature { get; set; } = minTemp;
}