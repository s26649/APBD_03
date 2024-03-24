using APBD_03.Exceptions;
using APBD_03.Models;

namespace APBD_03.Containers;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    public RefrigeratedContainer(double tareWeight, int height, int depth, string serialNumber, double maxLoadCapacity, string productType, double temperature)
        : base(tareWeight, height, depth, serialNumber, maxLoadCapacity)
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
        {
            throw new OverfillException("Masa przekracza maksymalną dozwoloną.");
        }
        LoadMass = mass;
    }

    public override void Unload()
    {
        LoadMass = 0;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Typ produktu: {ProductType}, Temperatura: {Temperature}°C";
    }
}