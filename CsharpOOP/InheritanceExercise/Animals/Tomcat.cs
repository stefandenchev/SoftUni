using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DEFAULT_GENDER = "Male";
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get
            {
                return DEFAULT_GENDER;
            }
            protected set
            {
                base.Gender = value;
            }
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}