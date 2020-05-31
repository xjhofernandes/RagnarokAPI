using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnarokAPI.DataBaseSettings
{
    public class MonsterDatabaseSettingsFix : IMonsterDatabaseSettingsFix
    {
        public string MonstersFixCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
