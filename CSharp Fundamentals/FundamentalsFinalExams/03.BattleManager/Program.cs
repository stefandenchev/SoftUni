using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BattleManager
{
    class Stats
    {
        public int HP { get; set; }
        public int EP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stats> players = new Dictionary<string, Stats>();
            string input = Console.ReadLine();

            while (input != "Results")
            {
                var elements = input.Split(":");
                var name = elements[1];

                if (input.Contains("Add"))
                {
                    var hp = int.Parse(elements[2]);
                    var ep = int.Parse(elements[3]);

                    if (!players.ContainsKey(name))
                    {
                        Stats stats = new Stats { HP = hp, EP = ep };
                        players.Add(name, stats);
                    }
                    else
                    {
                        players[name].HP += hp;
                    }
                }

                if (input.Contains("Attack"))
                {
                    var defender = elements[2];
                    int damage = int.Parse(elements[3]);

                    if (players.ContainsKey(name) && players.ContainsKey(defender))
                    {
                        players[defender].HP -= damage;
                        players[name].EP--;
                        if (players[defender].HP <= 0)
                        {
                            players.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }
                        if (players[name].EP <= 0)
                        {
                            players.Remove(name);
                            Console.WriteLine($"{name} was disqualified!");
                        }
                    }
                }

                if (input.Contains("Delete"))
                {
                    if (players.ContainsKey(name))
                    {
                        players.Remove(name);
                    }
                    if (name == "All")
                    {
                        players.Clear();
                    }
                }
                input = Console.ReadLine();
            }

            var sortedPlayers = players.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key);

            Console.WriteLine($"People count: {players.Count}");

            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{player.Key} - {player.Value.HP} - {player.Value.EP}");
            }
        }
    }
}