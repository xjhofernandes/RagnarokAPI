namespace RagnarokAPI.DataBaseSettings
{
    public class MonsterDatabaseSettings : IMonsterDatabaseSettings
    {
        public string MonstersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
