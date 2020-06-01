using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RagnarokAPI.Models;
using RagnarokAPI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RagnarokAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly MonsterService _monsterService;

        public MonsterController(MonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        [HttpPost]
        public ActionResult<MonsterCollection> Create(List<MonsterCollection> monsters)
        {
            _monsterService.Create(monsters);

            //return CreatedAtRoute("GetItems", new { id = item.Id.ToString() }, item);
            return null;
        }

        [HttpGet]
        public ActionResult<List<MonsterCollection>> Get() => _monsterService.Get();

        [HttpGet("{id}", Name = "GetMonsters")]
        public ActionResult<MonsterCollection> Get(string id)
        {
            var item = _monsterService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, MonsterCollection itemIn)
        {
            var item = _monsterService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _monsterService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var item = _monsterService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _monsterService.Remove(item.Id);

            return NoContent();
        }
    }
}
