using System.Collections.Generic;

namespace RzrSite.Models.Resources.Feature
{
    public class PutFeatureTableItems
    {
        public int CategoryId { get; set; }
        public List<FutureTableItem> Items { get; set; } = new List<FutureTableItem>();
    }

    public class FutureTableItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TypeId { get; set; }
        public string Value { get; set; }
    }
}
