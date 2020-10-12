using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemon = new List<Pokemon>();
        }

        private string name;
        private int badges = 0;
        private List<Pokemon> pokemon;

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}
