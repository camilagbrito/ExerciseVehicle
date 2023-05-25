using D00_Utility;
using E07_Vehicle.Enums;
using E07_Vehicle.Interfaces;
using System;
using System.Text;

namespace E07_Vehicle.Models
{
    internal class Plane: Vehicle, IPlane
    {
        #region Properties
        public int Capacity { get; set; }

        #endregion

        #region Constructors
        public Plane()
        {
            Capacity = 0;
        }

        public Plane(Brand brand, Model model, Color color, string licencePlate, int displacement, int speed, DateTime registrationDate, int capacity)
            : base(brand, model, color, licencePlate, displacement, speed, registrationDate)
        {

            Capacity = capacity;
        }

        #endregion

        #region Create
        public void Create()
        { 
            base.Create();
            ReadCapacity();
            Console.Clear();
        }

        #endregion

        #region Read Informations
        public void ReadCapacity()
        {

            do
            {
                Utility.BlockSeparator();

                try
                {
                    Console.Write("Capacity: ");
                    Capacity = int.Parse(Console.ReadLine());
                }
                catch
                (FormatException ex)
                {
                    Console.WriteLine("Invalid value. Please enter a valid value.");
                }
            } while (Capacity == 0);
        }

        #endregion

        #region MethodFly
        public void Fly()
        {
            Console.WriteLine("Flying...");
        }

        #endregion

        #region To String
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return base.ToString() + sb.AppendLine("Capacity: " + Capacity);
        }
        #endregion
    }
}
