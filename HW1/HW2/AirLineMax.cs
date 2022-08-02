using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HW2
{
    public class Plane
    {

        private string planeName;
        private string planeUsage;
        private int sitsCount;
        private int maxWeight;
        private double flightCapacity;

        public Plane(string planeName, string planeUsage, int sitsCount, int maxWeight, double flightCapacity)
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
            public List<Plane> Planes = new List<Plane>()
            {
                new Plane("IL","Military", 20, 50, 5000),
                new Plane("IL2", "Civil", 10, 20, 4000),
                new Plane("IL3", "Civil", 50, 150, 3000),
                new Plane("IL4", "Military", 35, 80, 8000),
                new Plane("IL5", "Civil", 40, 120, 5200),
            };


            public bool CreatePlane(Plane plane)
            {
                foreach (Plane planeStrInList in Planes)
                {
                    if (planeStrInList.ToString() == plane.ToString())
                    {
                        return false;
                        //WriteLine $"{plane}, already exists";
                    }
                }

                Planes.Add(plane);
                return true;
            }

            public List<Plane> SortPlanesBySitsCount()
            {
                return Planes.OrderBy(P => P.Seats).ToList();
            }

            public List<Plane> SortPlanesByRangeOfFlight()
            {
                return Planes.OrderBy(P => P.Capacity).ToList();
            }

            public List<Plane> GetPlanesSortedByName()
            {
                //var selectedPlanes = from PlaneByName in planes
                //                     where PlaneByName.Name != null
                //                     orderby PlaneByName.Name 
                //                     select PlaneByName;

                var selectedPlanesByName = Planes.Where(PlaneByName => PlaneByName.Name != null).OrderBy(PlaneByName => PlaneByName.Name);

                return selectedPlanesByName.ToList();
            }

            public List<Plane> GetPlanesSortedBySeatsCount()
            {
                var selectedPlanesBySeats = Planes.Where(PlaneBySeats => PlaneBySeats.Seats != 0).OrderBy(PlaneBySeats => PlaneBySeats.Seats);

                return selectedPlanesBySeats.ToList();
            }

            public List<Plane> GetPlanesSortedByWeightCount()
            {
                var selectedPlanesByWeight = Planes.Where(PlaneByWeight => PlaneByWeight.Weight != 0).OrderBy(PlaneByWeight => PlaneByWeight.Weight);

                return selectedPlanesByWeight.ToList();
            }

            public List<Plane> GetPlanesSortedByFlightCapacity()
            {
                var selectedPlanesByFlightCapacity = Planes.Where(PlaneByFlightCap => PlaneByFlightCap.Capacity != 0).OrderBy(PlaneByFlightCap => PlaneByFlightCap.Capacity);

                return selectedPlanesByFlightCapacity.ToList();
            }

            public int WeightsSumm()
            {
                int weightOfPlanes = 0;
                for (int i = 0; i < Planes.Count; i++)
                {
                    weightOfPlanes += Planes[i].Weight;
                }
                return weightOfPlanes;
            }

            public int SeatsCountSumm()
            {
                int seatsInPlanes = 0;
                for (int i = 0; i < Planes.Count; i++)
                {
                    seatsInPlanes += Planes[i].Seats;
                }
                return seatsInPlanes;
            }


        }

        public class ConsoleTrigger
        {
            public Company Company { get; set; }
            public ConsoleTrigger()
            {
                Company = new Company();
            }

            private void ShowPlanes()
            {
                foreach(Plane plane in Company.Planes)
                {
                    WriteLine(plane.ToString());
                }
            }

            private void CreatePlaneConsole()
            {
                string planeName = null;
                string planeUsage = null;
                int planeSitsCount = 0;
                int planeWeight = 0;
                double planeFlightCap = 0;

                WriteLine("Enter Plane name: ");
                planeName = ReadLine();
                WriteLine("Enter Plane usage:");
                planeUsage = ReadLine();
                WriteLine("Enter Plane Sits Count:");
                planeSitsCount = int.Parse(ReadLine());
                WriteLine("Enter Plane Weight:");
                planeWeight = int.Parse(ReadLine());
                WriteLine("Enter Plane Flight Capacity:");
                planeFlightCap = double.Parse(ReadLine());

                Plane createdPlane = new Plane(planeName, planeUsage, planeSitsCount, planeWeight, planeFlightCap);

                if (Company.CreatePlane(createdPlane))
                {
                    WriteLine("Plane Created!");
                }
                else
                {
                    WriteLine("Plane with such parameters already exists!");
                }
            }

            public void MainMenu() 
            {
                string userInput = null; 
                WriteLine("Hello, user");

                for (;userInput!="3";)
                {
                    WriteLine("Select any menu action:");
                    WriteLine("1. create");
                    WriteLine("2. show");
                    WriteLine("3. exit.");
                    WriteLine();
                    userInput = ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            WriteLine();
                            CreatePlaneConsole();
                            WriteLine();
                            break;
                        case "2":
                            ShowPlanes();
                            WriteLine();
                            break;
                        case "3":
                            
                            WriteLine("Good bye!");
                            Thread.Sleep(2500);

                            break;

                        default:
                            System.Console.WriteLine("Wrong input!!!");
                            break;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            ConsoleTrigger consoleTrigger = new ConsoleTrigger();
            consoleTrigger.MainMenu();
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
