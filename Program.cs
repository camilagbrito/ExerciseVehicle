using D00_Utility;
using E07_Vehicle.Models;
using System;
using System.Collections.Generic;

namespace E07_Vehicle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Submarine submarine = new Submarine();
            Plane plane = new Plane();
            List<Vehicle> list = new List<Vehicle>();

            try {

                Console.WriteLine("How Many Vehicles do you want to add? ");
                int n = int.Parse(Console.ReadLine());

                for(int i = 0; i < n; i++) {

                    //TODO handle add vehicles
                    Vehicle.VehiclesMenu();

                    string response = Console.ReadLine();
                    Console.Clear();

                    if (response.ToUpper() == "CAR")
                    {
                        car.Create();
                        car.Drive();
                        Console.ReadKey();
                        list.Add(car);
                    
                    }
                    else if (response.ToUpper() == "SUBMARINE")
                    {
                        submarine.Create();
                        submarine.Dive();
                        Console.ReadKey();
                        list.Add(submarine);
                   
                    }
                    else if (response.ToUpper() == "PLANE")
                    {
                        plane.Create();
                        plane.Fly();
                        Console.ReadKey();
                        list.Add(plane);
                   
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }

                Console.Clear();

                foreach (Vehicle v in list)
                {
                    Console.WriteLine(v.ToString());
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Utility.TerminateConsole();
        }
    }
}
