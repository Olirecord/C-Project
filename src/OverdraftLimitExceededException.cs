using System;
namespace src
{
    public class OverdraftLimitExceededException : Exception
    {
        public OverdraftLimitExceededException(string message) : base(message)
        {

        }
    }
}
