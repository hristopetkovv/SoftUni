
namespace Cars
{
    using System;

    class CarCannotContinueException : Exception
    {
        public CarCannotContinueException(string message)
            : base(message)
        {

        }
    }
}
