﻿

namespace TeledocTestTask.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string Message) : base(Message)
        {

        }
    }
}
