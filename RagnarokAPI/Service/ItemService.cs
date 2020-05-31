using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using RagnarokAPI.Models;
using RagnarokAPI.Models.Items;
using RagnarokAPI.ViewModel;

namespace RagnarokAPI.Service
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IItemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<Item>(settings.ItemsCollectionName);
        }

        public List<Item> Get() =>
            _items.Find(item => true).ToList();

        public Item Get(int id) =>
            _items.Find<Item>(item => item.IdItem.ItemIdentification == id).FirstOrDefault();

        public List<ItemViewModel> Get(List<int> itemList)
        {
            var ListItem = new List<ItemViewModel>();

            foreach (var item in itemList)
            {
                ListItem.Add(CreateItemViewModel(_items.Find<Item>(x => x.IdItem.ItemIdentification == item).FirstOrDefault()));
            }

            return ListItem;
        }

        public ItemViewModel CreateItemViewModel(Item item)
        {
            if (item == null)
                return null;
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

        public void Update(int id, Item itemIn) =>
            _items.ReplaceOne(item => item.IdItem.ItemIdentification == id, itemIn);

        public void Remove(Item itemIn) =>
            _items.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _items.DeleteOne(item=> item.Id == id);

    }
}
