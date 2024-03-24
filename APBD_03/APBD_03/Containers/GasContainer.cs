using APBD_03.Exceptions;
using APBD_03.Interfaces;
using APBD_03.Models;

namespace APBD_03.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double tareWeight, int height, int depth, double maxLoadCapacity, double pressure)
        : base(tareWeight, height, depth, ContainerSerialNumberGenerator.GenerateSerialNumber("G"), maxLoadCapacity)
    {
        Pressure = pressure;
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
        {
            NotifyHazard();
            throw new OverfillException("Masa przekracza maksymalną dozwoloną.");
        }
        LoadMass = mass;
    }

    public override void Unload()
    {
        LoadMass *= 0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Wykryto niebezpieczne zdarzenie w kontenerze {SerialNumber}");
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Ciśnienie: {Pressure} atm";
    }
}