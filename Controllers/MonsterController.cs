using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RagnarokAPI.Models;
using RagnarokAPI.Service;

namespace RagnarokAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MonsterController : ControllerBase
    {
        private readonly MonsterService _monsterService;

        public MonsterController(MonsterService monsterService)
        {
            _monsterService = monsterService;
        }

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
    }
}
