using D00_Utility;
using E07_Vehicle.Enums;
using System;
using System.Text;

namespace E07_Vehicle.Models
{
    internal abstract class Vehicle : IVehicle
    {

        #region Properties

        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public Color Color { get; set; }
        public string LicencePlate { get; set; }
        public int Displacement { get; set; }
        public int Speed { get; set; }
        public DateTime RegistrationDate { get; set; }

        #endregion

        #region Constructors
        public Vehicle()
        {
            LicencePlate = string.Empty;
            Displacement = 0;
            Speed = 0;
            RegistrationDate = DateTime.MinValue;
        }

        public Vehicle(Brand brand, Model model, Color color, string licencePlate, int displacement, int speed, DateTime registrationDate)
        {
            Brand = brand;
            Model = model;
            Color = color;
            LicencePlate = licencePlate;
            Displacement = displacement;
            Speed = speed;
            RegistrationDate = registrationDate;
        }

        public Vehicle(Color color, string licencePlate, int speed, DateTime registrationDate)
        {
            Brand = Brand.BOLIDE;
            Model = Model.ANO2000;
            Color = color;
            LicencePlate = licencePlate;
            Displacement = 1000;
            Speed = speed;
            RegistrationDate = registrationDate;
        }

        #endregion

        #region Create
        public void Create()
        {

            Console.WriteLine("Enter Vehicle data: ");
            Utility.BlockSeparator();

            BrandMenu();
            ReadBrand();
            Console.Clear();

            ModelMenu();
            ReadModel();
            Console.Clear();

            ColorMenu();
            ReadColor();
            Console.Clear();

            ReadLicencePlate();
            ReadDisplacement();
            ReadSpeed();
            ReadRegistrationDate();
        }

        #endregion

        #region Read Informations
        public void ReadBrand()
        {
            do
            {
                Utility.BlockSeparator();

                Console.Write("Brand: ");
                string brand = Console.ReadLine().ToUpper();
                ValidationBrand(brand);

            } while (Brand == 0);

        }

        public void ReadModel()
        {
            do
            {
                Utility.BlockSeparator();

                Console.Write("Model: ");
                string model = Console.ReadLine().ToUpper();
                ValidationModel(model);

            } while (Model == 0);
        }

        public void ReadColor()
        {
            do
            {
                Utility.BlockSeparator();

                Console.Write("Color: ");
                string color = Console.ReadLine().ToUpper();
                ValidationColor(color);

            } while (Color == 0);
        }

        public void ReadLicencePlate()
        {
            do
            {
                Utility.BlockSeparator();

                Console.Write("Licence Plate: ");
                LicencePlate = Console.ReadLine();

                if (LicencePlate == "")
                {
                    Console.WriteLine("Invalid value.Please enter a valid value.");
                }

            } while (LicencePlate == "");
        }

        public void ReadDisplacement()
        {
          
            do
            {
                Utility.BlockSeparator();

                try
                {
                    Console.Write("Displacement: ");
                    Displacement = int.Parse(Console.ReadLine());
                }
                catch
                (FormatException ex)
                {
                    Console.WriteLine("Invalid value. Please enter a valid value.");
                }
            } while (Displacement == 0);

        }

        public void ReadSpeed()
        {
            
            do
            {
                Utility.BlockSeparator();

                Console.Write("Speed: ");
                int speed = int.Parse(Console.ReadLine());
                ValidationSpeed(speed);

            } while (Speed == 0);
        }

        public void ReadRegistrationDate()
        {
            
            do
            {
                Utility.BlockSeparator();

                try
                {
                    Console.Write("RegistrationDate: ");
                    RegistrationDate = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid value. Please enter a valid value.");
                }

            }while(RegistrationDate == DateTime.MinValue);
        }
        #endregion

        #region Print Menus

        public static void VehiclesMenu()
        {
            Console.Clear();
            Console.WriteLine("Which vehicle do you want to add? ");

            Utility.BlockSeparator();

            Console.WriteLine("Submarine");
            Console.WriteLine("Car");
            Console.WriteLine("Plane");

            Utility.BlockSeparator();
        }
        public void BrandMenu()
        {
            Console.WriteLine("Brand Valid Options: ");

            Utility.BlockSeparator();

            foreach (Brand brand in Enum.GetValues(typeof(Brand)))
            {
                Console.WriteLine(brand.ToString());
            }
            Utility.BlockSeparator();
        }

        public void ModelMenu()
        {
            Console.WriteLine("Model Valid Options: ");

            Utility.BlockSeparator();

            foreach(Model model  in Enum.GetValues(typeof(Model)))
            {
                Console.WriteLine(model.ToString());
            }
            Utility.BlockSeparator();
        }

        public void ColorMenu()
        {
            Console.WriteLine("Color Valid Options: ");

            Utility.BlockSeparator();

            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine(color.ToString());
            }
            Utility.BlockSeparator();
        }
        #endregion

        #region Validation Read Methods

        public void ValidationBrand(string brand)
        {

            try
            {

                bool converted = Enum.TryParse<Brand>(brand, out Brand EnumValue);

                ValidationString(brand);

                if (converted)
                {
                    Brand selectedBrand = EnumValue;
                    Brand = selectedBrand;

                }

                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid brand value. Please enter a valid brand.");
            }
        }

        public void ValidationModel(string model)
        {
            try
            {

                bool converted = Enum.TryParse<Model>(model, out Model EnumValue);

                ValidationString(model);

                if (converted)
                {
                    Model selectedModel = EnumValue;
                    Model = selectedModel;

                }
                else
                {
                    throw new ArgumentException();
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid Model value. Please enter a valid Model.");
            }
        }

        public void ValidationColor(string color)
        {
            try
            {
                bool converted = Enum.TryParse<Color>(color, out Color EnumValue);
                ValidationString(color);

                if (converted)
                {
                    Color selectedColor = EnumValue;
                    Color = selectedColor;

                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid Color value. Please enter a valid Color.");
            }
        }

        public void ValidationString(string value)
        {
            bool convertNumber = int.TryParse(value, out int number);

            if (convertNumber)
            {
                throw new ArgumentException();
            }
        }


        public void ValidationSpeed(int speed)
        {
            try
            {
                if (speed > 200)
                {
                    throw new ArgumentException("Speed cannot be bigger than 200");
                }
                else if (speed < 0)
                {
                    throw new ArgumentException("Speed cannot be negative");
                }
                else
                {
                    Speed = speed;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Speed Methods
        public void SpeedDown(Vehicle vehicle, int value)
        {
            if (Speed > value)
            {
                vehicle.Speed -= value;
            }
            else if (Speed == 0)
            {
                vehicle.Speed = 0;
            }
            //diminui 1 de cada vez até zero
            else
            {
                vehicle.Speed -= 1;
            }

        }

        public void SpeedUp(Vehicle vehicle, int value)
        {
            if (Speed < 200)
            {
                vehicle.Speed += value;

                //valor maximo definido em 200
            }
            else if (Speed >= 200)
            {
                vehicle.Speed = 200;
            }

        }

        public void Stop(Vehicle vehicle)
        {
            vehicle.Speed = 0;
        }

        #endregion

        #region ToString
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Brand: " + Brand);
            sb.AppendLine("Model: " + Model);
            sb.AppendLine("Color: " + Color);
            sb.AppendLine("Licence Plate: " + LicencePlate);
            sb.AppendLine("Displacement: " + Displacement);
            sb.AppendLine("Speed: " + Speed);
            sb.AppendLine("Registration date: " + RegistrationDate.ToString("dd/MM/yyyy"));

            return sb.ToString();
        }

        #endregion
    }
}
