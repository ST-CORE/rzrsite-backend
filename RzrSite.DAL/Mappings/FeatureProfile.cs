using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Feature.Interfaces;
using RzrSite.Models.Resources.FeatureType.Interface;

namespace RzrSite.DAL.Mappings
{
  public class FeatureProfile: Profile
  {
    public FeatureProfile()
    {
      CreateMap<IPutFeatureType, FeatureType>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostFeatureType, FeatureType>();

      CreateMap<IPutFeature, Feature>();
        }
  }
}
