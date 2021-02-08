using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLandisGyr.Classes;

namespace ExerciseLandisGyr.Model
{
    interface IEndpointModel
    {
        public void Insert(Endpoint endpoint);
        public void Edit(Endpoint endpoint);
        public Endpoint Find(string serialNumber);
        public List<Endpoint> List();
        public void Remove(Endpoint endpoint);
    }
}
