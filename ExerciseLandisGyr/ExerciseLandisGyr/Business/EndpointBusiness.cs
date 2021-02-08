using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLandisGyr.Classes;
using ExerciseLandisGyr.Model;
using ExerciseLandisGyr.Enumerators;
using System.Linq;

namespace ExerciseLandisGyr.Business
{
    public class EndpointBusiness : IEndpointBusiness
    {
        private readonly EndpointModel _model;
        private readonly EndpointBase _base;
        public EndpointBusiness(ref EndpointBase endpointBase)
        {
            _model = new EndpointModel(ref endpointBase);
            _base = endpointBase;
        }

        public void Edit()
        {
            try
            {
                var endpoint = new Endpoint();
                Console.Clear();
                Console.WriteLine("\nEditing a endpoint");

                Console.WriteLine("Enter the serial number to find a endpoint:");
                endpoint = _model.Find(Console.ReadLine());
                if (endpoint != null)
                {
                    Console.WriteLine("Change the switch state (disconnected, connected or armed):");
                    var inputTest = Console.ReadLine().ToUpper();
                    if (Enum.IsDefined(typeof(SwitchState), inputTest))
                    {
                        endpoint.SwitchState = (int)Enum.Parse(typeof(SwitchState), inputTest);
                    }
                    else
                    {
                        throw new UserExceptions.InvalidInputException("Invalid input for a switch state!");
                    }

                    _model.Edit(endpoint);
                    Console.WriteLine("\nEndpoint edited!");
                    ReturnToMenu();
                }
                else
                {
                    Console.WriteLine("\nNo endpoint found!");
                    ReturnToMenu();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.WriteLine("\nSelect an option to continue:");
                Console.WriteLine("1) Try again");
                Console.WriteLine("2) Exit");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Edit();
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("\nAre you sure you want to exit program? All endpoints will be lost! (Yes/No)");
            var input = Console.ReadLine().ToUpper();
            if (input == "YES" || input == "Y")
            {
                Environment.Exit(0);
            }

            ReturnToMenu();
        }

        public void Find()
        {
            var endpoint = new Endpoint();
            Console.Clear();
            Console.WriteLine("\nFinding a endpoint");
            Console.WriteLine("Enter the serial number:");
            endpoint = _model.Find(Console.ReadLine());
            if(endpoint != null)
            {
                Console.WriteLine("\nEndpoint found!");
                Console.WriteLine("\nSerial Number: " + endpoint.SerialNumber);
                Console.WriteLine("Meter Model Id: " + Enum.GetName(typeof(MeterModel), endpoint.MeterModelId));
                Console.WriteLine("Meter Number: " + endpoint.MeterNumber);
                Console.WriteLine("Meter Firmware Version: " + endpoint.MeterFirmwareVersion);
                Console.WriteLine("Switch State: " + Enum.GetName(typeof(SwitchState), endpoint.SwitchState));

                ReturnToMenu();
            } else
            {
                Console.WriteLine("\nNo endpoint found!");
                ReturnToMenu();
            }
        }

        public void Insert()
        {
            try
            {
                var endpoint = new Endpoint();
                string inputTest;
                Console.Clear();
                Console.WriteLine("\nInserting a new endpoint");

                Console.WriteLine("Enter the serial number:");
                inputTest = Console.ReadLine();
                if (_model.Find(inputTest) != null)
                {
                    throw new UserExceptions.EndpointException("Already have a endpoint with this serial number!");
                }
                else
                {
                    endpoint.SerialNumber = inputTest;
                }

                Console.WriteLine("Enter the meter model id (NSX1P2W, NSX1P3W, NSX2P3W or NSX3P4W):");
                inputTest = Console.ReadLine().ToUpper();
                if (Enum.IsDefined(typeof(MeterModel), inputTest))
                {
                    endpoint.MeterModelId = (int)Enum.Parse(typeof(MeterModel), inputTest);
                }
                else
                {
                    throw new UserExceptions.InvalidInputException("Invalid input for a meter model id!");
                }

                Console.WriteLine("Enter the meter number:");
                inputTest = Console.ReadLine();
                if (int.TryParse(inputTest, out _))
                {
                    endpoint.MeterNumber = int.Parse(inputTest);
                }
                else
                {
                    throw new UserExceptions.InvalidInputException("Invalid input for a meter number!");
                }

                Console.WriteLine("Enter the meter firmware version:");
                endpoint.MeterFirmwareVersion = Console.ReadLine();

                Console.WriteLine("Enter the switch state (disconnected, connected or armed):");
                inputTest = Console.ReadLine().ToUpper();
                if (Enum.IsDefined(typeof(SwitchState), inputTest))
                {
                    endpoint.SwitchState = (int)Enum.Parse(typeof(SwitchState), inputTest);
                }
                else
                {
                    throw new UserExceptions.InvalidInputException("Invalid input for a switch state!");
                }

                _model.Insert(endpoint);
                Console.WriteLine("\nEndpoint added!");
                ReturnToMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.WriteLine("\nSelect an option to continue:");
                Console.WriteLine("1) Try again");
                Console.WriteLine("2) Exit");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Insert();
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }

        public void List()
        {
            Console.Clear();
            if (_base.EndpointList.Any())
            {
                Console.WriteLine("Listing all endpoints:");
                foreach (var endpoint in _model.List())
                {
                    Console.WriteLine("\nSerial Number: " + endpoint.SerialNumber);
                    Console.WriteLine("Meter Model Id: " + Enum.GetName(typeof(MeterModel), endpoint.MeterModelId));
                    Console.WriteLine("Meter Number: " + endpoint.MeterNumber);
                    Console.WriteLine("Meter Firmware Version: " + endpoint.MeterFirmwareVersion);
                    Console.WriteLine("Switch State: " + Enum.GetName(typeof(SwitchState), endpoint.SwitchState));
                }
                ReturnToMenu();
            } else
            {
                Console.WriteLine("\nNo endpoints found!");
                ReturnToMenu();
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\nEndpoint Manager");
            Console.WriteLine("Select an option to continue:");
            Console.WriteLine("1) Insert a new endpoint");
            Console.WriteLine("2) Edit an existing endpoint");
            Console.WriteLine("3) Delete an existing endpoint");
            Console.WriteLine("4) List all endpoints");
            Console.WriteLine("5) Find a endpoint by 'Endpoint Serial Number'");
            Console.WriteLine("6) Exit");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Insert();
                    break;
                case "2":
                    Edit();
                    break;
                case "3":
                    Remove();
                    break;
                case "4":
                    List();
                    break;
                case "5":
                    Find();
                    break;
                case "6":
                    Exit();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("\nRemoving a endpoint");
            Console.WriteLine("Enter the endpoint's serial number:");
            var endpoint = _model.Find(Console.ReadLine());
            if (endpoint != null)
            {
                Console.WriteLine("\nAre you sure you want to remove this endpoint? (Yes/No)");
                var input = Console.ReadLine().ToUpper();
                if (input == "YES" || input == "Y")
                {
                    _model.Remove(endpoint);
                    Console.WriteLine("\nEndpoint removed.");
                }

                ReturnToMenu();
            }
            else
            {
                Console.WriteLine("\nNo endpoint found!");
                ReturnToMenu();
            }
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
            Menu();
        }
    }
}
