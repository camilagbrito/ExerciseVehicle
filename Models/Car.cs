using D00_Utility;
using E07_Vehicle.Enums;
using E07_Vehicle.Interfaces;
using System;
using System.Text;

namespace E07_Vehicle.Models
{
    internal class Car : Vehicle, ICar
    {
        #region Properties
        public bool Ishybrid { get; set; }

        #endregion

        #region Constructors
        public Car()
        {
            Ishybrid = false;
        }

        public Car(Brand brand, Model model, Color color, string licencePlate, int displacement, int speed, DateTime registrationDate, bool isHybrid)
            : base(brand, model, color, licencePlate, displacement, speed, registrationDate)
        {

            Ishybrid = isHybrid;
        }

        #endregion

        #region Create
        public void Create()
        {
            base.Create();
            ReadIsHybrid();
            Console.Clear();
        }

        #endregion

        #region Read Informations
        public void ReadIsHybrid()
        {
            string resp;
            do
            {
                Utility.BlockSeparator();

                Console.Write("Hybrid (y/n): ");
                resp = Console.ReadLine().ToUpper();
                ValidationIsHybrid(resp);
            } while (resp != "Y" && resp != "N");
        }

        public void ValidationIsHybrid(string resp)
        {


            try
            {

                ValidationString(resp);

                if (resp == "Y")
                {
                    Ishybrid = true;
                }
                else if (resp == "N")
                {
                    Ishybrid = false;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid value. Please enter a valid value.");
            }

        }

        #endregion

        #region Validation Methods


        #endregion

        #region Drive Method
        public void Drive()
        {
            Console.WriteLine("Driving...");
        }
        #endregion

        #region To String
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return base.ToString() + sb.AppendLine("Hybrid: " + Ishybrid);
        }
        #endregion
    }
}
