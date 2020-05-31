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
    public class MonstersController : ControllerBase
    {
        private readonly MonstersService _monstersService;

        public MonstersController(MonstersService monstersService)
        {
            _monstersService = monstersService;
        }

        [HttpPost]
        public ActionResult<MonstersCollection> Create(List<MonstersCollection> monsters)
        {
            _monstersService.Create(monsters);

            //return CreatedAtRoute("GetItems", new { id = item.Id.ToString() }, item);
            return null;
        }

        [HttpGet]
        public ActionResult<List<MonstersCollection>> Get() => _monstersService.Get();

        [HttpGet("{id}", Name = "GetMonsters")]
        public ActionResult<MonstersCollection> Get(string id)
        {
            var item = _monstersService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, MonstersCollection itemIn)
        {
            var item = _monstersService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _monstersService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var item = _monstersService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _monstersService.Remove(item.Id);

            return NoContent();
        }
    }
}
