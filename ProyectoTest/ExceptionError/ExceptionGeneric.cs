using System;
/**
 * Sebastian Gonzalez
 * 
 * */
namespace ProyectoTest.ExceptionError
{
    public class ExceptionGeneric : Exception
    {
        public ExceptionGeneric(string message)
        : base(message)
        {

        }

        public ExceptionGeneric(string message, Exception inner)
            : base(message, inner)
        {

        }

    }
}
