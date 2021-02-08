using System;
using ExerciseLandisGyr.Classes;
using ExerciseLandisGyr.Business;

namespace TesteLandisGyr
{
    class Program
    {

        static void Main(string[] args)
        {
            var database = new EndpointBase();
            var business = new EndpointBusiness(ref database);

            business.Menu();
        }

    }
}
