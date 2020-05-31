using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnarokAPI.ViewModel
{
    public class MonsterViewModel
    {
        public string MonsterId { get; set; }

        public string MonsterName { get; set; }

        public string MonsterGifUrl { get; set; }

        public List<ItemViewModel> MonsterDrops { get; set; }

        public Stats MonsterStats { get; set; }

        public Element ElementExtraDamage { get; set; }

        public List<Spawn> MonsterSpawnMaps { get; set; }
    }

    public class Spawn
    {
        public string MapId { get; set; }

        public string MapName { get; set; }
    }

    public class Stats
    {
        public int? MonsterLevel { get; set; }

        public int? MonsterHp { get; set; }

        public int? MonsterSize { get; set; }

        public int? MonsterRace { get; set; }
    }

    public class Element
    {
        public int Neutral { get; set; }

        public int Water { get; set; }

        public int Earth { get; set; }

        public int Fire { get; set; }

        public int Wind { get; set; }

        public int Poison { get; set; }

        public int Holy { get; set; }

        public int Dark { get; set; }

        public int Ghost { get; set; }

        public int Undead { get; set; }
    }
}
