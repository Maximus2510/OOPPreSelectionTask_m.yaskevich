using static System.Console;

namespace HW2
{
    public abstract partial class Plane
    {

        private string planeName;
        private PlaneType planeUsage;
        private int sitsCount;
        private int maxWeight;
        private double flightCapacity;

        public Plane(string planeName, PlaneType planeUsage, int sitsCount, int maxWeight, double flightCapacity)
        {
            this.planeName = planeName;
            this.planeUsage = planeUsage;
            this.sitsCount = sitsCount;
            this.maxWeight = maxWeight;
            this.flightCapacity = flightCapacity;
        }

        public string Name
        {
            get { return planeName; }
            set { planeName = value; }
        }

        public PlaneType Usage
        {
            get { return planeUsage; }
            set { planeUsage = value; }
        }

        public int Seats
        {
            get { return sitsCount; }
            set { sitsCount = value; }
        }

        public int Weight
        {
            get { return maxWeight; }
            set { maxWeight = value; }
        }

        public double Capacity
        {
            get { return flightCapacity; }
            set { flightCapacity = value; }
        }

        public abstract string EngineType();

        public override string ToString()
        {
            return $"{Name}_{Usage}_{Seats}_{Weight}_{Capacity}";
        }

        public virtual void Print()
        {
            WriteLine($"Name = {Name}");
            WriteLine($"Ploane use type = {Usage}");
            WriteLine($"Sits Count = {Seats}");
            WriteLine($"Planes max weight = {Weight}");
            WriteLine($"Flight capacity = {Capacity}");
            WriteLine($"##############################\n");
        }
    }
}
