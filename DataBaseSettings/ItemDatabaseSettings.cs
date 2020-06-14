namespace RagnarokAPI.DataBaseSettings
{
    public class ItemDatabaseSettings : IItemDatabaseSettings
    {
        public string ItemsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}