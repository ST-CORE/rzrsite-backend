using RzrSite.Models.Entities;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.FeatureGroups
{
    public class FeatureList
    {
        public int FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; }
        public List<Feature> Features { get; set; }
    }
}
