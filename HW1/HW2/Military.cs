namespace HW2
{
    public abstract partial class Plane
    {
        public class Military : Plane
        {
            public Military(string planeName, int sitsCount, int maxWeight, double flightCapacity) 
                : base(planeName, PlaneType.Military, sitsCount, maxWeight, flightCapacity)
            {
            }

            public override string EngineType()
            {
                return "Military";
            }

            public override string ToString()
            {
                return base.ToString()+ "_Piu piu piu";
            }

        }
    }
}
