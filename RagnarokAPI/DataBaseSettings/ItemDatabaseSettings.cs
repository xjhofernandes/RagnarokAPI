﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnarokAPI.DataBaseSettings
{
    public class ItemDatabaseSettings : IItemDatabaseSettings
    {
        public string ItemsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}