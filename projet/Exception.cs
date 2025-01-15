using System;

namespace monPotager
{
    public class InvalidPlanteException : Exception
    {
            public InvalidPlanteException(string message) : base(message)
        {
        }
    }
}