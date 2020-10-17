using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RzrSite.Models.Comparers
{
  public class FeatureTypeComparer : IEqualityComparer<IFeatureType>
  {
    public bool Equals([AllowNull] IFeatureType first, [AllowNull] IFeatureType second)
    {
      return first.Id.Equals(second.Id);
    }

    public int GetHashCode([DisallowNull] IFeatureType featureType)
    {
      return featureType.GetHashCode();
    }
  }
}
