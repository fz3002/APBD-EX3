namespace Containers_Menagment.Models.Base;

public class ProductBase
{
    public string Name { get; set; }

    public double MinTemperature 
    { 
        get => TempOfProducts[Name];
        set => TempOfProducts[Name] = value; 
    }

    private static Dictionary<string, double> TempOfProducts = new()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausage", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    public ProductBase(string name)
    {
        Name = name;
        if(!TempOfProducts.ContainsKey(name))
        {
            Console.WriteLine("Product no in database. Enter min temp of given product");
            double minTemp = Convert.ToDouble(Console.ReadLine());
            TempOfProducts.Add(name, minTemp);
        }
    }
}