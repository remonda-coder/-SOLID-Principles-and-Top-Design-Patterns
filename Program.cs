using System.Text;
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. SpaceShip Simple Factory ---");

        ISpaceShipSimpleFactory factory = new SpaceShipSimpleFactory();
        
        ISpaceShip ship1 = factory.CreateSpaceShip(ShipType.MillenniumFalcon);
        Console.WriteLine($"Created: {ship1.displayName}");

        ISpaceShip ship2 = factory.CreateSpaceShip(ShipType.Serenity);
        Console.WriteLine($"Created: {ship2.displayName}");

        Console.WriteLine("\n--- 2. Using Factory Method ---");
        ISpaceShipFactory Falconfactory =new MilleniumFalconFactory();
        ISpaceShip MyFalcon=Falconfactory.CreateSpaceShip(ShipType.MillenniumFalcon);
        Console.WriteLine($"Created via Factory Method: {MyFalcon.displayName}");

        // If we want Serenity, we switch to the SerenityFactory.
        ISpaceShipFactory serenityFactory = new SerenityFactory();
        ISpaceShip mySerenity = serenityFactory.CreateSpaceShip(ShipType.Serenity);
        Console.WriteLine($"Created via Factory Method: {mySerenity.displayName}");
    }
    //enum 
    public enum ShipType
    {
       MillenniumFalcon,
        Serenity,
        NullShip 
    }
    //interface
    public interface ISpaceShip
    {
        public int position { get; set; }
        public int size { get; set; }
        public string displayName { get; set; }
        public int speed { get; set; }
    }

    //concrete
    public class MilleniumFalcon : ISpaceShip
    {
        public int position { get; set; } = 20;
        public int size { get; set; } = 300;
        public string displayName { get; set; } = "Millennium Falcon";
        public int speed { get; set; } = 1000;
    }
    public class Serenity : ISpaceShip
    {
        public int position { get; set; } = 35;
        public int size { get; set; } = 200;
        public string displayName { get; set; } = "Serenity";
        public int speed { get; set; } = 400;
    }
    public class NullShip : ISpaceShip
    {
        public int position { get; set; } = 0;
        public int size { get; set; } = 0;
        public string displayName { get; set; } = "";
        public int speed { get; set; } = 0;
    }
    //simple factory interface
    public interface ISpaceShipSimpleFactory
    {
        ISpaceShip CreateSpaceShip(ShipType type);
    }
    //simple factory concrete
    public class SpaceShipSimpleFactory : ISpaceShipSimpleFactory
    {
        public ISpaceShip CreateSpaceShip(ShipType type)
        {
            switch(type)
            {
                case ShipType.MillenniumFalcon:
                    return new MilleniumFalcon();
                case ShipType.Serenity:
                    return new Serenity();
                case ShipType.NullShip:
                    return  new NullShip();
                default:
                    throw new ArgumentException("Ship logic not implemented yet for this type.");
            }
            
        }
    }
    // factory interface
    public interface ISpaceShipFactory
    {
        ISpaceShip CreateSpaceShip(ShipType type);
    }
    // factory concrete 3 classes
    public class MilleniumFalconFactory : ISpaceShipFactory
    {
        public ISpaceShip CreateSpaceShip(ShipType type)
        {
            return new MilleniumFalcon();
        }
    }
    public class SerenityFactory : ISpaceShipFactory
    {
        public ISpaceShip CreateSpaceShip(ShipType type)
        {
            return new Serenity();
        }
    }
}


