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
        public ActionResult<List<Item>> Get() =>
            _itemService.Get();

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<ItemViewModel> Get(int id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }
            var rx = new Regex("<[^>]*>");
            item.Description.ItemDesc = item.Description.ItemDesc != null ? rx.Replace(item.Description.ItemDesc, "") : null;

            var itemView = new ItemViewModel()
            {
                ItemId = item.IdItem.ItemIdentification,
                NameItem = item.Name.NameText,
                CardImgUrl = item.Image.CardImgUrl,
                CollectionImgUrl = item.Image.CollectionImgUrl,
                ItemImgUrl = item.Image.itemImgUrl,
                ItemDescription = item.Description.ItemDesc,
            };

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
