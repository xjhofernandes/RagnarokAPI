namespace RagnarokAPI.DataBaseSettings
{
    public interface IItemDatabaseSettings
    {
        public string ItemsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
