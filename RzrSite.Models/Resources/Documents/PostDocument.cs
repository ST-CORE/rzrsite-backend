namespace RzrSite.Models.Resources.Documents
{
    public class PostDocument
    {
        public int ProductLineId { get; set; }
        public int FileId { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
    }

    public class PutDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
    }
}
