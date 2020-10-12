using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                var elements = input.Split();

                var name = elements[0];
                var pokeName = elements[1];
                var pokeElement = elements[2];
                var pokeHealth = int.Parse(elements[3]);


                var trainer = trainers.FirstOrDefault(x => x.Name == name);

                if (trainer != null)
                {
                    trainer.Pokemon.Add(new Pokemon(pokeName, pokeElement, pokeHealth));
                }
                else
                {
                    var newTrainer = new Trainer(name);
                    newTrainer.Pokemon.Add(new Pokemon(pokeName, pokeElement, pokeHealth));
                    trainers.Add(newTrainer);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                switch (input)
                {
                    case "Fire":
                        foreach (var trainer in trainers)
                        {
                            if (trainer.Pokemon.Any(x => x.Element == input))
                            {
                                trainer.Badges++;
                            }
                            else
                            {
                                foreach (var pokemon in trainer.Pokemon)
                                {
                                    pokemon.Health -= 10;
                                }

                                trainer.Pokemon.RemoveAll(x => x.Health <= 0);
                            }
                        }
                        break;

                    case "Water":
                        foreach (var trainer in trainers)
                        {
                            if (trainer.Pokemon.Any(x => x.Element == input))
                            {
                                trainer.Badges++;
                            }
                            else
                            {
                                foreach (var pokemon in trainer.Pokemon)
                                {
                                    pokemon.Health -= 10;
                                }

                                trainer.Pokemon.RemoveAll(x => x.Health <= 0);
                            }
                        }
                        break;

                    case "Electricity":
                        foreach (var trainer in trainers)
                        {
                            if (trainer.Pokemon.Any(x => x.Element == input))
                            {
                                trainer.Badges++;
                            }
                            else
                            {
                                foreach (var pokemon in trainer.Pokemon)
                                {
                                    pokemon.Health -= 10;
                                }
                                trainer.Pokemon.RemoveAll(x => x.Health <= 0);

                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            var sorted = trainers.OrderByDescending(x => x.Badges);
            foreach (var trainer in sorted)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemon.Count}");
            }
        }
    }
}