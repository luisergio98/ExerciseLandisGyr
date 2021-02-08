using System;

namespace ExerciseLandisGyr.Classes
{
    public class Endpoint
    {
        public Endpoint()
        {
            
        }

        public string SerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public int SwitchState { get; set; }
    }

}

