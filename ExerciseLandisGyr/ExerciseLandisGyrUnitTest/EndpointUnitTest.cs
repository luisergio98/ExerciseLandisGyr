using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExerciseLandisGyr.Classes;
using ExerciseLandisGyr.Model;
using ExerciseLandisGyr.Enumerators;
using System.Linq;

namespace ExerciseLandisGyrUnitTest
{
    [TestClass]
    public class EndpointUnitTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var database = new EndpointBase();
            var model = new EndpointModel(ref database);

            model.Insert(new Endpoint{ 
                MeterFirmwareVersion = "1234", 
                MeterModelId = (int)MeterModel.NSX1P2W, 
                MeterNumber = 1234, SerialNumber = "1234", 
                SwitchState = (int)SwitchState.CONNECTED });
        }

        public void EditTest()
        {
            var database = new EndpointBase();
            var model = new EndpointModel(ref database);

            model.Insert(new Endpoint
            {
                MeterFirmwareVersion = "1234",
                MeterModelId = (int)MeterModel.NSX1P2W,
                MeterNumber = 1234,
                SerialNumber = "1234",
                SwitchState = (int)SwitchState.CONNECTED
            });

            model.Edit(new Endpoint
            {
                MeterFirmwareVersion = "4321",
                MeterModelId = (int)MeterModel.NSX1P3W,
                MeterNumber = 4321,
                SerialNumber = "4321",
                SwitchState = (int)SwitchState.ARMED
            });
        }

        public void RemoveTest()
        {
            var database = new EndpointBase();
            var model = new EndpointModel(ref database);

            model.Insert(new Endpoint
            {
                MeterFirmwareVersion = "1234",
                MeterModelId = (int)MeterModel.NSX1P2W,
                MeterNumber = 1234,
                SerialNumber = "1234",
                SwitchState = (int)SwitchState.CONNECTED
            });

            model.Remove(new Endpoint
            {
                MeterFirmwareVersion = "1234",
                MeterModelId = (int)MeterModel.NSX1P2W,
                MeterNumber = 1234,
                SerialNumber = "1234",
                SwitchState = (int)SwitchState.CONNECTED
            });
        }

        public void ListTest()
        {
            var database = new EndpointBase();
            var model = new EndpointModel(ref database);

            model.Insert(new Endpoint
            {
                MeterFirmwareVersion = "1234",
                MeterModelId = (int)MeterModel.NSX1P2W,
                MeterNumber = 1234,
                SerialNumber = "1234",
                SwitchState = (int)SwitchState.CONNECTED
            });

            model.Insert(new Endpoint
            {
                MeterFirmwareVersion = "4321",
                MeterModelId = (int)MeterModel.NSX1P3W,
                MeterNumber = 4321,
                SerialNumber = "4321",
                SwitchState = (int)SwitchState.ARMED
            });

            var list = model.List();

            if (list.Any())
            {
                database.EndpointList = list;
            }
        }
    }
}
