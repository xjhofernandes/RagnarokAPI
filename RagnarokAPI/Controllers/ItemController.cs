using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RagnarokAPI.Models;
using RagnarokAPI.Models.Items;
using RagnarokAPI.Service;
using RagnarokAPI.ViewModel;

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

        [HttpGet]
        public ActionResult<List<ItemViewModel>> Get()
        {
            var items = new List<ItemViewModel>();
            foreach (var item in _itemService.Get())
            {
                items.Add(_itemService.CreateItemViewModel(item));
            }
            return items;
        }

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<ItemViewModel> Get(int id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }
            var itemView = _itemService.CreateItemViewModel(item);

            return itemView;
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Item itemIn)
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
