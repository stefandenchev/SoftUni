using _03.Telephony.Exceptions;
using _03.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Models
{
    public class StationaryPhone : Phone
    {
        public sealed override string Call(string phoneNumber)
        {
            return $"Dialing... {base.Call(phoneNumber)}";
        }
    }
}
