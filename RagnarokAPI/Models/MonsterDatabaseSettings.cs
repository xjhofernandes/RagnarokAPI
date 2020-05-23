﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnarokAPI.Models
{
    public class MonsterDatabaseSettings : IMonsterDatabaseSettings
    {
        public string MonstersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
