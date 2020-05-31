using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnarokAPI.DataBaseSettings
{
    public interface IMonsterDatabaseSettings
    {
        public string MonstersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
