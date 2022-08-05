namespace HW2
{
    public abstract partial class Plane
    {
        public class Civil : Plane
        {
            public Civil(string planeName, int sitsCount, int maxWeight, double flightCapacity) : base(planeName, PlaneType.Civil, sitsCount, maxWeight, flightCapacity)
            {
            }

            public override string EngineType()
            {
                return "Civil";
            }

            public override string ToString()
            {
                return base.ToString()+ "_Tr tr tr";
            }
        }
    }
}
