using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RagnarokAPI.Models;
using RagnarokAPI.Service;
using RagnarokAPI.ViewModel;
using Element = RagnarokAPI.ViewModel.Element;
using Spawn = RagnarokAPI.ViewModel.Spawn;
using Stats = RagnarokAPI.ViewModel.Stats;

namespace RagnarokAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly MonsterService _monsterService;
        private readonly ItemService _itemService;

        public MonsterController(MonsterService monsterService, ItemService itemService)
        {
            _monsterService = monsterService;
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<MonsterViewModel>> Get()
        {
            var monsterList = new List<MonsterViewModel>();

            foreach (var monster in _monsterService.Get())
            {
                monsterList.Add(CreateMonsterView(monster));
            }
            return monsterList;
        }

        [HttpGet("{id}", Name = "GetMonster")]
        public ActionResult<MonsterViewModel> Get(string id)
        {
            var monster = _monsterService.Get(id);

            if (monster == null)
            {
                return NotFound();
            }

            return CreateMonsterView(monster);
        }

        private MonsterViewModel CreateMonsterView(Monster monster)
        {
            var elements = new Element
            {
                Dark = monster.Stats.Element.Dark,
                Earth = monster.Stats.Element.Earth,
                Fire = monster.Stats.Element.Fire,
                Ghost = monster.Stats.Element.Ghost,
                Holy = monster.Stats.Element.Holy,
                Neutral = monster.Stats.Element.Neutral,
                Poison = monster.Stats.Element.Poison,
                Undead = monster.Stats.Element.Undead,
                Water = monster.Stats.Element.Water,
                Wind = monster.Stats.Element.Wind
            };

            var stats = new Stats()
            {
                MonsterHp = monster.Stats.Hp,
                MonsterLevel = monster.Stats.Level,
                MonsterRace = monster.Stats.Race,
                MonsterSize = monster.Stats.Scale
            };

            var maps = new List<Spawn>();

            if (monster.Spawns != null)
                foreach (var map in monster.Spawns)
                {
                    maps.Add(new Spawn()
                    {
                        MapId = map.Map.MapId,
                        MapName = map.Map.Name,
                    });
                }

            var monsterView = new MonsterViewModel()
            {
                MonsterId = monster.IdMonstro,
                MonsterName = monster.Name.Name,
                MonsterGifUrl = monster.Image.GifUrl,
                MonsterDrops = monster.Drop.Normal != null ? _itemService.Get(monster.Drop.Normal.Select(x => x.Item.IdItem).ToList()) : null,
                ElementExtraDamage = elements,
                MonsterStats = stats,
                MonsterSpawnMaps = maps
            };

            return monsterView;
        }

        [HttpPost]
        public ActionResult<Monster> Create(Monster monster)
        {
            _monsterService.Create(monster);

            return CreatedAtRoute("GetMonster", new {id = monster.Id.ToString()}, monster);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Monster monsterIn)
        {
            var monster = _monsterService.Get(id);

            if (monster == null)
            {
                return NotFound();
            }

            _monsterService.Update(id, monsterIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var monster = _monsterService.Get(id);

            if (monster == null)
            {
                return NotFound();
            }

            _monsterService.Remove(monster.Id);

            return NoContent();
        }
    }
}