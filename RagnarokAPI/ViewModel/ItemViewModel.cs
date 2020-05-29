using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnarokAPI.ViewModel
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }

        public string NameItem { get; set; }

        public string ItemImgUrl { get; set; }

        public string CollectionImgUrl { get; set; }

        public string CardImgUrl { get; set; }

        public string ItemDescription { get; set; }
    }
}
