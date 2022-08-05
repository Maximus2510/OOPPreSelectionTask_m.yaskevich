using static System.Console;
using System.Threading;
using System;

namespace HW2
{
    public abstract partial class Plane
    {
        public class ConsoleTrigger
        {
            public Company Company { get; set; }

            public ConsoleTrigger()
            {
                Company = new Company();
            }

            private void CreatePlaneConsole()
            {
                WriteLine("Enter Plane name: ");
                string inputName = ReadLine();
                WriteLine("Enter Plane usage,");
                WriteLine("enter Military or Civil to create plane of such type.");
                string inputUserPlaneType = ReadLine();
                bool correctTypeInput = Enum.IsDefined(typeof(PlaneType), inputUserPlaneType);

                if (!correctTypeInput)
                {
                    WriteLine("No such type of a plane!");
                }
                PlaneType type = (PlaneType)Enum.Parse(typeof(PlaneType), inputUserPlaneType);
                WriteLine("Enter Plane Sits Count:");
                int inputSitsCount = int.Parse(ReadLine());
                WriteLine("Enter Plane Weight:");
                int planeWeight = int.Parse(ReadLine());
                WriteLine("Enter Plane Flight Capacity:");
                double planeFlightCap = double.Parse(ReadLine());

                Plane createdPlane;

                switch (type)
                {

                    case PlaneType.Military:
                        createdPlane = new Military(inputName, inputSitsCount, planeWeight, planeFlightCap);
                        break;
                    case PlaneType.Civil:
                        createdPlane = new Civil(inputName, inputSitsCount, planeWeight, planeFlightCap);
                        break;
                    default:
                        return;
                }

                

                if (Company.CreatePlane(createdPlane))
                {
                    WriteLine("Plane Created!");
                }
                else
                {
                    WriteLine("Plane with such parameters already exists!");
                }
            }
            private void ShowPlanes()
            {
                foreach (Plane plane in Company.Planes)
                {
                    WriteLine(plane.ToString());
                }
            }

            private void SortPlanesBySeatsCount()
            {

                WriteLine("Enter min seats count value:");
                int minInput = int.Parse(ReadLine());
                WriteLine("Enter max seats count value:");
                int maxInput = int.Parse(ReadLine());
                WriteLine();

                if (minInput < maxInput)
                {
                    var item = Company.GetPlanesSortedBySeatsCountUserInput(minInput,maxInput);
                    item.ForEach(WriteLine);
                }
                else
                {
                    WriteLine("Min seats can't be higher than Max seats count! Enter correct seats count!");
                }
            }

            private void SortPlanesByWeight()
            {

                WriteLine("Enter min weight count value:");
                int minInput = int.Parse(ReadLine());
                WriteLine("Enter max weight count value:");
                int maxInput = int.Parse(ReadLine());
                WriteLine();

                if (minInput < maxInput)
                {
                    var item = Company.GetPlanesSortedByWeightUserInput(minInput, maxInput);
                    item.ForEach(WriteLine);
                }
                else
                {
                    WriteLine("Min seats can't be higher than Max seats count! Enter correct seats count!");
                }
            }

            private void GetPlanesByType()
            {
                WriteLine("Enter plane type:     (e.g.: Military/Civil)");
                //bool correctTypeInput = Enum.TryParse(ReadLine(),out PlaneType userInputPlaneType);
                string inputUserPlaneType = ReadLine();
                bool correctTypeInput = Enum.IsDefined(typeof(PlaneType), inputUserPlaneType);

                if(correctTypeInput)
                {
                    PlaneType type = (PlaneType)Enum.Parse(typeof(PlaneType), inputUserPlaneType);
                    var planeByType = Company.GetPlanesByType(type);
                    planeByType.ForEach(WriteLine);
                }
                else
                {
                    Console.WriteLine("No such type of plane, Military and Civil plane types can be created!");
                }
            }

            private void GetAllPlanesWeight()
            {
                WriteLine(Company.WeightsSumm());
            }

            private void GetAllPlanesFlightCapacity()
            {
                WriteLine(Company.CapacitySumm());
            }

            public void MainMenu() 
            {
                string userInput = null; 
                WriteLine("Hello, user");

                for (;userInput!="0";)
                {
                    WriteLine("Select any menu action:");
                    WriteLine("1. create plane");
                    WriteLine("2. show planes");
                    WriteLine("3. sort planes by seats count");
                    WriteLine("4. sort planes by weight");
                    WriteLine("5. get planes by type");
                    WriteLine("6. get all planes weight");
                    WriteLine("7. get all planes flight capacity");
                    WriteLine("0. exit.");
                    WriteLine();
                    userInput = ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.Clear();
                            CreatePlaneConsole();
                            WriteLine();
                            break;
                        case "2":
                            Console.Clear();
                            ShowPlanes();
                            WriteLine();
                            break;
                        case "3":
                            Console.Clear();
                            SortPlanesBySeatsCount();
                            WriteLine();
                            break;
                        case "4":
                            Console.Clear();
                            SortPlanesByWeight();
                            WriteLine();
                            break;
                        case "5":
                            Console.Clear();
                            GetPlanesByType();
                            WriteLine();
                            break;
                        case "6":
                            Console.Clear();
                            WriteLine("Planes weight:");
                            GetAllPlanesWeight();
                            WriteLine();
                            break;
                        case "7":
                            Console.Clear();
                            WriteLine("Planes flight capacity");
                            GetAllPlanesFlightCapacity();
                            WriteLine();
                            break;
                        case "0":
                            WriteLine("Good bye!");
                            Thread.Sleep(2500);

                            break;

                        default:
                            WriteLine("Wrong input!!!");
                            break;
                    }
                }
            }
        }
    }
}
