using _03.Telephony.Exceptions;
using _03.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Models
{
    public class Smartphone : Phone, IBrowsable
    {
        public Smartphone()
        {

        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }

        public override string Call(string phoneNumber)
        {
            return $"Calling... {base.Call(phoneNumber)}";
        }
    }
}
