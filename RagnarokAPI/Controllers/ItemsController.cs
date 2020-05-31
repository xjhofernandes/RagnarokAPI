using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RagnarokAPI.Models;
using RagnarokAPI.Service;
using RagnarokAPI.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RagnarokAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemsService;

        public ItemsController(ItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpPost]
        public ActionResult<ItemsCollection> Create(ItemsCollection item)
        {
            _itemsService.Create(item);

            return CreatedAtRoute("GetItems", new { id = item.Id.ToString() }, item);
        }

        [HttpPost]
        public ActionResult<ItemsCollection> Create(List<ItemsCollection> item)
        {
            _itemsService.Create(item);

            //return CreatedAtRoute("GetItems", new { id = item.Id.ToString() }, item);
            return null;
        }

        [HttpGet]
        public ActionResult<List<ItemsCollection>> Get() => _itemsService.Get();

        [HttpGet("{id}", Name = "GetItems")]
        public ActionResult<ItemsCollection> Get(int id)
        {
            var item = _itemsService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ItemsCollection itemIn)
        {
            var item = _itemsService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemsService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(int id)
        {
            var item = _itemsService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemsService.Remove(item.Id);

            return NoContent();
        }

    }
}
