namespace APBD_03.Models;

public abstract class Container
{
    public double LoadMass { get; protected set; }
    public double TareWeight { get; }
    public int Height { get; }
    public int Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoadCapacity { get; }

    protected Container(double tareWeight, int height, int depth, string serialNumber, double maxLoadCapacity)
    {
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoadCapacity = maxLoadCapacity;
    }

    public abstract void Load(double mass);
    public abstract void Unload();
    
    public override string ToString()
    {
        return $"Numer seryjny: {SerialNumber}, Typ: {GetType().Name}, Masa ładunku: {LoadMass}kg, Maksymalna ładowność: {MaxLoadCapacity}kg, Wymiary: {Height}cm x {Depth}cm";
    }
}