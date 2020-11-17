using System;
namespace src
{
    public class UnableToLocateCustomerException : Exception
    {
        public UnableToLocateCustomerException(String message):base (message)
        {
        }
    }
}
