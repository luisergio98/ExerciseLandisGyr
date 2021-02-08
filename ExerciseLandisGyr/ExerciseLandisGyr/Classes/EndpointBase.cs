using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseLandisGyr.Classes
{
    public class EndpointBase
    {
        public EndpointBase()
        {
            EndpointList = new List<Endpoint>();
        }

        public List<Endpoint> EndpointList { get; set; }
    }
}
