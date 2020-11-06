﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string INVALID_PHONE_NUMBER_EXCEPTION_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException() : base(INVALID_PHONE_NUMBER_EXCEPTION_MESSAGE)
        {

        }
    }
}
