using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;

namespace RzrSite.Models.Responses.ProductLine
{
    public class FullProductLine
  {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public List<IAdvantage> Advantages { get; set; }
        public List<IDocument> Documents { get; set; }
        public List<IProduct> Products { get; set; }
        public bool IsShowOnMain { get; set; }
        public StrippedDbFile FeaturesPDF { get; set; }
  }
}
