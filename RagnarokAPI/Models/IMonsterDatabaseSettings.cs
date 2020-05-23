namespace RagnarokAPI.Models
{
    public interface IMonsterDatabaseSettings
    {
        public string MonstersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}