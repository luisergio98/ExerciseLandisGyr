using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseLandisGyr.UserExceptions
{
    public class EndpointException : Exception
    {
        public EndpointException()
        {
        }

        public EndpointException(string message)
        : base(message)
        {
        }

        public EndpointException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
