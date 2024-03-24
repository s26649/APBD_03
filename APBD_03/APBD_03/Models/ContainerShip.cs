using System.Text;

namespace APBD_03.Models;

public class ContainerShip
{
    public List<Container> Containers { get; private set; }
    public double MaxSpeed { get; }
    public int MaxContainerCount { get; }
    public double MaxTotalWeight { get; }

    public ContainerShip(double maxSpeed, int maxContainerCount, double maxTotalWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxTotalWeight = maxTotalWeight;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new Exception("nie można załadować nowych kontenerów, statek osiągnął maksymalną ilość kontenerów.");
        }

        double totalWeight = Containers.Sum(c => c.LoadMass + c.TareWeight) + container.LoadMass + container.TareWeight;
        
        if (totalWeight / 1000 > MaxTotalWeight) // kg na tony
        {
            throw new Exception("nie można załadować kontenera, przekroczyłby on maksymalną dozwoloną masę statku.");
        }
        
        Containers.Add(container);
    }
    
    public bool UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            return true;
        }
        return false;
    }
    
    public bool ReplaceContainer(string serialNumber, Container newContainer)
    {
        var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index != -1)
        {
            Containers[index] = newContainer;
            return true;
        }
        return false;
    }

    public bool TransferContainer(ContainerShip destinationShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            if (UnloadContainer(serialNumber))
            {
                try
                {
                    destinationShip.LoadContainer(container);
                    return true;
                }
                catch (Exception ex)
                {
                    // ladowanie containera z powrotem jesli transfer nie zadziala
                    LoadContainer(container);
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        return false;
    }
    
    public override string ToString()
    {
        var shipInfo = new StringBuilder();
        
        shipInfo.AppendLine($"Kontenerowiec Info: Maksymalna prędkość: {MaxSpeed} węzłów, Maksymalna liczba kontenerów: {MaxContainerCount}, Maksymalna waga: {MaxTotalWeight} ton");
        shipInfo.AppendLine($"Ilość załadowanych kontenerów: {Containers.Count}, Łączna waga: {Containers.Sum(c => c.LoadMass + c.TareWeight) / 1000} ton");

        foreach (var container in Containers)
        {
            shipInfo.AppendLine(container.ToString());
        }

        return shipInfo.ToString();
    }
}