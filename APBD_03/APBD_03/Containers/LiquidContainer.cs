using APBD_03.Exceptions;
using APBD_03.Interfaces;
using APBD_03.Models;

namespace APBD_03.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double tareWeight, int height, int depth, string serialNumber, double maxLoadCapacity, bool isHazardous)
        : base(tareWeight, height, depth, serialNumber, maxLoadCapacity)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double mass)
    {
        double maxAllowedLoad = IsHazardous ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9;
        if (mass > maxAllowedLoad)
        {
            NotifyHazard();
            throw new OverfillException("Masa przekracza maksymalną dozwoloną.");
        }
        LoadMass = mass;
    }

    public override void Unload()
    {
        LoadMass = 0;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Wykryto niebezpieczne zdarzenie w kontenerze {SerialNumber}");
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Ładunek niebezpieczny: {(IsHazardous ? "Tak" : "Nie")}";
    }
}