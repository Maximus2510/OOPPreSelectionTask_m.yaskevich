using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace HW2
{
    public class Plane
    {

        private string planeName;
        private string planeUsage;
        private int sitsCount;
        private int maxWeight;
        private double flightCapacity;

        public Plane(string planeName, string planeUsage, int sitsCount, int maxWeight,double flightCapacity)
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

        public string Usage
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

        //сделать виртуальным
        public virtual void Print()
        {
            WriteLine($"Name = {Name}");
            WriteLine($"Ploane use type = {Usage}");
            WriteLine($"Sits Count = {Seats}");
            WriteLine($"Planes max weight = {Weight}");
            WriteLine($"Flight capacity = {Capacity}");
            WriteLine($"##############################\n");
        }

        public override string ToString()
        {
            return ($"{Name}_{Usage}_{Seats}_{Weight}_{Capacity}");
        }


        public class Company
        {
            private List<Plane> planes = new List<Plane>()
            {
                new Plane("IL","Military", 20, 50, 5000),
                new Plane("IL2", "Civil", 10, 20, 4000),
                new Plane("IL3", "Civil", 50, 150, 3000),
                new Plane("IL4", "Military", 35, 80, 8000),
                new Plane("IL5", "Civil", 40, 120, 5200),
            };


            private string planeStrInList;
            public string CreatePlane(Plane plane)
            {
                foreach(Plane planeStrInList in planes)
                {
                    planeStrInList.ToString();
                }

                if (plane.ToString() == planeStrInList)
                {
                    return $"{plane}, already exists";
                }
                else
                {
                    planes.Add(plane);
                    return $"{plane}, created";
                }
            }

            public List<Plane> SortPlanesBySitsCount()
            {
                List<Plane> result = planes.OrderBy(P => P.Seats).ToList();
                return result;
            }

            public List<Plane> SortPlanesByRangeOfFlight()
            {
                return planes.OrderBy(P => P.Capacity).ToList();
            }

            public List<Plane> GetPlanesSortedByName()
            {
                //var selectedPlanes = from PlaneByName in planes
                //                     where PlaneByName.Name != null
                //                     orderby PlaneByName.Name 
                //                     select PlaneByName;

                var selectedPlanesByName = planes.Where(PlaneByName => PlaneByName.Name != null).OrderBy(PlaneByName => PlaneByName.Name);

                return selectedPlanesByName.ToList();
            }

            public List<Plane> GetPlanesSortedBySeatsCount()
            {
                var selectedPlanesBySeats = planes.Where(PlaneBySeats => PlaneBySeats.Seats != 0).OrderBy(PlaneBySeats => PlaneBySeats.Seats);

                return selectedPlanesBySeats.ToList();
            }

            public List<Plane> GetPlanesSortedByWeightCount()
            {
                var selectedPlanesByWeight = planes.Where(PlaneByWeight => PlaneByWeight.Weight != 0).OrderBy(PlaneByWeight => PlaneByWeight.Weight);

                return selectedPlanesByWeight.ToList();
            }

            public List<Plane> GetPlanesSortedByFlightCapacity()
            {
                var selectedPlanesByFlightCapacity = planes.Where(PlaneByFlightCap => PlaneByFlightCap.Capacity != 0).OrderBy(PlaneByFlightCap => PlaneByFlightCap.Capacity);

                return selectedPlanesByFlightCapacity.ToList();
            }

            public int WeightsSumm()
            {
                int weightOfPlanes = 0;
                for (int i = 0; i < planes.Count; i++)
                {
                    weightOfPlanes += planes[i].Weight;
                }
                return weightOfPlanes;
            }

            public int SeatsCountSumm()
            {
                int seatsInPlanes = 0;
                for (int i = 0; i < planes.Count; i++)
                {
                    seatsInPlanes += planes[i].Seats;
                }
                return seatsInPlanes;
            }


        }

        static void Main(string[] args)
        {
            
            //Plane plane1 = new Plane("IL-1",200,5000,52895.50);
            //Plane plane2 = new Plane("IL-2", 3000, 4000, 8123.68);
            //Plane plane3 = new Plane("IL-3", 500, 2000, 9254.50);
            //Plane plane4 = new Plane("IL-4", 100, 1500, 3156.45);

            //WriteLine("Info about plane1:");
            //plane1.Print();
            //WriteLine("Info about plane2:");
            //plane2.Print();
            //WriteLine("Info about plane3:");
            //plane3.Print();
            //WriteLine("Info about plane4:");
            //plane4.Print();
            //ReadLine();

            //AirLineMax allPlanes = new AirLineMax ("")

        }
    }
}
