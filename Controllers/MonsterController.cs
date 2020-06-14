﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RagnarokAPI.Models;
using RagnarokAPI.Service;

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
    }
}
