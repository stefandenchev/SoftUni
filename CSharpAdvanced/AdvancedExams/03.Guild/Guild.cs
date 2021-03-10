using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player toRemove = roster.FirstOrDefault(x => x.Name == name);
            return roster.Remove(toRemove);
        }

        public void PromotePlayer(string name)
        {
            Player toPromote = roster.FirstOrDefault(x => x.Name == name);
            toPromote.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player toPromote = roster.FirstOrDefault(x => x.Name == name);
            toPromote.Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string Class)
        {
            List<Player> kicked = new List<Player>();

            foreach (var player in roster.ToList())
            {
                if (player.Class == Class)
                {
                    kicked.Add(player);
                }
            }
            return kicked.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
