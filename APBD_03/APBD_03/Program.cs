using APBD_03.Containers;
using APBD_03.Models;

namespace APBD_03;
class Program
{
    public static void Main(string[] args)
    {
        ContainerShip ship1 = new ContainerShip(20, 5, 50);
        ContainerShip ship2 = new ContainerShip(15, 10, 100);

        GasContainer gasContainer = new GasContainer(2000, 250, 400, 10000, 2.5);
        LiquidContainer liquidContainer = new LiquidContainer(1500, 200, 350, 8000, true);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(2500, 300, 450, 12000, "Banany", -5);

        Console.WriteLine("załadunek kontenerów na statek 1:");
        ship1.LoadContainer(gasContainer);
        ship1.LoadContainer(liquidContainer);
        ship1.LoadContainer(refrigeratedContainer);

        Console.WriteLine(ship1.ToString());

        Console.WriteLine("próba transferu kontenera z gazem na statek 2:");
        if (ship1.TransferContainer(ship2, gasContainer.SerialNumber))
        {
            Console.WriteLine("sukces.");
        }
        else
        {
            Console.WriteLine("niepowodzenie.");
        }

        Console.WriteLine("statek 1 po transferze:");
        Console.WriteLine(ship1.ToString());

        Console.WriteLine("statek 2 po transferze:");
        Console.WriteLine(ship2.ToString());
    }
}