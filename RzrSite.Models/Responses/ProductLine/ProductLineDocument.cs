using System.Collections.Generic;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.Models.Responses.ProductLine
{
    public class ProductLineDocumentVm
    {
        public int CategoryId { get; set; }
        public int ProductLineId { get; set; }
        public List<ProductLineDocument> Documents = new List<ProductLineDocument>();
    }

    public class ProductLineDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int FileId { get; set; }
        public string FilePath { get; set; }
    }
}
