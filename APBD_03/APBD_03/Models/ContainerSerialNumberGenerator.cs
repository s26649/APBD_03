namespace APBD_03.Models;

public static class ContainerSerialNumberGenerator
{
    private static readonly Dictionary<string, int> counts = new Dictionary<string, int>();

    public static string GenerateSerialNumber(string containerType)
    {
        if (!counts.ContainsKey(containerType))
        {
            counts[containerType] = 0;
        }
        counts[containerType]++;
        return $"KON-{containerType}-{counts[containerType]}";
    }
}
