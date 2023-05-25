using D00_Utility;
using E07_Vehicle.Enums;
using E07_Vehicle.Interfaces;
using System;
using System.Text;


namespace E07_Vehicle.Models
{
    internal class Submarine : Vehicle, ISubmarine
    {
        #region Properties
        public int FullTankQuantity {get; set;}

        #endregion

        #region Constructors
        public Submarine()
        {
            FullTankQuantity = 0;
        }

        public Submarine(Brand brand, Model model, Color color, string licencePlate, int displacement, int speed, DateTime registrationDate, int fullTankQuantity)
            : base(brand, model, color, licencePlate, displacement, speed, registrationDate)
        {

           FullTankQuantity = fullTankQuantity;
        }

        #endregion

        #region Create
        public void Create()
        {
            base.Create();
            ReadFullTankQuantity();
            Console.Clear();
        }

        #endregion

        #region Read Informations
            public void ReadFullTankQuantity()
        {
            do
            {
                Utility.BlockSeparator();

                try
                {
                    Console.Write("Full Tank Quantity: ");
                    FullTankQuantity = int.Parse(Console.ReadLine());
                }
                catch
                (FormatException ex)
                {
                    Console.WriteLine("Invalid value. Please enter a valid value.");
                }
            } while (FullTankQuantity == 0);
        }
        #endregion

        #region Dive Method
        public void Dive()
        {
            Console.WriteLine("Diving...");
        }

        #endregion

        #region To String
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return base.ToString() + sb.AppendLine("Full Tank Quantity: " + FullTankQuantity);
        }
        #endregion
    }
}
