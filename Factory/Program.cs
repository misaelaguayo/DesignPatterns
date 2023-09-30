namespace Factory
{
    public enum VehicleType
    {
        Scooter,
        Bike
    }

    public interface IFactory
    {
        void Drive(int miles);
    }

    public class Scooter : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }

    public class Bike : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(VehicleType Vehicle);
    }

    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(VehicleType Vehicle)
        {
            switch (Vehicle)
            {
                case VehicleType.Scooter:
                    return new Scooter();
                case VehicleType.Bike:
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();
            IFactory scooter = factory.GetVehicle(VehicleType.Scooter);
            scooter.Drive(10);
            IFactory bike = factory.GetVehicle(VehicleType.Bike);
            bike.Drive(20);
        }
    }
}
