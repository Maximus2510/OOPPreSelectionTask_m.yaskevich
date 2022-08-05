using System;
using System.Collections.Generic;
using System.Linq;

namespace HW2
{
    public abstract partial class Plane
    {
        public class Company
        {
            public List<Plane> Planes = new List<Plane>()
            {
                new Military("IL", 20, 50, 5000),
                new Civil("IL2", 10, 20, 4000),
                new Civil("IL3", 50, 150, 3000),
                new Military("IL4", 35, 80, 8000),
                new Civil("IL5", 40, 120, 5200),
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
            public List<Plane> GetPlanesByType(PlaneType userInputPlaneType)
            {
                var selectPlaneType = Planes.Where(PlaneByName => PlaneByName.Usage == userInputPlaneType).OrderBy(PlaneByName => PlaneByName.Name);
                return selectPlaneType.ToList();

            }

            public List<Plane> GetPlanesSortedBySeatsCount()
            {
                var selectedPlanesBySeats = Planes.Where(PlaneBySeats => PlaneBySeats.Seats != 0).OrderBy(PlaneBySeats => PlaneBySeats.Seats);

                return selectedPlanesBySeats.ToList();
            }

            public List<Plane> GetPlanesSortedBySeatsCountUserInput(int minInput, int maxInput)
            {
                var selectedPlanesBySeatsCountUserInput = Planes.Where(PlaneBySeats => PlaneBySeats.Seats > minInput && PlaneBySeats.Seats < maxInput).OrderBy(PlaneBySeats => PlaneBySeats.Seats);

                return selectedPlanesBySeatsCountUserInput.ToList();
            }

            public List<Plane> GetPlanesSortedByWeight()
            {
                var selectedPlanesByWeight = Planes.Where(PlaneByWeight => PlaneByWeight.Weight != 0).OrderBy(PlaneByWeight => PlaneByWeight.Weight);

                return selectedPlanesByWeight.ToList();
            }

            public List<Plane> GetPlanesSortedByWeightUserInput(int minInput, int maxInput)
            {
                var selectedPlanesByWeightUserInput = Planes.Where(PlaneByWeight => PlaneByWeight.Weight > minInput && PlaneByWeight.Weight < maxInput).OrderBy(PlaneByWeight => PlaneByWeight.Weight);

                return selectedPlanesByWeightUserInput.ToList();
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

            public int CapacitySumm()
            {
                int weightOfPlanes = 0;
                for (int i = 0; i < Planes.Count; i++)
                {
                    weightOfPlanes += Convert.ToInt32(Planes[i].Capacity);
                }
                return weightOfPlanes;
            }


        }
    }
}
