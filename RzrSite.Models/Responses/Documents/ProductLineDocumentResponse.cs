namespace RzrSite.Models.Responses.Documents
{
    public class ProductLineDocumentResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int FileId { get; set; }
        public string FilePath { get; set; }
    }
}
