using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLandisGyr.Classes;

namespace ExerciseLandisGyr.Model
{
    public class EndpointModel : IEndpointModel
    {
        private readonly EndpointBase _endpointBase;
        public EndpointModel(ref EndpointBase endpointBase)
        {
            _endpointBase = endpointBase;
        }

        public void Edit(Endpoint endpoint)
        {
            var index = _endpointBase.EndpointList.FindIndex(x => x.SerialNumber == endpoint.SerialNumber);
            _endpointBase.EndpointList[index] = endpoint;
        }

        public Endpoint Find(string serialNumber)
        {
            return _endpointBase.EndpointList.Find(x => x.SerialNumber == serialNumber);
        }

        public void Insert(Endpoint endpoint)
        {
            _endpointBase.EndpointList.Add(endpoint);
        }

        public List<Endpoint> List()
        {
            return _endpointBase.EndpointList;
        }

        public void Remove(Endpoint endpoint)
        {
            _endpointBase.EndpointList.Remove(endpoint);
        }
    }
}
