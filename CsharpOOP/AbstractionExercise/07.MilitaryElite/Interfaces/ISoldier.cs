﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ISoldier
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}