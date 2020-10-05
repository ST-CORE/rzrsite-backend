using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.Models.Responses.ProductLine
{
    public class ProductLineDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public IDbFile File { get; set; }
    }
}
