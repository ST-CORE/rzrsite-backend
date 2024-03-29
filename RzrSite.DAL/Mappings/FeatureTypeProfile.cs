﻿using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.FeatureType.Interface;

namespace RzrSite.DAL.Mappings
{
  public class FeatureTypeProfile: Profile
  {
    public FeatureTypeProfile()
    {
      CreateMap<IPutFeatureType, FeatureType>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostFeatureType, FeatureType>();
    }
  }
}
