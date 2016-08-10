using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	class Program
	{
		//static string reg_Nr, color, manufacturer;
		//static int parsedTopSpeedInt, parsedNumberOfWheelsInt;

		
		static void Main(string[] args)
		{
			BankHandler bankHandler = new BankHandler();

			//foreach (Vehicle v in garage)
			//{
			//	Console.WriteLine(v);
			//}

			int parsedInt = 1;

			while (parsedInt != 0)
			{
				Console.WriteLine("\n*********************************************************");
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7 or 0) of your choice:\n"
				+ "\n1. Display a list of all accounts."
				+ "\n2. Display the balance of a specific account."
				+ "\n3. Display transaction history for a specific account."
				+ "\n4. Make account deposit."
				+ "\n5. Make account withdrawal."
				+ "\n6. Make transfer between accounts."
				+ "\n7. Lock an account."
				+ "\n0. Exit the application");


				while (!int.TryParse(Console.ReadLine(), out parsedInt))
				{
					Console.WriteLine("Try again:");
				}

				switch (parsedInt)
				{
					case 1:
						int parsedCapacityInt;

						Console.Clear();
						Console.WriteLine("Decide the capacity of the Garage:");

						while (!int.TryParse(Console.ReadLine(), out parsedCapacityInt))
						{
							Console.WriteLine("Try again:");
						}

						garage = new Garage<Vehicle>(parsedCapacityInt);

						garage.addVehicleToGarage(vehicle1);
						garage.addVehicleToGarage(vehicle2);
						garage.addVehicleToGarage(vehicle3);
						garage.addVehicleToGarage(vehicle4);
						garage.addVehicleToGarage(vehicle5);
						garage.addVehicleToGarage(vehicle6);
						garage.addVehicleToGarage(vehicle7);
						garage.addVehicleToGarage(vehicle8);

						Console.WriteLine("Created a new garage with " + parsedCapacityInt + " parking slots!");

						break;
					case 2:
						int parsedIDInt;

						Console.Clear();
						Console.WriteLine("Type the ID of the vehicletype you want to add:\n1. Airplane \n2. Motorcycle" +
											"\n3. Car \n4. Bus \n5. Boat");

						while (!int.TryParse(Console.ReadLine(), out parsedIDInt) || (parsedIDInt < 1 || parsedIDInt > 5))
						{
							Console.WriteLine("Try again:");
						}

						switch (parsedIDInt)
						{
							case 1:
								string isJetplane;
								double parsedWingspanDouble;
								bool boolIsJetplane = false;

								Program.scanBaseProperties();

								Console.WriteLine("Is it a jetplane? Type 'y' or 'n':");
								isJetplane = Console.ReadLine();
								if (isJetplane.Equals("y"))
								{
									boolIsJetplane = true;
								}

								Console.WriteLine("Enter the wingspan:");
								while (!double.TryParse(Console.ReadLine(), out parsedWingspanDouble))
								{
									Console.WriteLine("Try again:");
								}

								Airplane airplane = new Airplane("Airplane", reg_Nr, color, manufacturer, parsedTopSpeedInt, parsedNumberOfWheelsInt,
									boolIsJetplane, parsedWingspanDouble);
								garage.addVehicleToGarage(airplane);

								break;
							case 2:
								string gotSidewagon;
								double parsedCylinderVolumeDouble;
								bool boolGotSidewagon = false;

								Program.scanBaseProperties();

								Console.WriteLine("Enter the cylinder volume:");
								while (!double.TryParse(Console.ReadLine(), out parsedCylinderVolumeDouble))
								{
									Console.WriteLine("Try again:");
								}

								Console.WriteLine("Does the motorcycle have a sidewagon? Type 'y' or 'n':");
								gotSidewagon = Console.ReadLine();
								if (gotSidewagon.Equals("y"))
								{
									boolGotSidewagon = true;
								}

								Motorcycle motorcycle = new Motorcycle("Motorcycle", reg_Nr, color, manufacturer, parsedTopSpeedInt,
									parsedNumberOfWheelsInt, parsedCylinderVolumeDouble, boolGotSidewagon);
								garage.addVehicleToGarage(motorcycle);

								break;
							case 3:
								string gotElectricEngine;
								int parsedNumberOfDoorsInt;
								bool boolGotElectricEngine = false;

								Program.scanBaseProperties();

								Console.WriteLine("Enter number of doors:");
								while (!int.TryParse(Console.ReadLine(), out parsedNumberOfDoorsInt))
								{
									Console.WriteLine("Try again:");
								}

								Console.WriteLine("Does the car have an electric engine? Type 'y' or 'n':");
								gotElectricEngine = Console.ReadLine();
								if (gotElectricEngine.Equals("y"))
								{
									boolGotElectricEngine = true;
								}

								Car car = new Car("Car", reg_Nr, color, manufacturer, parsedTopSpeedInt, parsedNumberOfWheelsInt,
									parsedNumberOfDoorsInt, boolGotElectricEngine);
								garage.addVehicleToGarage(car);

								break;
							case 4:
								string isDoubleDecker;
								int parsedPassengerCapacityInt;
								bool boolIsDoubleDecker = false;

								Program.scanBaseProperties();

								Console.WriteLine("Is the bus a doubledecker? Type 'y' or 'n':");
								isDoubleDecker = Console.ReadLine();
								if (isDoubleDecker.Equals("y"))
								{
									boolIsDoubleDecker = true;
								}

								Console.WriteLine("Enter the passenger capacity:");
								while (!int.TryParse(Console.ReadLine(), out parsedPassengerCapacityInt))
								{
									Console.WriteLine("Try again:");
								}

								Bus bus = new Bus("Bus", reg_Nr, color, manufacturer, parsedTopSpeedInt, parsedNumberOfWheelsInt,
									boolIsDoubleDecker, parsedPassengerCapacityInt);
								garage.addVehicleToGarage(bus);

								break;
							case 5:
								string isSailBoat;
								int parsedNumberOfPropellersInt;
								bool boolIsSailBoat = false;

								Program.scanBaseProperties();

								Console.WriteLine("Enter the number of propellers:");
								while (!int.TryParse(Console.ReadLine(), out parsedNumberOfPropellersInt))
								{
									Console.WriteLine("Try again:");
								}

								Console.WriteLine("Is the boat a sailboat? Type 'y' or 'n':");
								isSailBoat = Console.ReadLine();
								if (isSailBoat.Equals("y"))
								{
									boolIsSailBoat = true;
								}

								Boat boat = new Boat("Boat", reg_Nr, color, manufacturer, parsedTopSpeedInt, parsedNumberOfWheelsInt,
									parsedNumberOfPropellersInt, boolIsSailBoat);
								garage.addVehicleToGarage(boat);

								break;
							default:
								Console.WriteLine("\nPlease enter some valid input (1, 2, 3, 4, or 5)\n");

								break;
						}

						break;
					case 3:
						Console.Clear();
						garage.sortAndGetAllVehiclesInGarage();

						foreach (Vehicle v in garage)
						{
							Console.WriteLine(v);
						}

						break;
					case 4:
						string[] parametersArray = new string[4];

						Console.Clear();
						Console.WriteLine("Type in the parameters you want to include in the filtering.\nIf you want to leave any " +
											"parameter out, type '!': \n1. Color \n2. Manufacturer" +
											"\n3. Top speed \n4. Number of wheels");

						for (int i = 1; i < 5; i++)
						{
							Console.Write(i + ": ");
							parametersArray[i - 1] = Console.ReadLine();
						}

						List<Vehicle> tmpList = garage.getAllVehiclesByOptionalColorManufacturerTopSpeedNumberOfWheels(parametersArray[0],
							parametersArray[1], parametersArray[2], parametersArray[3]);

						Console.WriteLine(tmpList.Count + " vehicles matches the criteria:\n");

						foreach (Vehicle v in tmpList)
						{
							Console.WriteLine(v);
						}

						break;
					case 5:
						Console.Clear();
						Console.WriteLine("What type of vehicle do you want to search for?");
						string vehicleType = Console.ReadLine();

						tmpList = garage.getAllVehiclesByType(vehicleType);
						Console.WriteLine(tmpList.Count + " vehicles matches the criteria:\n");

						foreach (Vehicle v in tmpList)
						{
							Console.WriteLine(v);
						}

						break;
					case 6:
						Console.Clear();
						Console.WriteLine("Type the registration number of the vehicle you want to list:");
						string registrationNumber = Console.ReadLine();

						Vehicle vehicle = garage.getVehicleByRegistrationNumber(registrationNumber);

						Console.WriteLine(vehicle);

						break;
					case 7:
						Console.Clear();
						garage.sortAndGetAllVehiclesInGarage();

						foreach (Vehicle v in garage)
						{
							Console.WriteLine(v);
						}

						Console.WriteLine("\nType the registration number of the vehicle you want to remove:");
						registrationNumber = Console.ReadLine();

						garage.removeVehicleByRegistrationNumber(registrationNumber);

						break;
					case 0:
						return;

					default:
						Console.WriteLine("\nPlease enter some valid input (1, 2, 3, 4, 5, 6, 7 or 0)\n");

						break;
				}
			}

			Console.ReadKey();
		}
	}
}
