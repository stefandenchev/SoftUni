using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary<string, int> heroesAndHP
            // Dictionary<string, int> heroesAndMP

            // Dictionary<string, int[]> dict = new Dictionary<string, int[]>(); //  OR LIST

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string heroName = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);
                Hero hero = new Hero() { HP = hp, MP = mp };
                heroes.Add(heroName, hero);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command.Contains("CastSpell"))
                {
                    var elements = command.Split(" - ");
                    string name = elements[1];
                    int mpNeeded = int.Parse(elements[2]);
                    string spellName = elements[3];

                    if (heroes[name].MP - mpNeeded >= 0)
                    {
                        heroes[name].MP -= mpNeeded;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }

                if (command.Contains("TakeDamage"))
                {
                    var elements = command.Split(" - ");
                    string name = elements[1];
                    int damage = int.Parse(elements[2]);
                    string attacker = elements[3];

                    heroes[name].HP -= damage;
                    if (heroes[name].HP > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        //heroes.Remove(heroes[name]);
                    }
                }

                if (command.Contains("Recharge"))
                {
                    var elements = command.Split(" - ");
                    string name = elements[1];
                    int recharge = int.Parse(elements[2]);

                    if (heroes[name].MP + recharge > 200)
                    {
                        recharge = 200 - heroes[name].MP;
                    }
                    heroes[name].MP += recharge;
                    Console.WriteLine($"{name} recharged for {recharge} MP!");
                }

                if (command.Contains("Heal"))
                {
                    var elements = command.Split(" - ");
                    string name = elements[1];
                    int recharge = int.Parse(elements[2]);

                    if (heroes[name].HP + recharge > 100)
                    {
                        recharge = 100 - heroes[name].HP;
                    }

                    heroes[name].HP += recharge;
                    Console.WriteLine($"{name} healed for {recharge} HP!");
                }

                command = Console.ReadLine();
            }

            var sortedHeroes = heroes.OrderByDescending(h => h.Value.HP)
                .ThenBy(h => h.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var hero in sortedHeroes)
            {
                if (hero.Value.HP > 0)
                {
                    Console.WriteLine(hero.Key);
                    Console.WriteLine($"  HP: {hero.Value.HP}");
                    Console.WriteLine($"  MP: {hero.Value.MP}");
                }
            }

        }
    }
}