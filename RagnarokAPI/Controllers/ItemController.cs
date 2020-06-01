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
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public ActionResult<ItemCollection> Create(ItemCollection item)
        {
            _itemService.Create(item);

            return CreatedAtRoute("GetItems", new { id = item.Id.ToString() }, item);
        }

        [HttpPost]
        public ActionResult<ItemCollection> Create(List<ItemCollection> item)
        {
            _itemService.Create(item);

            //return CreatedAtRoute("GetItems", new { id = item.Id.ToString() }, item);
            return null;
        }

        [HttpGet]
        public ActionResult<List<ItemCollection>> Get() => _itemService.Get();

        [HttpGet("{id}", Name = "GetItems")]
        public ActionResult<ItemCollection> Get(int id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ItemCollection itemIn)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(int id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Remove(item.Id);

            return NoContent();
        }

    }
}
