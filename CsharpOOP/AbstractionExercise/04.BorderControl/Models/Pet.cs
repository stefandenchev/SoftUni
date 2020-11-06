using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Pet : IEntity, IAlive
    {
        public Pet(string id, string birthdate)
        {
            Id = id;
            Birthdate = birthdate;
        }
        public string Id { get; set; }
        public string Birthdate { get; set; }

    }
}
